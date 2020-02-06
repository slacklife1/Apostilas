/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 8.6
*
*/


import javax.naming.*;
import javax.naming.directory.*;
import java.util.*;
import javax.swing.JOptionPane;

public class Consultar2DNS
{

    public static void main (String args[])
    {
    	try
    	{
 	    Hashtable ht = new Hashtable();
            ht.put("java.naming.factory.initial", "com.sun.jndi.dns.DnsContextFactory");
	    ht.put("java.naming.provider.url", "dns://200.125.52.187");
		
	    DirContext ctx = new InitialDirContext(ht);
				
	    //Três tipos de registro DNS
	    String parametros [] = new String [3];
	    parametros[0] = new String ("NS");
	    parametros[1] = new String ("A");
	    parametros[2] = new String ("MX");
			
	    String endereco = JOptionPane.showInputDialog (null, "Qual endereço será consultado?");
			
    	    Attributes resultado = ctx.getAttributes(endereco, parametros);
        	
            Enumeration en = resultado.getAll();
				
	    while (en.hasMoreElements())
	    {
		System.out.println(en.nextElement());
	    }
        }
        catch (Exception exc)
        {
            System.err.println (exc.toString());
        }
    }
}