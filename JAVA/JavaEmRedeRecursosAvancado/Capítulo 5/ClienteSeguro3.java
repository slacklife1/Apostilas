/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 5.9
*
*/


import java.security.*;
import javax.net.ssl.*;
import java.io.*;

public class ClienteSeguro3
{

    public static void main (String args[])
    {
	int porta = 8888;
	String servidor = "200.35.201.87";
		
 	try
	{
	    String senha = "70945";
		
	    KeyStore trust =  KeyStore.getInstance("JKS");
			
	    char[] senhaArray = senha.toCharArray();

  	    trust.load(new FileInputStream("certservidor"), senhaArray);
			
	    TrustManagerFactory tmf = TrustManagerFactory.getInstance("SunX509");
	    tmf.init(trust);

 	    SSLContext ctx = SSLContext.getInstance("TLS");
	    ctx.init(null, tmf.getTrustManagers(),  null);
		
	    SSLSocketFactory factory = ctx.getSocketFactory();
	    SSLSocket conexaoSegura = (SSLSocket)factory.createSocket(servidor,porta);
    		
    	    ObjectOutputStream saida = new ObjectOutputStream (conexaoSegura.getOutputStream());
            String mensagem = "Mensagem criptografada";
            saida.writeObject (mensagem);
   
            System.out.println ("Mensagem enviada para o servidor");
   
            conexaoSegura.close();
	}
	catch(Exception exc)
	{
    	    System.out.println(exc.getMessage());
	}
    }
}