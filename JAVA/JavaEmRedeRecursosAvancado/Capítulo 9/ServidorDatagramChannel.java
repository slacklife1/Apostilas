/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 9.11
*
*/


import java.nio.*;
import java.nio.channels.*;
import java.net.*;

public class ServidorDatagramChannel
{

    static public void main (String [] args)
    {
	try
	{
   	    int porta = 5678;
		
            DatagramChannel servidor = DatagramChannel.open();
		
	    InetSocketAddress enderecoLocal = new InetSocketAddress (porta);
		
	    servidor.socket().bind (enderecoLocal);
		
	    System.out.println ("Servidor UDP pronto.\n");
								
	    ByteBuffer buffer = ByteBuffer.allocate (100);
	    SocketAddress endRemoto = servidor.receive (buffer);
					
	    byte recebido[] = buffer.array();
	    String mensagem = new String (recebido);
			
	    System.out.println ("Mensagem recebida de " + endRemoto + ": " + mensagem);
	}
	catch (Exception exc)
	{
	    System.err.println (exc.toString());
	}
    }
}