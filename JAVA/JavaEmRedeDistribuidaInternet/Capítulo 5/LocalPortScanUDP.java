/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 5.1
*
*/

import java.net.*;

public class LocalPortScanUDP
{

  static public void main(String[] args)
  {

    int portaInicial = 1;
    int portaFinal = 1023;
    String endereco = null;

    try
    {
      endereco = InetAddress.getLocalHost().toString();
    }
    catch (Exception exc)
    {
      exc.toString();
    }

    StringBuffer portas = new StringBuffer();

    for (int porta = portaInicial; porta <= portaFinal; ++porta)
    {
      try
      {
        DatagramSocket servidor = new DatagramSocket(porta);
        System.out.print ("\rVerificando porta: " + porta);
        servidor.close();
        Thread.sleep (200);
      }
      catch (BindException exc)
      {
        portas.append(porta + "\n");
      }
      catch (Exception exc)
	 		{
 				System.err.println ("Exceção geral: " + exc.toString());
 			}

    }
    System.out.println ("\nPortas encontradas:\n" + portas.toString());
  }
}
