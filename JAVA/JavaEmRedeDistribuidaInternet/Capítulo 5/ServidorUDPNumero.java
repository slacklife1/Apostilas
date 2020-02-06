/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 5.3
*
*/

import java.net.DatagramSocket;
import java.net.DatagramPacket;

public class ServidorUDPNumero
{
    public static void main(String[] args)
    {
        try
        {
            DatagramSocket socket = new DatagramSocket(2654);        
                    
            byte[] num = new byte[1];
            DatagramPacket datagrama = new DatagramPacket (num, 1);
            socket.receive(datagrama);
            byte[] recebido = datagrama.getData();
            System.out.println ("O número recebido foi: " + recebido[0]);
        }
        catch (Exception exc)
        {
            System.err.println(exc.toString());
        }
                
    }
}