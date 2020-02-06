/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 5.2
*
*/

import java.net.DatagramSocket;
import java.net.DatagramPacket;
import java.net.InetAddress;

public class ClienteUDPNumero
{
    public static void main(String args[])
    {
        try
        {
            DatagramSocket socket = new DatagramSocket();        
        
            InetAddress endereco = InetAddress.getByName("201.156.84.3");
            int porta = 2654;
            byte[] num = new byte[1];
            num[0] = 12;        
            DatagramPacket datagrama = new DatagramPacket (num, 1, endereco, porta);
        
            socket.send(datagrama);
            System.out.println ("Datagrama UDP enviado com sucesso.");
        }
        catch (Exception exc)
        {
            System.err.println (exc.toString());
        }
    }
}