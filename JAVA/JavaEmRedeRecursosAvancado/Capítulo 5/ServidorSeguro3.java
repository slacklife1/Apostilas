/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 5.8
*
*/


import java.security.*;
import javax.net.ssl.*;
import java.io.*;

public class ServidorSeguro3
{

    public static void main (String args[])
    {
	try
	{
	    String senha = "Ab45";
		
	    KeyStore store = KeyStore.getInstance("JKS");
			
 	    char[] senhaArray = senha.toCharArray();

  	    store.load(new FileInputStream("seguro"), senhaArray);
		
	    KeyManagerFactory kmf = KeyManagerFactory.getInstance("SunX509");
	    kmf.init(store, senhaArray);

	    SSLContext ctx = SSLContext.getInstance("TLS");
	    ctx.init(kmf.getKeyManagers(), null, null);
	    
 	    SSLServerSocketFactory factory = ctx.getServerSocketFactory();
	    SSLServerSocket servidor = (SSLServerSocket)factory.createServerSocket(8888);
			
	    System.out.println ("Aguardando abertura de conexão");
    	    SSLSocket conexaoSegura = (SSLSocket)servidor.accept();
    		
    	    ObjectInputStream entrada = new ObjectInputStream (conexaoSegura.getInputStream());
            String mensagem = (String) entrada.readObject();
            
	    System.out.println ("Texto recebido do host cliente: " + mensagem);
            
 	    conexaoSegura.close();
	}
	catch (Exception exc)
	{
	    System.err.println (exc.toString());
	}
    }
}