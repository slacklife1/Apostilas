/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 5.7
*
*/


import javax.net.ssl.*;
import java.io.*;

public class ClienteSeguro2
{

    public static void main (String args[])
    {
	int porta = 3333;
	String servidor = "servidor.seguro.java.br";

	try
	{
  	    SSLSocketFactory factory = (SSLSocketFactory) SSLSocketFactory.getDefault();
 	    SSLSocket conexaoSegura = (SSLSocket) factory.createSocket(servidor, porta);
   		    		
    	    DataOutputStream saida = new DataOutputStream (conexaoSegura.getOutputStream());
            saida.writeDouble(5.9);
            saida.writeDouble(3.2);
            
            DataInputStream entrada = new DataInputStream (conexaoSegura.getInputStream());
            double resultado = entrada.readDouble();
        
	    System.out.println ("Resultado da operacao: " + resultado);
        
 	    conexaoSegura.close();
	}
	catch(Exception exc)
	{
	    System.out.println(exc.getMessage());
	}
    }
}