/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 4.15
*
*/

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.net.*;
import java.io.*;

public class ClientePonto extends JFrame{
static Socket conexao = null;
   public ClientePonto() {

        super ("Ponto");

        setBounds(400, 300, 270, 290);

        String endereco = JOptionPane.showInputDialog(null, "Digite o endereço do servidor");
        new Velocidade (endereco).start();

        Painel pp = new Painel(Color.blue);
        getContentPane().add (pp);
        pp.repaint();
        setResizable(false);
        setVisible(true);
    }
    public static void main (String args[])
    {
        ClientePonto cliente = new ClientePonto();
        cliente.addWindowListener( new WindowAdapter ()
        {
            public void windowClosing (WindowEvent evento)
            {
                try
                {
                    conexao.close();
                    System.exit (0);
                }
                catch (Exception exc)
                {
                  System.err.println (exc.toString());
                }
            }
        });
    }    
}

class Velocidade extends Thread
{
  String endereco = null;
  DataInputStream entrada = null;
  public Velocidade (String endereco)
  {
    this.endereco = endereco;
  }
  public void run ()
  {

    try
      {
        ClientePonto.conexao = new Socket (endereco, 5555);
        entrada = new DataInputStream(ClientePonto.conexao.getInputStream());

        for (;;)
        {
          sleep(500);
          Bolinha.velocidade = 100 * entrada.readInt();  
       }

      }
      catch (Exception e)
      {
        JOptionPane.showMessageDialog(null, "Problemas na abertura de conexão com o servidor\n" + e.getMessage());
        System.exit (1);
      }


  }
}
class Bolinha extends Thread
{
    static int velocidade=1000;
    Painel painel;
    int x, y;
    int contador = 0;
    
    public Bolinha (Painel p)
    {
        painel = p;
        x = 0; y = 0;
    }
        
    public void run ()
    {
        while (true)
        {

            if (contador < 50)
            {
                x+=5;
                contador++;
            }
            else if (contador < 100)
            {
                y+=5;
                contador++;
            }
            else if (contador < 150)
            {
                x-=5;
                contador++;
            }
            else if (contador < 200)
            {
                y-=5;
                contador++;
                if (contador == 200)
                    contador=0;
            }
            painel.alterarValores(x, y);
            painel.repaint();

            try {
              sleep (velocidade);
            }
            catch (Exception e){}
       }     

    }
}

class Painel extends JPanel
{
    int x, y;
    Color cor;
    public Painel(Color c)
    {
        repaint();
        cor = c;
        x =0;
        y =0;
        Bolinha b = new Bolinha(this);
        b.start();
    }
    public void paintComponent(Graphics g)
    {     
        super.paintComponent(g);

        g.drawRect (5, 5, 250, 250);

        g.setColor (cor);
        g.fillOval (x, y, 10, 10);
  
    }
    public void alterarValores (int a, int b)
    {
        x=a;
        y=b;
    }
}
