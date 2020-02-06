/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 6.4
*
*/


import javax.mail.*;
import javax.mail.internet.*;
import java.util.Properties;
import javax.activation.*;

public class EnviarEmailAnexo
{
    public static void main (String args[])
    {
        try
        {
            String servidor = "servidor.com.br";
            String destino = "danielgcosta@gmail.com";
            String origem = "einstein@yahoo.com";
	    String arquivo = "contas.txt";
        
            Properties props = new Properties();
            props.put("mail.smtp.host", servidor);

            Session s = Session.getInstance(props,null);
            
            Message mensagem = new MimeMessage(s);
            InternetAddress endOrigem = new InternetAddress(origem);
            mensagem.setFrom(endOrigem);

            InternetAddress endDestino = new InternetAddress(destino); 
            mensagem.addRecipient(Message.RecipientType.TO, endDestino);
        
            mensagem.setSubject("Mensagem com anexo");
            
            Multipart mensagemPartes = new MimeMultipart();
                
            MimeBodyPart parteTextual = new MimeBodyPart();
            parteTextual.setText("Essa é a parte textual da mensagem.");

            mensagemPartes.addBodyPart(parteTextual);
            
            MimeBodyPart parteAnexo = new MimeBodyPart();
            DataSource source = new FileDataSource(arquivo);
            parteAnexo.setDataHandler(new DataHandler(source));
            parteAnexo.setFileName(arquivo);

            mensagemPartes.addBodyPart(parteAnexo);
            
            mensagem.setContent(mensagemPartes);
  
            Transport.send(mensagem);
        
            System.out.println ("E-mail com anexo enviado com sucesso.");
        }
        catch (Exception exc)
        {
            System.out.println(exc.toString());
        }
    }    
}
