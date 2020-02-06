/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 8.7
*
*/


import javax.naming.*;
import javax.naming.directory.*;
import java.util.*;
import javax.swing.JOptionPane;

public class Consultar3DNS
{

    public static void main (String args[])
    {
    	try
   	{
 	    Hashtable ht = new Hashtable();
            ht.put("java.naming.factory.initial", "com.sun.jndi.dns.DnsContextFactory");
	    ht.put("java.naming.provider.url", "dns://126.74.204.59");
		
	    DirContext ctx = new InitialDirContext(ht);
						
	    String parametros [] = new String [3];
	    parametros[0] = new String ("NS");
	    parametros[1] = new String ("SOA");
	    parametros[2] = new String ("A");
	
	    String endereco = JOptionPane.showInputDialog (null, "Qual endereço sera consultado?");
			
	    Attributes resultado = ctx.getAttributes(endereco, parametros);
        	
            NamingEnumeration ne = resultado.getAll();

	    //Forma mais detalhada de visualização
            while (ne.hasMoreElements())
            {
		Attribute attr = (Attribute)ne.next();
		String tipo = attr.getID();
		Enumeration en = attr.getAll();
				
		System.out.println("Atributos " + tipo);
	
	 	while (en.hasMoreElements())
		{
		    System.out.println(en.nextElement());
		}
		System.out.println();
	    }
        }
        catch (Exception exc)
        {
            System.err.println (exc.toString());
        }
    }
}