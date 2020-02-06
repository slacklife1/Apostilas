import java.awt.BorderLayout;
import java.awt.Container;
import java.awt.GridLayout;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.WindowEvent;
import java.awt.event.WindowListener;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;

import javax.swing.JButton;
import javax.swing.JDialog;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JPasswordField;
import javax.swing.JTextField;
import javax.swing.JOptionPane;





public class LoginWindow
	extends JFrame
	implements WindowListener, MouseListener {


	private JButton login = new JButton("Login");
	private JButton cancel = new JButton("Cancelar");
	

	private JTextField user = new JTextField();
	private	JPasswordField pass = new JPasswordField();

	private String server; 
	
	private Socket S;
	private ObjectOutputStream writer;
	private ObjectInputStream reader;
	
	public LoginWindow(String server) throws Exception {
		this.server = server;
		this.setTitle("Java Messenger Login");
		this.setSize(400,100);
		
		this.addWindowListener(this);
		
		JPanel panel = new JPanel();
		BorderLayout layout = new BorderLayout();
		
		panel.setLayout(layout);
		
		GridLayout southLayout = new GridLayout(3,1);
		JPanel southPanel = new JPanel();
		southPanel.setLayout(southLayout);
				
		
		
		login.addMouseListener(this);
		cancel.addMouseListener(this);

		
		southPanel.add(login);
		southPanel.add(cancel);
		southPanel.add(new JLabel());
		
		GridLayout centerLayout = new GridLayout(3,2);
		JPanel centerPanel = new JPanel();
		centerPanel.setLayout(centerLayout);
		

		
		centerPanel.add(new JLabel("Usuário: "));
		centerPanel.add(user);
		centerPanel.add(new JLabel("Senha: "));
		centerPanel.add(pass);
		centerPanel.add(new JLabel());
		centerPanel.add(new JLabel());

		
		panel.add(BorderLayout.CENTER, centerPanel);
		panel.add(BorderLayout.EAST, southPanel); 
		
		
		Container C = this.getContentPane();
		C.add(panel);
		
		this.setVisible(true);
		
		S = new Socket(this.server, 5000);
		writer = new ObjectOutputStream(S.getOutputStream());
		reader =  new ObjectInputStream(S.getInputStream());	
	}


	public void windowOpened(WindowEvent E) {
	}

	public void windowClosing(WindowEvent E) {
		System.exit(0);
	}

	public void windowClosed(WindowEvent E) {
	}

	public void windowIconified(WindowEvent E) {
	}

	public void windowDeiconified(WindowEvent E) {
	}

	public void windowActivated(WindowEvent E) {
	}

	public void windowDeactivated(WindowEvent E) {
	}

	public void mouseClicked(MouseEvent E) {
	}

	public void mousePressed(MouseEvent E) {
	}

	public void mouseReleased(MouseEvent E) {
		if (E.getSource() == this.cancel) System.exit(0);
		
		
		if (E.getSource() == this.login) {
			try {
			
				
				
				String user = this.user.getText();
				String pass= new String(this.pass.getPassword());
				
				writer.writeObject(new Message(user, pass, S.getLocalAddress().getHostAddress()));
				writer.flush();
				
				//Espera para receber a mensagem com os seus amigos e seus status...
				
				Message mensagem = (Message) reader.readObject();
				if (mensagem.getMessage() == null) {
					System.out.println("Online::" + mensagem.getOnlineFriends().size() + "\nOffline::" + mensagem.getOfflineFriends().size());
				
					MessengerWindow messenger = new MessengerWindow(mensagem.getOnlineFriends(), mensagem.getOfflineFriends(), S, user, writer);
				
					this.setVisible(false);
				} else {
				
					if (mensagem.getMessage().equals("FAILED")) {
						JOptionPane pane = new JOptionPane("Usuário e Senha Inválidos!", JOptionPane.ERROR_MESSAGE);
						JDialog dialog = pane.createDialog(this, "Usuario e Senha inválidos");
						dialog.setVisible(true);
						
					}
				}
				
				
			} catch (Exception Ex) {
				Ex.printStackTrace();
			}
			
			//MessengerWindow = new MessengerWindow();				 
		}
		

	}

	public void mouseEntered(MouseEvent E) {
	}

	public void mouseExited(MouseEvent E) {
	}

}
