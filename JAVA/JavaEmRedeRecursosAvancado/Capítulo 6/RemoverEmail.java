/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 6.7
*
*/


import javax.mail.*;
import javax.mail.internet.*;
import java.util.Properties;

public class RemoverEmail
{

    static public void main (String args[])
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
            folder.open(Folder.READ_WRITE);
            
            Message[] emails = folder.getMessages();
            
            System.out.println ("Lendo os e-mails:");
            for (int i=0; i < emails.length; i++)
            {
                System.out.println (emails[i].getSubject());
                emails[i].setFlag(Flags.Flag.DELETED, true);
            }

            folder.close(true);
        }
        catch (Exception exc)
        {
            System.out.println(exc.toString());
        }
    }
}
