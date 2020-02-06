/*
* Java em Rede: Recursos Avan�ados de Programa��o
*
* Daniel G. Costa
*
* Exemplo 9.13
*
*/


import java.nio.*;
import java.nio.channels.*;
import java.net.*;

public class ServidorDatagramChannelFloat
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
								
	    ByteBuffer buffer = ByteBuffer.allocate (8);
	    servidor.receive (buffer);
					
	    buffer.position (0);
	    float num1 = buffer.getFloat();
	    float num2 = buffer.getFloat();
						
	    System.out.println ("N�mero 1: " + num1);
	    System.out.println ("N�mero 2: " + num2);
	    System.out.println ("A soma dos n�meros recebidos �: " + (num1 + num2));
	    
	}
	catch (Exception exc)
	{
	    System.err.println (exc.toString());
	}
    }
}