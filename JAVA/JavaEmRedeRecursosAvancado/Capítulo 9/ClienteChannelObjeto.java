/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 9.10
*
*/


import java.io.*;
import java.nio.*;
import java.nio.channels.*;
import java.net.*;

public class ClienteChannelObjeto
{

    static public void main (String entrada [])
    {
	try
	{
	    int portaRemota = 4756;
	    String enderecoServidor = "201.25.163.84";
		
 	    InetSocketAddress enderecoRemoto = new InetSocketAddress (enderecoServidor, portaRemota);

	    SocketChannel cliente = SocketChannel.open(enderecoRemoto);
		
	    String nome = "Daniel G. Costa";
	    Usuario user = new Usuario (nome);
			
	    ByteArrayOutputStream saidaByte = new ByteArrayOutputStream ();
	    ObjectOutputStream saidaObjeto = new ObjectOutputStream (saidaByte);
	    saidaObjeto.writeObject (user);
	    saidaObjeto.flush();
			
	    ByteBuffer buffer = ByteBuffer.wrap (saidaByte.toByteArray());
						
	    cliente.write (buffer);
			
	    System.out.println ("Informações enviadas com sucesso.");
	}
	catch (Exception exc)
	{
	    System.err.println (exc.toString());
	}
    }
}