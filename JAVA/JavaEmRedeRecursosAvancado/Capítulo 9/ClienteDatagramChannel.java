/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 9.12
*
*/


import java.nio.*;
import java.nio.channels.*;
import java.net.*;

public class ClienteDatagramChannel
{

    static public void main (String entrada [])
    {
	try
	{
	    int portaServidor = 5678;
	    String enderecoServidor = "200.154.67.218";
		
	    DatagramChannel cliente = DatagramChannel.open();
		
	    SocketAddress enderecoRemoto = new InetSocketAddress (enderecoServidor, portaServidor);
		
	    String texto = "Ainda estou aprendendo Java NIO";
            ByteBuffer buffer = ByteBuffer.wrap (texto.getBytes());
			
	    int num = cliente.send (buffer, enderecoRemoto);
			
	    System.out.println ("Bytes enviados: " + num);
	}
	catch (Exception exc)
	{
	    System.err.println (exc.toString());
	}
    }
}