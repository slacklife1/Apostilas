/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 8.5
*
*/


import javax.naming.*;
import javax.naming.directory.*;
import java.util.Hashtable;

public class ConsultarDNS
{
    
    public static void main (String args[])
    {
    	try
    	{
      	    Hashtable ht = new Hashtable();
            ht.put("java.naming.factory.initial", "com.sun.jndi.dns.DnsContextFactory");
	    ht.put("java.naming.provider.url", "dns://201.25.169.201");
		
	    DirContext ctx = new InitialDirContext(ht);
				
	    //Recuperação dos registros de tipo A
	    Attributes resultado = ctx.getAttributes("google.com", new String[] {"A"});
            System.out.println ("Registros A: " + resultado.toString());
        	
            resultado = ctx.getAttributes("google.com", new String[] {"MX"});
            System.out.println ("Registros MX: " + resultado.toString());
        }
        catch (Exception exc)
        {
       	    System.err.println (exc.toString());
        }
    }
}