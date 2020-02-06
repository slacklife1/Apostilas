/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 4.2
*
*/

import java.net.Socket;
import java.net.UnknownHostException;
import javax.swing.JOptionPane;

public class PortScanTCP
{

  static public void main (String rede[])
  {
   
    String endereco = JOptionPane.showInputDialog(null, "Digite o endereço do servidor a ser verificado.");

    StringBuffer portasEncontradas = new StringBuffer();

    for (int porta = 20; porta <= 200; porta++)
    {
      try
      {
        System.out.print ("\rVerificando porta " + porta);
        Socket s = new Socket (endereco, porta);
        portasEncontradas.append (porta + "\n");
        s.close();
      }
      catch (UnknownHostException un)
      {
        System.out.println ("O endereço informado não é válido");
        System.exit (0);
      }
      catch (Exception exc)
      {
      }
   }
   System.out.println ("\nPortas TCP encontradas\n" + portasEncontradas.toString());
 }
}

