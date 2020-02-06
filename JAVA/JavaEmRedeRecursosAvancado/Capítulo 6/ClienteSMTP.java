/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 6.1
*
*/


import java.io.*;
import java.net.*;

public class ClienteSMTP
{

    public static void main(String[] args)
    {
        Socket conexao = null;
        DataOutputStream saida = null;
        BufferedReader entrada = null;

        String servidorSMTP = "hotmail.com";

        try
        {
            conexao = new Socket(servidorSMTP, 25);
        
 	    saida = new DataOutputStream(conexao.getOutputStream());
            entrada = new BufferedReader (new InputStreamReader (conexao.getInputStream()));
        
            saida.writeBytes("HELO daniel.com\n");
            System.out.println("Resposta do servidor: " + entrada.readLine());
            
            saida.writeBytes("MAIL FROM: daniel@yahoo.com\n");
            System.out.println("Resposta do servidor: " + entrada.readLine());

            saida.writeBytes("RCPT TO: newton@gmail.com\n");
            System.out.println("Resposta do servidor: " + entrada.readLine());
            
            saida.writeBytes("DATA\n");
            System.out.println("Resposta do servidor: " + entrada.readLine());
            
            saida.writeBytes("Subject: Última mensagem\n");
            saida.writeBytes("FROM: Daniel G. Costa\n");
            saida.writeBytes("TO: Isaac Newton\n");
            saida.writeBytes("MIME-Version: 1.0");
            saida.writeBytes("Content-Type: text/plain;\n");
            saida.writeBytes("\nEstou aprendendo java em rede!!!");
            saida.writeBytes("\r\n.\r\n");
            System.out.println("Resposta do servidor: " + entrada.readLine());

            saida.close();
            entrada.close();
            conexao.close();
        }
        catch (UnknownHostException exc)
        {
                System.out.println("Endereço desconhecido: " + exc.getMessage());
        }
        catch (Exception exc)
        {
                System.out.println(exc.toString());
        }
    }
}