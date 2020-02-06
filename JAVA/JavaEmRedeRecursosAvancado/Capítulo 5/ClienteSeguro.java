/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 5.5
*
*/


import javax.net.ssl.*;
import java.io.*;

public class ClienteSeguro
{

    public static void main (String args[])
    {
	int porta = 2222;
 	String host = "201.25.136.56";
		
  	try
	{
	    SSLSocketFactory factory = (SSLSocketFactory) SSLSocketFactory.getDefault();
   	    SSLSocket conexaoSegura = (SSLSocket) factory.createSocket(host, porta);
    		
    	    DataOutputStream saida = new DataOutputStream (conexaoSegura.getOutputStream());
            int numero = 47;
            saida.writeInt(numero);
            System.out.println ("Número enviado para o servidor");

            conexaoSegura.close();
        }
	catch(Exception exc)
	{
    	    System.out.println(exc.getMessage());
	}
    }
}