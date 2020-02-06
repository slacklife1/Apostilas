/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 8.8
*
*/


import javax.naming.Context;
import javax.naming.InitialContext;
import java.util.*;

public class ListarRMI
{
   
    public static void main (String args[])
    {
    	Properties prop = new Properties();
                
        String tipo = "com.sun.jndi.rmi.registry.RegistryContextFactory";
 	prop.put(Context.INITIAL_CONTEXT_FACTORY, tipo);
	prop.put(Context.PROVIDER_URL, "rmi://201.123.84.157:1099");

        
        try
        {
            Context contexto = new InitialContext(prop);

	    //Retorna todo o conteúdo do RMI Registry
            Enumeration en = contexto.list("");
        	
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