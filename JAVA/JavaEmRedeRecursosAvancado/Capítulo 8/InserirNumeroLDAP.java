/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 8.2
*
*/


import javax.naming.*;
import javax.naming.directory.*;
import java.util.*;

public class InserirNumeroLDAP
{
    
    public static void main (String args[])
    {
        String servidor = "201.54.139.47";
    	String usuario = "cn=admin,dc=meudomain";
    	String senha = "secreto";
    	String rootContext = "dc=meudomain";
        	
        Properties prop = new Properties();
                
        prop.put (Context.INITIAL_CONTEXT_FACTORY, "com.sun.jndi.ldap.LdapCtxFactory");
        prop.put (Context.PROVIDER_URL, "ldap://" + servidor + "/" + rootContext);
        prop.put (Context.SECURITY_PRINCIPAL, usuario);
        prop.put (Context.SECURITY_CREDENTIALS, senha);
        
        try
        {
            DirContext ctx = new InitialDirContext(prop);
                        
            Integer numero = new Integer(47);

	    //O número é inserido na base LDAP
            ctx.bind ("cn=numero", numero);
                                    
            System.out.println ("Número inserido com sucesso.");
        }
        catch (NameAlreadyBoundException exc)
        {
            System.err.println ("Já existe uma entrada LDAP com essa identificação.");
        }
        catch (Exception exc)
        {
            System.err.println (exc.toString());
        }
    }
}