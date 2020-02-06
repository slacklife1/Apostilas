
import java.io.Serializable;
import java.util.Vector;


public class Message implements Serializable {
	private String messageType;
	private String message = null;
	private String sender;
	private String pass = null;
	private String destination = null;
	private String senderip;
	private Vector onlineFriends = null;
	private Vector offlineFriends = null;
	
	


	//	Construtor da classe para Login
	public Message(String user, String pass, String ip)	{
				this.messageType = "LOGIN";
				this.sender = user;
				this.pass = pass;
				this.senderip = ip;
	}
	//Construtor da classe de loginConfirmed
	public Message(Vector onlineFriends, Vector offlineFriends) {
		this.messageType = "LOGINOK";
		this.onlineFriends = onlineFriends;
		this.offlineFriends = offlineFriends;
		
	}

	// Construtor da classe para Mensagem
	public Message(String sender, String message, String destination, String ip) {
			this.messageType = "MESSAGE";
			this.sender = sender;
			this.message = message;
			this.destination = destination;
			this.senderip = ip;
	}
	
	// Construtor da Classe para Logoff
	public Message(String sender) {
		this.messageType = "LOGOFF";
		this.sender = sender;
	}
	// Envia mensagem de que usúario user está online/offline
	public Message(String user, String status) {
		this.messageType = "USER_EVENT";
		this.sender = user;
		this.message = status;
	}
	/*
	// Construtor de classe para cadastro de usuario
	public Message(String sender, String pass, String ip) {
	}
	*/
	



	public String getMessage() {
		return message;
	}


	public String getMessageType() {
		return messageType;
	}


	public String getPass() {
		return pass;
	}


	public String getSender() {
		return sender;
	}


	public String getSenderip() {
		return senderip;
	}
	
	public String getDestination() {
		return destination;
	}
	
	public Vector getOnlineFriends() {
		return onlineFriends;
	}
	
	public Vector getOfflineFriends() {
			return offlineFriends;
	}
	

}
