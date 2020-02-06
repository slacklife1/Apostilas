/*
 * Classe responsavel pelo atendimento das requisi��es dos Clientes. 
 * Login, Disconnect, Mensagem, Cadastro
 */


import java.net.ServerSocket;
import java.net.Socket;







public class MessengerServer {

	public static void main(String[] args) throws Exception {
		
		System.out.println("Iniciando o Servidor Messenger...");
	
	
		ServerSocket server = new ServerSocket(5000);
		
		
		while(true) {
			Socket cliente = new Socket();
			// Espera por requisisi��o de Usuario...
			cliente = server.accept(); 	
			
			// Lan�a Instancia do Servidor para conversar com o usuario...
			MessengerServerClientInstance serverInstace = new MessengerServerClientInstance(cliente);
			serverInstace.start();
			
			
		}
		
	}
}
