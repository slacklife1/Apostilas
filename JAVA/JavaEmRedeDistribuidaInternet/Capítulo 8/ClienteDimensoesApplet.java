/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 8.10
*
*/

import java.net.*;
import java.io.*;
import javax.swing.JApplet;
import javax.swing.JOptionPane;
import java.awt.Graphics;

public class ClienteDimensoesApplet extends JApplet
{
    private int tamanho = 0;
    public void init ()
    {
        //Endereço IP e porta do servidor
  	 		String endereco = "201.25.135.48";
        int porta = 6565;

        try
        {
            Socket conexao = new Socket (endereco, porta);
            DataInputStream entrada = new DataInputStream (conexao.getInputStream());
            
            tamanho = entrada.readInt();
            conexao.close();                
        }
        catch (Exception exc)
        {
            JOptionPane.showMessageDialog(null, "Problema na conexão com o servidor.");
        }
   }
   public void paint (Graphics g)
   {
      if (tamanho < 100)
        g.setColor (java.awt.Color.yellow);
      else if (tamanho < 200)
        g.setColor (java.awt.Color.green);
      else if (tamanho < 300)
        g.setColor (java.awt.Color.blue);
      else
        g.setColor (java.awt.Color.red);

      g.fillRect(10, 10, tamanho, tamanho);
   }
}