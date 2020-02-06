/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 5.6
*
*/

import java.net.DatagramSocket;
import java.net.InetAddress;
import java.net.DatagramPacket;

public class ServidorMulticast {

    public static void main(String args[])
    {
        try
        {
            DatagramSocket socket = new DatagramSocket();
            byte dados[] = new byte[1];
            
            for (;;)
            {   
                dados[0] = (byte)(Math.random()*50);                  
                InetAddress enderecoMulticast = InetAddress.getByName("235.0.0.1");

                DatagramPacket datagrama = new DatagramPacket(dados, 1, enderecoMulticast, 8866);
                socket.send(datagrama);
                
                Thread.sleep (2000);                
            }            
        }
        catch (Exception exc)
        {   
            System.err.println (exc.getMessage());
        }
    }
}