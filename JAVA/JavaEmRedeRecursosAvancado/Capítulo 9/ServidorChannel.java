/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 9.2
*
*/


import java.nio.*;
import java.nio.channels.*;
import java.net.*;

public class ServidorChannel
{

    static public void main (String entrada [])
    {
	try
	{
	    int porta = 4756;
	
	    ServerSocketChannel servidor = ServerSocketChannel.open();
		
	    InetSocketAddress enderecoLocal = new InetSocketAddress (porta);
		
   	    servidor.socket().bind (enderecoLocal);
		
	    System.out.println ("Servidor pronto.\n");
			
	    SocketChannel conexao = servidor.accept();
						
	    ByteBuffer buffer = ByteBuffer.allocate (100);

	    conexao.read (buffer);
	    byte recebido[] = buffer.array();
	    String mensagem = new String (recebido);
			
	    System.out.println ("Mensagem recebida: " + mensagem);
		
	}
	catch (Exception exc)
	{
	    System.err.println (exc.toString());
	}
    }
}