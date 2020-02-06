/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 4.14
*
*/

import java.net.*;
import java.io.*;
import javax.swing.*;
import javax.swing.event.*;
import java.awt.event.*;
import java.util.*;

public class ServidorPonto extends JFrame implements ChangeListener {

private JSlider vel;
static Vector sockets;


  public ServidorPonto() {

         super ("Controle da velocidade dos Pontos");
         vel = new JSlider (SwingConstants.HORIZONTAL, 1, 10, 10);
         vel.setMajorTickSpacing(1);
         vel.setPaintTicks (true);
      	 vel.setInverted (true);
         vel.addChangeListener (this);

         sockets = new Vector (5);

         new Servidor().start();

         getContentPane().add(vel);
         setBounds(200, 200, 300, 80);
         setVisible(true);
  }

  public static void main (String rede[])
  {

        ServidorPonto servidor = new ServidorPonto();
        servidor.addWindowListener(new WindowAdapter () {
            public void windowClosing (WindowEvent evento)
            {
                System.exit (0);
            }
          }
        );
  }
  public void stateChanged (ChangeEvent e)
  {
       Enumeration elementos = sockets.elements();
       while (elementos.hasMoreElements())
       {
          try
          {
           Socket s = (Socket)elementos.nextElement();
           if (!(s.isConnected()))               
           {
               sockets.remove(s);
           }
           else
           {
                DataOutputStream saida = new DataOutputStream (s.getOutputStream());
                saida.writeInt(vel.getValue());
           }
          }
          catch (Exception ee)
          {
            System.err.println ("Problemas na conexão com os clientes.");
          }
       }

  }
}

class Servidor extends Thread
{
  private ServerSocket server;
  public void run ()
  {
    try
    {
      server = new ServerSocket (5555);
      while (true)
      {
        Socket conexao = server.accept();
        ServidorPonto.sockets.add(conexao);
        sleep (500);
      }
    }
    catch (Exception e) {}
    }
  }


