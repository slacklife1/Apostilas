import java.io.ObjectInputStream;
import java.net.ServerSocket;
import java.net.Socket;

//Classe responsavel por receber os eventos do servidor
public class ClientSocketListener extends Thread {

	private ObjectInputStream reader;
	private MessengerWindow window;
	
	public ClientSocketListener(MessengerWindow window) throws Exception {

		
		this.window = window;
		

		
		
		
	}
	
	public void run() {
		ServerSocket serverChanel = null;
		try {		
		
			serverChanel = new ServerSocket(5001);
		
			
		} catch (Exception E) {
			E.printStackTrace();
		}
		
		
		while(true) {
			
			try {
				Socket S = serverChanel.accept();
		
				reader = new ObjectInputStream(S.getInputStream());
				System.out.println("Esperando sinal de servidor...");
				Message mensagem = (Message) reader.readObject();
				System.out.println("recebido" + mensagem.getMessageType());
				if (mensagem.getMessageType().equals("USER_EVENT")) {
					String user = mensagem.getSender();
					String status = mensagem.getMessage();
					System.out.println(" - " + status);
					if (status.equals("online")) {
					//Usuario entrou online
						window.setUserOnline(user);
					} else { 
						window.setUserOffline(user);
					//Usuario está offline
					}
			
				}
		
				if (mensagem.getMessageType().equals("MESSAGE")) {
					String sender = mensagem.getSender();
					String text = mensagem.getMessage();
					window.showMessage(sender, text);
				}
				
			} catch (Exception E) {
				E.printStackTrace();
			}
		}
	}
}
