/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 9.9
*
*/


import java.io.*;
import java.nio.*;
import java.nio.channels.*;
import java.net.*;

public class ServidorChannelObjeto
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
						
	    ByteBuffer buffer = ByteBuffer.allocate (1024);
	    conexao.read (buffer);
			
	    ByteArrayInputStream entradaByte = new ByteArrayInputStream(buffer.array());
    	    ObjectInputStream entradaObjeto = new ObjectInputStream(entradaByte);
					
	    Usuario user = (Usuario) entradaObjeto.readObject();
						
	    System.out.println ("Nome do usuário recebido pela rede: " + user.getNome());
		
	}
	catch (Exception exc)
	{
	    System.err.println (exc.toString());
	}
    }
}