/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 5.6
*
*/


import javax.net.ssl.*;
import java.io.*;

public class ServidorSeguro2
{

    public static void main (String args[])
    {
	try
	{
	    int porta = 3333;
		
  	    SSLServerSocketFactory ssf = (SSLServerSocketFactory) SSLServerSocketFactory.getDefault();
    	    SSLServerSocket servidor = (SSLServerSocket)ssf.createServerSocket(porta);
    		
    	    SSLSocket conexaoSegura = (SSLSocket)servidor.accept();
    		
    	    DataInputStream entrada = new DataInputStream (conexaoSegura.getInputStream());
            double numero1 = entrada.readDouble();
            double numero2 = entrada.readDouble();
            double resultado = numero1 * numero2;
        
            DataOutputStream saida = new DataOutputStream (conexaoSegura.getOutputStream());
            saida.writeDouble (resultado);
        
            System.out.println ("Resultado da operação: " + resultado);

            conexaoSegura.close();
	}
	catch(Exception exc)
	{
 	    System.out.println(exc.toString());
	}
    }
}