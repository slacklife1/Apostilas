/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 9.3
*
*/


import java.nio.*;
import java.nio.channels.*;
import java.net.*;

public class ClienteChannel
{
    static public void main (String entrada [])
    {
        try
	{		
	    int portaServidor = 4756;
	    String enderecoServidor = "185.74.96.123";
		
	    SocketChannel cliente = SocketChannel.open();
		
	    InetSocketAddress enderecoRemoto = new InetSocketAddress (enderecoServidor, portaServidor);
		
	    cliente.connect (enderecoRemoto);
	
	    String texto = "Estou aprendendo Java NIO";
	    ByteBuffer buffer = ByteBuffer.wrap (texto.getBytes());
				
	    int num = cliente.write (buffer);
	    System.out.println ("Bytes enviados: " + num);
	}
	catch (Exception exc)
	{
	    System.err.println (exc.toString());
	}
    }
}