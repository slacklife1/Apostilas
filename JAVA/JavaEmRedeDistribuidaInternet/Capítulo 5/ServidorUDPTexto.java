/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 5.5
*
*/

import java.net.DatagramSocket;
import java.net.DatagramPacket;
import java.net.InetAddress;

public class ServidorUDPTexto
{
    public static void main(String args[])
    {
        try
        {
            DatagramSocket socket = new DatagramSocket(5265);
            byte[] dados = new byte[100];
            DatagramPacket datagrama = new DatagramPacket (dados, dados.length);
            socket.receive(datagrama);

            byte[] recebido = datagrama.getData();
            String textoRecebido = new String (recebido);
            System.out.println ("Texto recebido: " + textoRecebido.trim());

            String texto = "Meu nome é Java!";
            InetAddress endereco = datagrama.getAddress();
            int porta = datagrama.getPort();

            System.out.println ("Porta do cliente: " + porta);

            byte[] arrayTexto = texto.getBytes();
            datagrama = new DatagramPacket (arrayTexto, arrayTexto.length, endereco, porta);
            socket.send(datagrama);
            System.out.println ("Texto enviado: " + texto);

            socket.close();
        }
        catch (Exception exc)
        {
            System.err.println (exc.toString());
        }
   
    }
}
