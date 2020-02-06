/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 5.4
*
*/

import java.net.DatagramSocket;
import java.net.DatagramPacket;
import java.net.InetAddress;

public class ClienteUDPTexto
{
    public static void main(String args[])
    {
        try
        {
            DatagramSocket socket = new DatagramSocket();

            String texto = "Qual é o seu nome?";

            //Endereço e porta do servidor
            InetAddress endereco = InetAddress.getByName("200.32.165.84");
            int porta = 5265;

            byte[] arrayTexto = texto.getBytes();

            DatagramPacket datagrama = new DatagramPacket (arrayTexto, arrayTexto.length, endereco, porta);
            socket.send(datagrama);
            System.out.println ("Texto enviado: " + texto);

            byte[] dados = new byte[100];
            DatagramPacket retorno = new DatagramPacket (dados, dados.length);

            socket.receive(retorno);
            byte[] recebido = retorno.getData();
            String textoRecebido = new String (recebido);
            System.out.println ("Texto recebido: " + textoRecebido.trim());

            socket.close();
        }
        catch (Exception exc)
        {
            System.err.println (exc.toString());
        }    
    }
}