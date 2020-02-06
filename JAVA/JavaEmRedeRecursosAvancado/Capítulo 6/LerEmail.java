/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 6.5
*
*/


import javax.mail.*;
import javax.mail.internet.*;
import java.util.Properties;

public class LerEmail
{

    static public void main (String entrada[])
    {
        try
        {
            String servidorPOP3 = "200.158.95.204";
            String usuario = "daniel";
            String senha = "secreta123";
        
            Properties props = System.getProperties();
            Session session = Session.getDefaultInstance(props, null);
        
            Store pop = session.getStore("pop3");
            pop.connect (servidorPOP3, usuario, senha);
            
            Folder folder = pop.getDefaultFolder();
	    folder = folder.getFolder("INBOX");
            folder.open(Folder.READ_ONLY);
            
            Message[] emails = folder.getMessages();
            
            System.out.println ("Assuntos dos e-mails recebidos:");
            for (int i=0; i < emails.length; i++)
            {
                System.out.println (emails[i].getSubject());
            }
        }
        catch (Exception exc)
        {
            System.out.println(exc.getMessage());
        }
    }
}