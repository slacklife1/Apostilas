/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 8.4
*
*/


import javax.naming.*;
import javax.naming.directory.*;
import java.util.*;

public class ConsultarLDAP
{
    
    public static void main (String args[])
    {
    	String servidor = "200.25.139.68";
    	String usuario = "cn=admin,dc=basejava";
    	String senha = "minhasenha";
        	
        Properties prop = new Properties();
                
        prop.put (Context.INITIAL_CONTEXT_FACTORY, "com.sun.jndi.ldap.LdapCtxFactory");
        prop.put (Context.PROVIDER_URL, "ldap://" + servidor);
        prop.put (Context.SECURITY_PRINCIPAL, usuario);
        prop.put ( Context.SECURITY_CREDENTIALS, senha);
        
        try
        {
            DirContext contexto = new InitialDirContext(prop);
        	
            SearchControls sc = new SearchControls();
	    sc.setSearchScope (SearchControls.SUBTREE_SCOPE);
			
	    Enumeration en = contexto.search("dc=basejava","cn=newton",sc);

	    System.out.println ("Busca por newton:");
	    while (en.hasMoreElements())
	    {
		System.out.println (en.nextElement());
	    }
			
	    en = contexto.search("dc=basejava","cn=*",sc);

 	    System.out.println ("\n\nBusca por todos os cn:");
	    while (en.hasMoreElements())
	    {
		System.out.println(en.nextElement());
	    }
            
            Attributes att = new BasicAttributes(true);
	    att.put(new BasicAttribute("cn", "admin"));
	    en = contexto.search("dc=basejava",att);
	
	    System.out.println ("\n\nNova busca por newton:");
	    while (en.hasMoreElements())
	    {
		System.out.println (en.nextElement());
	    }
       	}
        catch (Exception exc)
 	{
            System.err.println (exc.toString());
        }
    }
}