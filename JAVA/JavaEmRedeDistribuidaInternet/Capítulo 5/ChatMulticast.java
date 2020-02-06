/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 5.8
*
*/

import java.awt.BorderLayout;
import java.awt.GridLayout;
import java.io.IOException;
import java.net.*;
import javax.swing.*;
import java.awt.event.*;

public class ChatMulticast extends JFrame implements ActionListener
{
    private JTextArea area;
    private JTextField campo;
    private JButton botao;
    private InetAddress enderecoMulticast;
    private int porta = 9999;
    private MulticastSocket socket;
    private String nome;
    
    public ChatMulticast() throws IOException
    {               
        nome = JOptionPane.showInputDialog(null, "Digite o seu nome");
        
        setTitle("Chat Multicast - Usuário " + nome);
        
        area = new JTextArea("Chat iniciado.\n");
        area.setEnabled(false);
        campo = new JTextField (10);        
        botao = new JButton ("Enviar");   
        botao.addActionListener(this);
        
        enderecoMulticast = InetAddress.getByName("236.52.65.8");        
        
        socket = new MulticastSocket(porta);
        socket.joinGroup(enderecoMulticast);
        new Leitora(socket, area).start();
        
        getContentPane().add (area, BorderLayout.CENTER);
        JPanel painel = new JPanel (new GridLayout (1, 2));
        painel.add (campo);
        painel.add (botao);
        getContentPane().add (painel, BorderLayout.SOUTH);
        
        setBounds (300,200,350,400);
        setResizable(false);
        setVisible(true);
    }
    public static void main (String[] programa) throws IOException
    {
        ChatMulticast chat = new ChatMulticast();
        chat.addWindowListener(new WindowAdapter () {
            public void windowClosing (WindowEvent evento)
            {
                System.exit (0);
            }
          }
        );
    }
    public void actionPerformed (ActionEvent evento)
    {
        try
        {           
            byte dados[] = new String (nome + ": " + campo.getText()).getBytes();
            DatagramPacket datagrama = new DatagramPacket(dados, dados.length, enderecoMulticast, porta);
            socket.send (datagrama);     
            campo.setText("");
        }
        catch (Exception exc)
        {
            System.err.println ("Exceção no envio de dados: " + exc.getMessage());
        }
    }
}
class Leitora extends Thread
{
    MulticastSocket socketMulticast;
    JTextArea area;
    public Leitora (MulticastSocket s, JTextArea a)    
    {
        socketMulticast = s;
        area = a;        
    }   
    public void run()
    {
        try
        {
            while (true)
            {
                byte dados[] = new byte [256];                
                DatagramPacket datagrama = new DatagramPacket (dados, dados.length);
                socketMulticast.receive(datagrama);                
                String texto = new String(datagrama.getData());
                area.append("\n" + texto.trim());
                sleep (100);
            }
            
        }
        catch (Exception exc)
        {
            System.err.println (exc.toString());
        }
    }
}
