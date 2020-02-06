import java.io.*;
import java.net.Socket;
import java.sql.*;
import java.util.Vector;


public class MessengerServerClientInstance extends Thread {

	
	private ObjectOutputStream writer;
	private Statement stmtDB;
	
	Socket client = new Socket();

	public MessengerServerClientInstance (Socket client) throws Exception {
	
		this.client = client;
		
		DriverManager.registerDriver(new sun.jdbc.odbc.JdbcOdbcDriver());
		Connection connDB = DriverManager.getConnection("jdbc:odbc:Messenger");	
		
		stmtDB = connDB.createStatement();
		
		this.writer = new ObjectOutputStream(client.getOutputStream());

	}

	
	public void run() {
		
			boolean control = true;
			try { 
				ObjectInputStream reader= new ObjectInputStream(client.getInputStream());

				while (control) {
						
						System.out.println("Esperando mensagem de cliente...");	
								
						 	
						Message mensagem = (Message) reader.readObject();
						
						System.out.println("Recebeu: " + mensagem.getMessageType());
						
						if (mensagem.getMessageType().equals("LOGIN")) {
							//Busca os amigos do usuario e verifica o status de cada um
							//e retorna para o cliente a mensagem;
							Vector online = null;
							Vector offline = null;
							Vector warn = new Vector();
							int id = -1;
							String user = mensagem.getSender();
							String senderip = mensagem.getSenderip();
							String pass = mensagem.getPass();
							System.out.println("select ID, USUARIO " +
															   "from usuarios " + 
															   "where usuario = '" + user + "' and senha = '" + pass + "';");
							
							
							ResultSet rs = stmtDB.executeQuery("select ID, USUARIO " +
															   "from usuarios " + 
															   "where usuario = '" + user + "' and senha = '" + pass + "';");
							
							if (rs.next()) {
								//Se acho o usuario e a senha confere, busca os amigos
								id = rs.getInt("ID");
								
								rs = stmtDB.executeQuery("select usuario, status, ip " +														"from usuarios where id in (" +														"select amigo from amigos where usuario = " + id + ");");
								
								online = new Vector();
								offline = new Vector();
								
								while (rs.next()) {
									
									
									String usr = rs.getString("USUARIO");
									String status = rs.getString("STATUS");
									String ip = rs.getString("IP");
									
									if (status.equals("ONLINE")) {
										online.add(usr);
										warn.add(ip);
									}
									else {
										System.out.println(usr);
										offline.add(usr);
									}
										
									
								}
							} else {
								//LoginFailed
								System.out.println("Usuario e senha não conferem!");
								
								this.writer.writeObject(new Message("SERVER", "FAILED", "", ""));
								this.writer.flush();
								continue;
							}
							System.out.println("Online:" + online.size());
							System.out.println("Offline:" + offline.size());
							Message login = new Message(online, offline);
							this.writer.writeObject(login);
							this.writer.flush();
							
							//Avisa todos os amigos que este entrou online
							Message useronlineevent = new Message(user, "online");
							for (int i=0; i<warn.size(); i++) {
								System.out.println((String) warn.elementAt(i));
								Socket S = new Socket((String) warn.elementAt(i), 5001); 
								//Endereço e porta onde o cliente recebe comunicados do servidor
								ObjectOutputStream writer = new ObjectOutputStream(S.getOutputStream());
								writer.writeObject(useronlineevent);
								writer.flush();
								//writer.close();
								//S.close();
							}
							
							
							//Atualiza seu status na tabela para online
							stmtDB.execute("update USUARIOS set STATUS='ONLINE', IP='"+ senderip +"' where ID=" + id);
							
							
						}
						
						if (mensagem.getMessageType().equals("MESSAGE")) {
							//Recebe a mensagem, verifica para quem vai, e envia.
							ResultSet rs = stmtDB.executeQuery("select id, usuario, ip " +								" from usuarios where usuario = '" + mensagem.getDestination() + "';");
								
							if (rs.next()) {
								Socket S = new Socket(rs.getString("IP"), 5001);
								
								ObjectOutputStream writer = new ObjectOutputStream(S.getOutputStream());
								
								writer.writeObject(mensagem);	//encaminha mensagem ao usuario...
								writer.flush();
								
							}
						}
						
						if (mensagem.getMessageType().equals("LOGOFF")) {
							System.out.println("Efetuando Logoff de " + mensagem.getSender());
							String id = "";
							ResultSet rs = stmtDB.executeQuery("select ID, USUARIO " +
															   "from usuarios " + 
															   "where usuario = '" + mensagem.getSender() + "';");
							
							if (rs.next()) {
								id = rs.getString("ID");
							}
							stmtDB.execute("update USUARIOS set STATUS='OFFLINE', IP=null where ID=" + id + ";");
							
							//Envia mensagem para todos os usuarios dizendo este estar offline
							rs = stmtDB.executeQuery("select usuario, status, ip " +
												     "from usuarios where id in (" +
													 "select amigo from amigos where usuario = " + id + ");");
							Message userofflineevent = new Message(mensagem.getSender(), "offline");
							while(rs.next()) {
								//System.out.println(rs.getString("USUARIO"));
								if (rs.getString("STATUS").equals("OFFLINE")) continue;
								System.out.println("Enviando mensagem de logoff para" + rs.getString("USUARIO"));
								Socket S = new Socket(rs.getString("IP"), 5001); 
								//Endereço e porta onde o cliente recebe comunicados do servidor
								ObjectOutputStream writer = new ObjectOutputStream(S.getOutputStream());
								writer.writeObject(userofflineevent);
								writer.flush();
								//writer.close();
								//S.close();
																												 
							}
							
							//reader.close();
							//client.close();
							control = false;
						
						}
						
						if (mensagem.getMessageType().equals("NOVOUSUARIO")) {
							//Recebe a mensagem e cria o usuario na base de dados
							
						}
						
						if (mensagem.getMessageType().equals("ADICIONARAMIGO")) {
							// Recebe a mensagem e adiciona o amigo no banco de dados
							
						}
						
						
						
						
						
				}
					
			} catch (Exception E) {
				E.printStackTrace();
			}
			
		System.out.println("Finalizando thread!");
		
		}
	

}
