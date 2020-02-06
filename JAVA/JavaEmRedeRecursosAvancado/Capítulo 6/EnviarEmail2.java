/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 6.3
*
*/


import javax.mail.*;
import javax.mail.internet.*;
import javax.swing.JOptionPane;
import java.net.InetAddress;
import java.util.Properties;

public class EnviarEmail2
{

    public static void main(String args[])
    {
        String origem = "danielgouveiacosta@yahoo.com";
      
        try
        {
	    //Recuperando o endereço IP local
            InetAddress endereco = InetAddress.getLocalHost();
            String ipLocal = endereco.getHostAddress();
            String nomeLocal = endereco.getHostName();
    
            String servidorSMTP = JOptionPane.showInputDialog("Servidor SMTP");
            String destino = JOptionPane.showInputDialog("E-mail de destino");        
      
            Properties prop = new Properties();
            prop.put("mail.smtp.host", servidorSMTP);
               
            Session session = Session.getInstance(prop, null);
            MimeMessage msg = new MimeMessage(session);
        
            msg.setFrom(new InternetAddress (origem));
            msg.setRecipient(Message.RecipientType.TO, new InternetAddress(destino));
            
            msg.setSentDate(new java.util.Date());
            
            msg.setSubject("Informações");
            msg.setText ("Endereco IP: " + ipLocal + " - Nome do host: " + nomeLocal);
            
            Transport.send (msg);
        
            System.out.println ("E-mail enviado com sucesso.");
        }
        catch (Exception exc)
        {
            System.out.println(exc.getMessage());
        }
    }
}