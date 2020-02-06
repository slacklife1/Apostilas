/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 2.4
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
        
            InetAddress enderecoServidor = InetAddress.getByName("201.156.84.3");
            int portaServidor = 2654;
            byte[] num = new byte[1];
            num[0] = 12;
            DatagramPacket datagrama = new DatagramPacket (num, 1, enderecoServidor, portaServidor);
        
            socket.send(datagrama);
            System.out.println ("Datagrama UDP enviado com sucesso.");
        }
        catch (Exception exc)
        {
            System.err.println (exc.toString());
        }
    }
}