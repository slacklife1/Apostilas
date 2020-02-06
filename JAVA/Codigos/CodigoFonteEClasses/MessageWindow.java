import java.awt.BorderLayout;
import java.awt.Container;
import java.awt.GridLayout;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.WindowEvent;
import java.awt.event.WindowListener;
import java.io.ObjectOutputStream;

import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JButton;
import javax.swing.JTextArea;

public class MessageWindow
	extends JFrame
	implements WindowListener, MouseListener {

	private ObjectOutputStream writer;
	
	private JButton send = new JButton("Enviar");
	private JButton cancel = new JButton("Cancelar");

	private JTextArea history;
	private JTextArea message = new JTextArea();
	


	private String user;
	private String sender;

	public MessageWindow(String sender, String user, ObjectOutputStream writer) {

		this.writer = writer;
		this.user = user;
		this.sender = sender;
		
		
		
		this.setTitle(user);
		this.setSize(400,300);
		
		
		this.addWindowListener(this);
		
		JPanel panel = new JPanel();
		BorderLayout layout = new BorderLayout();
		
		panel.setLayout(layout);
		
		GridLayout eastLayout = new GridLayout(2,1);
		JPanel eastPanel = new JPanel();
		eastPanel.setLayout(eastLayout);
				
		send.addMouseListener(this);
		cancel.addMouseListener(this);
		
		
		eastPanel.add(send);
		eastPanel.add(cancel);
	
		
		GridLayout centerLayout = new GridLayout(3,1);
		JPanel centerPanel = new JPanel();
		centerPanel.setLayout(centerLayout);
		
		this.history = new JTextArea();
		this.history.setEditable(false);
		
		
		
		centerPanel.add(this.history);
		centerPanel.add(new JLabel("Mensagem: "));
		centerPanel.add(message);
		
		panel.add(BorderLayout.CENTER, centerPanel);
		panel.add(BorderLayout.EAST, eastPanel); 
		
		
		Container C = this.getContentPane();
		C.add(panel);
		
		this.setVisible(true);
	}
	
	public String getHistory() {
		return this.history.getText();
	}
	
	public void setText(String text) {
		this.history.setText(text);
	}

	public void windowOpened(WindowEvent E) {


	}


	public void windowClosing(WindowEvent E) {


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

		if (E.getSource() == this.send) {
			if (!this.message.getText().equals("")) {
				//Envia a mensagem...
				Message mensagem = new Message(sender, this.message.getText(), user, "1");
				try {
					writer.writeObject(mensagem);
					writer.flush();
				} catch (Exception Ex) {
					Ex.printStackTrace();
				}
				
			this.message.setText("");
			this.history.setText(this.history.getText() + "\n" + sender + ": " + mensagem.getMessage());
			}
			
		}
		
		if (E.getSource() == this.cancel) {
			this.setVisible(false);
		}
	}


	public void mouseEntered(MouseEvent E) {


	}


	public void mouseExited(MouseEvent E) {


	}

}
