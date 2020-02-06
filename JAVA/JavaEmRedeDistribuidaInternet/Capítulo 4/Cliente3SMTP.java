/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 4.5
*
*/

import java.io.*;
import java.net.*;

public class Cliente3SMTP
{

    public static void main(String[] args)
    {
        Socket conexao = null;
        DataOutputStream saida = null;
        BufferedReader entrada = null;
        String endereco = "www.yahoo.com";
        try
        {
            conexao = new Socket(endereco, 25);
            saida = new DataOutputStream(conexao.getOutputStream());
            entrada = new BufferedReader (new InputStreamReader (conexao.getInputStream()));

        }
        catch (UnknownHostException un)
        {
            System.out.println("Endereço desconhecido: " + un.getMessage());
            System.exit (0);
        }
        catch (IOException exc)
        {
            System.out.println("Problemas com os streams: " + exc.getMessage());
            System.exit (0);
        }


        try
        {
            saida.writeBytes("HELO chico\n");
            System.out.println("Resposta do servidor: " + entrada.readLine());
            
            saida.writeBytes("MAIL FROM: daniel@yahoo.com\n");
            System.out.println("Resposta do servidor: " + entrada.readLine());

            saida.writeBytes("RCPT TO: gouveia@yahoo.com\n");
            System.out.println("Resposta do servidor: " + entrada.readLine());
            
            saida.writeBytes("DATA\n");
            System.out.println("Resposta do servidor: " + entrada.readLine());
            
            saida.writeBytes("Subject: Última mensagem\n");
            saida.writeBytes("FROM: Daniel\n");
            saida.writeBytes("TO: Gouveia\n");
            saida.writeBytes("MIME-Version: 1.0");
            saida.writeBytes("Content-Type: text/plain;\n");            
            saida.writeBytes("\nEstou saindo. Tchau!!!");
            saida.writeBytes("\r\n.\r\n");            
            System.out.println("Resposta do servidor: " + entrada.readLine());

            saida.close();
            entrada.close();
            conexao.close();

        }
        catch (UnknownHostException un)
        {
                System.out.println(un.toString());
        }
        catch (IOException exc)
        {
                System.out.println(exc.toString());
        }
    }
}