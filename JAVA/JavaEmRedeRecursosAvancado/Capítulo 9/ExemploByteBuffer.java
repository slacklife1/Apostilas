/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 9.1
*
*/


import java.nio.*;

public class ExemploByteBuffer
{
 
    public static void main (String entrada[])
    {
	ByteBuffer buffer = ByteBuffer.allocate (20);
		
	System.out.println ("O ByteBuffer foi criado.\n");
	
	System.out.println ("Propriedades do ByteBuffer após ser criado:");
	System.out.println ("Capacidade: " + buffer.capacity());
	System.out.println ("Limite: " + buffer.limit());
	System.out.println ("Posição atual: " + buffer.position() + "\n");
		
	System.out.println ("Colocando valores no ByteBuffer:");
	buffer.put ((byte) 2);
	buffer.put ((byte) 47);
	buffer.putInt (56);	
		
	System.out.println ("Propriedades do ByteBuffer após inserir valores:");
	System.out.println ("Capacidade: " + buffer.capacity());
	System.out.println ("Limite: " + buffer.limit());
	System.out.println ("Posição atual: " + buffer.position() + "\n");
		
	buffer.position (0);		
	System.out.println ("Lendo o Bytebuffer da primeira forma:");
	
	while (buffer.hasRemaining())
	{
	    System.out.print (buffer.get() + " ");
	}
		
	System.out.println ( );
		
	System.out.println ("Lendo o Bytebuffer da segunda forma:");
		
	byte array[] = buffer.array();
	for (int i=0; i < array.length;i++)
	{
	    System.out.print (array[i] + " ");
	}
			
	String mensagem = ("Estou conhecendo o ByteBuffer");
	ByteBuffer buffer2 = ByteBuffer.wrap (mensagem.getBytes());

	System.out.println ("\n\nPropriedades do segundo ByteBuffer:");
	System.out.println ("Capacidade: " + buffer2.capacity());
	System.out.println ("Limite: " + buffer2.limit());
	System.out.println ("Posição atual: " + buffer2.position() + "\n");
		
	System.out.println ("Lendo o segundo Bytebuffer:");
		
	while (buffer2.hasRemaining())
	{
    	    System.out.print (buffer2.get() + " ");
	}
		
	buffer.position (10);
	buffer.putInt (11);
	buffer.putInt (65);		
	System.out.println ("\n\nint na posição 10: " + buffer.getInt (10));
	System.out.println ("int na posição 14: " + buffer.getInt (14));
	
	System.out.println ( );
	buffer.position (0);
		
	System.out.println ("Conteúdo final do ByteBuffer:");
	while (buffer.hasRemaining())
	{
	    System.out.print (buffer.get() + " ");
	}
				
	System.out.println ( );
	System.out.println ( );
	
	buffer = ByteBuffer.allocateDirect (100);
	CharBuffer textoBuffer = buffer.asCharBuffer();
	textoBuffer.put ("Um texto de exemplo.");
			
	textoBuffer.position (0);
	System.out.print ("String: ");
	while (textoBuffer.hasRemaining())
	{
    	    System.out.print (textoBuffer.get());
	}
		
	System.out.println ( );
    }
}