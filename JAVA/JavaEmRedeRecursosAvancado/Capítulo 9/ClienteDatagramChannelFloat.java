/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 9.14
*
*/


import java.nio.*;
import java.nio.channels.*;
import java.net.*;

public class ClienteDatagramChannelFloat
{

    static public void main (String entrada [])
    {
	try
	{
	    int portaServidor = 5678;
	    String enderecoServidor = "www.java.br";
		
   	    DatagramChannel cliente = DatagramChannel.open();
		
	    SocketAddress enderecoRemoto = new InetSocketAddress (enderecoServidor, portaServidor);
		
	    cliente.connect (enderecoRemoto);
	
	    ByteBuffer buffer = ByteBuffer.allocate (8);
	    buffer.putFloat (3.4f);
	    buffer.putFloat (4.73f);
	    buffer.flip();
			
	    int num = cliente.write (buffer);
			
	    System.out.println ("Bytes enviados: " + num);
	}
	catch (Exception exc)
	{
	    System.err.println (exc.toString());
	}
    }
}