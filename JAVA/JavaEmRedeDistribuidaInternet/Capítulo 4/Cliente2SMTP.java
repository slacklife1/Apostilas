/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 4.4
*
*/

import java.io.*;
import java.net.*;

public class Cliente2SMTP
{

    public static void main(String[] args)
    {
        Socket conexao = null;
        DataOutputStream saida = null;
        DataInputStream entrada = null;
        String end = "www.gmail.com";
        try
        {
            InetAddress endereco = InetAddress.getByName(end);
            conexao = new Socket(endereco, 25);
            saida = new DataOutputStream(conexao.getOutputStream());
            entrada = new DataInputStream (conexao.getInputStream());

        }
        catch (UnknownHostException un)
        {
            System.out.println("Endereço desconhecido.");
            System.exit (0);
        }
        catch (IOException exc)
        {
            System.out.println("Problemas na abertura dos streams.");
            System.exit (0);
        }


        try
        {
            saida.writeBytes("HELO Daniel\n");
            System.out.println("Resposta do servidor: " + entrada.readLine());

            saida.writeBytes("MAIL FROM: daniel@gmail.com\n");
            System.out.println("Resposta do servidor: " + entrada.readLine());

            saida.writeBytes("RCPT TO: gouveia@gmail.com\n");
            System.out.println("Resposta do servidor: " + entrada.readLine());

            saida.writeBytes("DATA\n");
            System.out.println("Resposta do servidor: " + entrada.readLine());

            saida.writeBytes("Subject: Mensagem importante\n");
            saida.writeBytes("FROM: daniel\n");
            saida.writeBytes("TO: gouveia\n");
            saida.writeBytes("\nBom dia! Aqui está tudo bem.!!!");
            saida.writeBytes("\r\n.\r\n");
            System.out.println("Resposta do servidor: " + entrada.readLine());

            saida.close();
            entrada.close();
            conexao.close();

        }
        catch (UnknownHostException un)
        {
                System.out.println(un.getMessage());
        }
        catch (IOException exc)
        {
                System.out.println(exc.getMessage());
        }
    }
}