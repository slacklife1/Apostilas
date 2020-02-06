/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 5.7
*
*/

import java.net.InetAddress;
import java.net.DatagramPacket;
import java.net.MulticastSocket;

public class ClienteMulticast 
{

  public static void main(String net[]) 
  {
      try
      {
            MulticastSocket socket = new MulticastSocket(8866);
            InetAddress endereco = InetAddress.getByName("235.0.0.1");
            socket.joinGroup(endereco);

            byte dados[] = new byte[1];

            DatagramPacket datagrama = new DatagramPacket(dados, 1);
            for (;;)
            {
                socket.receive(datagrama);
                dados = datagrama.getData ();
                System.out.println ("Número recebido: " + dados[0]);
            }
            
      }
      catch (Exception exc)
      {
          System.err.println (exc.toString());                    
      }
     }
   }