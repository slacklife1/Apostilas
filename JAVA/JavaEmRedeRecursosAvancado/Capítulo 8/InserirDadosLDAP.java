/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 8.3
*
*/


import javax.naming.*;
import javax.naming.directory.*;
import java.util.*;

public class InserirDadosLDAP
{

    public static void main (String args[])
    {
    	String servidor = "www.java.br";
    	String usuario = "cn=admin,dc=javadomain";
    	String senha = "secreto";
    	String rootContext = "dc=javadomain";
        	
        Properties prop = new Properties();
                
        prop.put (Context.INITIAL_CONTEXT_FACTORY, "com.sun.jndi.ldap.LdapCtxFactory");
        prop.put (Context.PROVIDER_URL, "ldap://" + servidor + "/" + rootContext);
        prop.put (Context.SECURITY_PRINCIPAL, usuario);
        prop.put (Context.SECURITY_CREDENTIALS, senha);
        
        try
        {          
            DirContext contexto = new InitialDirContext(prop);
                        
            contexto.createSubcontext("cn=nomes");
            contexto.bind ("cn=einstein,cn=nomes", "Albert Einstein");
            contexto.bind ("cn=newton,cn=nomes", "Isaac Newton");
                                    
            System.out.println ("Informações inseridas com sucesso.");
            
            String recebido = (String)contexto.lookup("cn=newton,cn=nomes");
            System.out.println ("Informação recuperada: " + recebido);
            
            contexto.rebind ("cn=newton,cn=nomes", "O Grande Isaac Newton");
            
            recebido = (String)contexto.lookup("cn=newton,cn=nomes");
            System.out.println ("Informação recuperada: " + recebido);
            
            contexto.rename ("cn=newton,cn=nomes", "cn=isaac newton,cn=nomes");
           
            contexto.unbind("cn=einstein,cn=nomes");
            
        }
        catch (Exception exc)
        {
            exc.printStackTrace();
        }
    }
}