/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 6.6
*
*/


import javax.mail.*;
import javax.mail.internet.*;
import java.util.Properties;
import java.io.*;

public class LerEmail2
{
    static public void main (String args[])
    {
        try
        {
            String servidorPOP3 = "pop3.servidor.com";
            String usuario = "danielgcosta";
            String senha = "secreta123";
        
            Properties props = System.getProperties();
            Session session = Session.getDefaultInstance(props, null);
        
            Store pop = session.getStore("pop3");
            pop.connect (servidorPOP3, usuario, senha);
            
            Folder folder = pop.getDefaultFolder();
            folder = folder.getFolder("INBOX");
            folder.open(Folder.READ_ONLY);
            
            Message[] emails = folder.getMessages();
            
            Message mensagem = null;
            
            System.out.println ("E-mails recebidos:\n");
            for (int i=0; i < emails.length; i++)
            {
                System.out.println ("E-mail " + (i+1));
                
                mensagem = emails[i];
                InternetAddress origem = (InternetAddress)mensagem.getFrom()[0];
                
                System.out.println ("Assunto: " + mensagem.getSubject());
                System.out.println ("Origem: " + origem.getAddress());
                System.out.println ("De: " + origem.getPersonal());
                
                InputStream entrada = mensagem.getInputStream();
                BufferedReader reader = new BufferedReader(new InputStreamReader(entrada));
                String linha = reader.readLine();

                System.out.println ("Mensagem:");
                while (linha!=null)
                {
                    System.out.println(linha);
                    linha=reader.readLine();
                }
                
                System.out.println ();
            }
        }
        catch (Exception exc)
        {
            System.out.println(exc.getMessage());
        }
    }
}