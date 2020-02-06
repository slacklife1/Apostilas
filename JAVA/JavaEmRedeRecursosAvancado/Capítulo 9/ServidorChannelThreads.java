/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 9.4
*
*/


import java.nio.*;
import java.nio.channels.*;
import java.net.*;

public class ServidorChannelThreads
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
			
	    while (true)
	    {
		SocketChannel conexao = servidor.accept();
				
		new Gerenciador (conexao).start();
	    }
		
	}
	catch (Exception exc)
	{
	    System.err.println (exc.toString());
	}
    }
}

class Gerenciador extends Thread
{
    private SocketChannel conexao;
	
    public Gerenciador (SocketChannel con)
    {
	conexao = con;
    }
    public void run()
    {
	try
	{
	    ByteBuffer buffer = ByteBuffer.allocate (4);
	    while (true)
	    {
		conexao.read (buffer);
			
		buffer.position (0);
		int recebido = buffer.getInt();
						
		String remoto = conexao.socket().getInetAddress().toString();
		remoto = remoto + ": " + conexao.socket().getPort();
				
		System.out.println ("Número recebido do cliente " + remoto + ": " + recebido);
			
		int enviado = (int)Math.pow (recebido, 2);
			
		buffer.clear();
		buffer.putInt (enviado);
		buffer.flip();
		conexao.write (buffer);
			
		System.out.println ("Número enviado para o cliente: " + enviado);
					
		buffer.clear();
  	    }
	}
	catch (Exception exc)
	{
	    System.err.println (exc.toString());
	}
    }
}