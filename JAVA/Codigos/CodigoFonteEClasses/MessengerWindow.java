import java.awt.BorderLayout;
import java.awt.Container;
import java.awt.GridLayout;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.WindowEvent;
import java.awt.event.WindowListener;
import java.io.ObjectOutputStream;
import java.net.Socket;
import java.util.Hashtable;
import java.util.Vector;


import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;


public class MessengerWindow
	extends JFrame
	implements MouseListener, WindowListener {
	
	private Socket S = new Socket();
	private ObjectOutputStream writer;
	private String user;
	private Vector usersOnline;
	private Vector usersOffline;
	private JPanel panel = new JPanel();
	
	private Hashtable conversations = new Hashtable();
	
	
	public MessengerWindow(Vector onlineFriends, Vector offlineFriends, Socket S, String user, ObjectOutputStream writer) throws Exception{
		this.S = S;
		this.writer = writer;
		this.user = user;
		int online = onlineFriends.size();
		int offline = offlineFriends.size();
		
		ClientSocketListener listener = new ClientSocketListener(this);
		listener.start(); 
		
		this.usersOnline = onlineFriends;
		this.usersOffline = offlineFriends;
		
		System.out.println("Oline:" + online + "\nOffline: " + offline);
		this.setTitle("Java Messenger Online");
		this.setSize(100,500);
		
		this.addWindowListener(this);
		

		BorderLayout layout = new BorderLayout();
		
		panel.setLayout(layout);
		

		GridLayout centerLayout = new GridLayout(offline+online+2,1);
		JPanel centerPanel = new JPanel();
		centerPanel.setLayout(centerLayout);
		
		centerPanel.add(new JLabel("Usuarios Online:"));
		for (int i=0; i<online; i++) {
			JLabel label = new JLabel((String)onlineFriends.elementAt(i));
			label.addMouseListener(this);
			centerPanel.add(label);
		}
		
		centerPanel.add(new JLabel("Usuarios Offline:"));
		for (int i=0; i<offline; i++) {
					centerPanel.add(new JLabel((String)offlineFriends.elementAt(i)));
		}
		
		panel.add(BorderLayout.CENTER, centerPanel);
		
		
		Container C = this.getContentPane();
		C.add(panel);
		
		this.pack();
		this.setVisible(true);
	}
	
	public void setUserOnline(String user) {
		this.usersOffline.remove(user);
		this.usersOnline.add(user);
		System.out.println("User: " + user + " - online");
		this.refresh();
		
		
	}
	
	public void setUserOffline(String user) {
		this.usersOnline.remove(user);
		this.usersOffline.add(user);
		this.refresh();
		System.out.println("User: " + user + " - offline");
	}
	
	public void refresh() {
		int offline = this.usersOffline.size();
		int online = this.usersOnline.size();

		GridLayout centerLayout = new GridLayout(offline+online+2,1);
		JPanel centerPanel = new JPanel();
		centerPanel.setLayout(centerLayout);
		centerPanel.add(new JLabel("Usuarios Online:"));
		for (int i=0; i<online; i++) {
			JLabel label = new JLabel((String)this.usersOnline.elementAt(i));
			label.addMouseListener(this);
			centerPanel.add(label);
		}

		centerPanel.add(new JLabel("Usuarios Offline:"));
		for (int i=0; i<offline; i++) {
			centerPanel.add(new JLabel((String)this.usersOffline.elementAt(i)));
		}

		panel.removeAll();
		panel.add(BorderLayout.CENTER, centerPanel);
		Container C = this.getContentPane();
		C.add(panel);

		this.repaint();
		C.repaint();
		
		this.pack();
	}
	
	public void showMessage(String user, String message) {
		
		if (conversations.containsKey(user)){
			
			MessageWindow M = (MessageWindow) conversations.get(user);
			M.setText(M.getHistory() + "\n" + user + ": " + message);
			M.setVisible(true);
		} else {
			MessageWindow M = new MessageWindow(this.user, user, this.writer);
			M.setText(message);
			
			conversations.put(user, M);
		}
	}

	public void mouseClicked(MouseEvent E) {


	}

	public void mousePressed(MouseEvent E) {


	}

	public void mouseReleased(MouseEvent E) {
		String destination = ((JLabel)E.getSource()).getText();
		if (conversations.containsKey(user)){
			MessageWindow M = (MessageWindow) conversations.get(user);

			M.setVisible(true);
		} else {
			MessageWindow M = new MessageWindow(this.user, destination, this.writer);
			conversations.put(destination, M);
		}		
	}

	public void mouseEntered(MouseEvent E) {


	}

	public void mouseExited(MouseEvent E) {


	}

	public void windowOpened(WindowEvent E) {


	}

	public void windowClosing(WindowEvent E) {
		
		Message logoff = new Message(user);
		try {
 
			writer.writeObject(logoff);
			writer.flush();

		} catch (Exception Ex) {
			Ex.printStackTrace();
		}
		
		
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

}
