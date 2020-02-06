/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 9.6
*
*/


import java.nio.*;
import java.nio.channels.*;
import java.nio.channels.spi.*;
import java.util.*;
import java.net.*;

public class ServidorChannelNB
{
    private Selector selec;
    private ByteBuffer buffer;

    static public void main (String entrada [])
    {
	new ServidorChannelNB();
    }
    public ServidorChannelNB ()
    {
	try
	{
	    int porta = 4756;
		
	    ServerSocketChannel servidor = ServerSocketChannel.open();
	    servidor.configureBlocking (false);
			
	    selec = SelectorProvider.provider().openSelector();
		
	    InetSocketAddress enderecoLocal = new InetSocketAddress (porta);
		
	    servidor.socket().bind (enderecoLocal);
		
	    System.out.println ("Servidor pronto.\n");
									
	    servidor.register(selec, SelectionKey.OP_ACCEPT);
	    while (true)
	    {
	        selec.select();
		Set readyKeys = selec.selectedKeys();
            	Iterator i = readyKeys.iterator();
				
	   	while (i.hasNext())
		{
	            SelectionKey selecionada = (SelectionKey)i.next();
    	            i.remove();

        	    if (selecionada.isAcceptable())
		    {
            	        iniciarConexao (selecionada);
                    }
                    if (selecionada.isValid() && selecionada.isReadable())
                    {
	               	receberEnviarDados(selecionada);
    	            }
            	}
		
	    }
		
	}
	catch (Exception exc)
	{
	    System.err.println (exc.toString());
	}
    }

    public void iniciarConexao (SelectionKey skey) throws Exception
    {
	ServerSocketChannel servidor = (ServerSocketChannel)skey.channel();
        
        SocketChannel conexao = servidor.accept();
        conexao.configureBlocking(false);

        conexao.register(selec, SelectionKey.OP_READ);
    }
	
    public void receberEnviarDados (SelectionKey skey) throws Exception
    {
	SocketChannel conexao = (SocketChannel)skey.channel();
        buffer = ByteBuffer.allocate(4);
       
        conexao.read(buffer);
        buffer.flip();
        
        buffer.position (0);
	int recebido = buffer.getInt();
		
	String remoto = conexao.socket().getInetAddress().toString();
	remoto = remoto + ":" + conexao.socket().getPort();
	System.out.println ("Número recebido do cliente " + remoto + " - " + recebido);
        
        int enviado = (int)Math.pow (recebido, 2);
        
        System.out.println ("Número enviado para o cliente " + remoto + " - " + enviado);
			
	buffer.clear();
	buffer.putInt (enviado);
	buffer.flip();
	conexao.write (buffer);
    }
}