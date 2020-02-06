/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 8.1
*
*/


import javax.naming.*;
import javax.naming.directory.*;
import java.util.*;

public class ListarLDAP
{

    public static void main (String args[])
    {
    	String servidorLDAP = "201.54.139.47";
    	String usuario = "cn=admin,dc=meudomain";
    	String senha = "secreta";
        	
        Properties prop = new Properties();
            
	//Propriedades para iniciação do Context
        prop.put (Context.INITIAL_CONTEXT_FACTORY, "com.sun.jndi.ldap.LdapCtxFactory");
        prop.put (Context.PROVIDER_URL, "ldap://" + servidorLDAP);
        prop.put (Context.SECURITY_PRINCIPAL, usuario);
        prop.put (Context.SECURITY_CREDENTIALS, senha);
        
        try
        {
            Context contexto = new InitialContext (prop);
            NamingEnumeration lista = contexto.list ("dc=meudomain");

  	    while (lista.hasMore())
	    {
    		NameClassPair nc = (NameClassPair)lista.next();
    		System.out.println(nc);
	    }
		
	    System.out.println ();
			
	    lista = contexto.listBindings("dc=meudomain");

  	    while (lista.hasMore())
	    {
    		NameClassPair ncp = (NameClassPair)lista.next();
    		System.out.println(ncp);
	    }
       	}
        catch (Exception exc)
	{
            System.err.println (exc.toString());
        }
    }
}