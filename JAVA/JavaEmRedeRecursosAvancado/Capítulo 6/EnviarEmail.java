/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 6.2
*
*/


import javax.mail.*;
import javax.mail.internet.*;
import java.util.Properties;

public class EnviarEmail
{
    String servidorSMTP = "200.25.32.178";
    String origem = "daniel@yahoo.com";
    String destino = "newton@gmail.com";

    public static void main (String args[]) throws Exception
    {
        EnviarEmail programa = new EnviarEmail();
        
        Properties prop = new Properties();
        prop.put("mail.smtp.host", programa.servidorSMTP);
        prop.put ("mail.transport.protocol", "smtp");
        prop.put ("mail.smtp.auth", "false");
        prop.put ("mail.debug", "true");
        prop.put ("mail.smtp.debug", "true");
        prop.put ("mail.mime.charset", "ISO-8859-1");
        prop.put ("mail.smtp.port", "25");
        prop.put ("mail.smtp.starttls.enable", "false");
        prop.put ("mail.smtp.socketFactory.port", "25");
        prop.put ("mail.smtp.socketFactory.fallback", "false");
               
        Session session = Session.getInstance(prop, null);
        MimeMessage msg = new MimeMessage(session);
        
        msg.setFrom(new InternetAddress (programa.origem));
        msg.setRecipient(Message.RecipientType.TO, new InternetAddress(programa.destino));
        
        msg.setSentDate(new java.util.Date());
        
        msg.setSubject("Mensagem de teste");
        msg.setText ("O JavaMail funciona!");
        
        Transport.send (msg);
        
        System.out.println ("E-mail enviado com sucesso.");
    }
}