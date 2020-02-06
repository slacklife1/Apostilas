/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 9.5
*
*/


import java.nio.*;
import java.nio.channels.*;
import java.net.*;
import javax.swing.JOptionPane;

public class ClienteChannelThreads
{
    static public void main (String entrada [])
    {
	try
	{
	    int porta = 4756;
	    String enderecoServidor = JOptionPane.showInputDialog (null, "Qual é o endereço do servidor?");
		
	    SocketChannel conexao = SocketChannel.open();
		
  	    InetSocketAddress enderecoRemoto = new InetSocketAddress (enderecoServidor, porta);
		
	    conexao.connect (enderecoRemoto);
		
	    ByteBuffer buffer = ByteBuffer.allocate (4);
	    while (true)
	    {
		buffer.clear();
		buffer.putInt ((int)(Math.random()*100));
		buffer.flip();
			
		int num = conexao.write (buffer);
		System.out.println ("Bytes enviados: " + num);
			
		buffer.clear();
		conexao.read (buffer);
					
		buffer.position (0);
		int recebido = buffer.getInt();
						
		System.out.println ("Número recebido do servidor: " + recebido);
				
		Thread.sleep (2000);
	    }
	}
	catch (Exception exc)
	{
	    System.err.println (exc.toString());
	}
    }
}