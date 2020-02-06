/*
* Java em Rede: Recursos Avan�ados de Programa��o
*
* Daniel G. Costa
*
* Exemplo 9.7
*
*/


import java.nio.*;
import java.nio.channels.*;
import java.net.*;
import javax.swing.JOptionPane;

public class ClienteChannelNB
{

    static public void main (String entrada [])
    {
	try
	{
	    int porta = 4756;
	    String enderecoServidor = JOptionPane.showInputDialog (null, "Qual � o endere�o do servidor?");
		
	    SocketChannel conexao = SocketChannel.open();
		
	    InetSocketAddress enderecoRemoto = new InetSocketAddress (enderecoServidor, porta);
		
	    conexao.connect (enderecoRemoto);
			
	    ByteBuffer buffer = ByteBuffer.allocate (4);
			
	    while (true)
	    {
		int num = (int)(Math.random()*100);
		buffer.putInt (num);
		buffer.flip();
			
		conexao.write (buffer);
		System.out.println ("N�mero enviado para o servidor: " + num);
			
		buffer.clear();
		conexao.read (buffer);
					
		buffer.position (0);
		int recebido = buffer.getInt();
						
		System.out.println ("N�mero recebido do servidor: " + recebido);
					
		buffer.clear();
		Thread.sleep ((int)(Math.random() * 4000)+300);
					
	    }
	}
	catch (Exception exc)
	{
	    System.err.println (exc.toString());
	}
    }
}