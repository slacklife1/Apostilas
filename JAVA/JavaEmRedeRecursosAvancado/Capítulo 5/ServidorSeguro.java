/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 5.4
*
*/


import javax.net.ssl.*;
import java.io.*;

public class ServidorSeguro
{

    public static void main (String args[])
    {
	try 
        {
	    int porta = 2222;

 	    SSLServerSocketFactory ssf = (SSLServerSocketFactory) SSLServerSocketFactory.getDefault();
    	    SSLServerSocket servidorSeguro = (SSLServerSocket)ssf.createServerSocket(porta);
    		
	    System.out.println ("Aguardando abertura de conexão");
    	    SSLSocket conexaoSegura = (SSLSocket)servidorSeguro.accept();
    		
    	    DataInputStream entrada = new DataInputStream (conexaoSegura.getInputStream());                        
            int recebido = entrada.readInt();
            System.out.println ("Número recebido do cliente: " + recebido);
            
	    conexaoSegura.close();
	}  
	catch(Exception exc) 
	{  
	    System.out.println(exc.getMessage());          
	}		
    }
}