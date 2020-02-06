/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 4.3
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
        DataInputStream entrada = null;
        String endereco = "www.gmail.com";
        try
        {
            conexao = new Socket(endereco, 25);
            saida = new DataOutputStream(conexao.getOutputStream());
            entrada = new DataInputStream(conexao.getInputStream());

            saida.writeBytes("HELO Daniel\n");
            entrada.readLine();

            saida.writeBytes("MAIL FROM: daniel@gmail.com\n");
            entrada.readLine();

            saida.writeBytes("RCPT TO: gouveia@gmail.com\n");
            entrada.readLine();

            saida.writeBytes("DATA\n");
            entrada.readLine();

            saida.writeBytes("Subject: Testando...\n");
            saida.writeBytes("FROM: daniel\n");
            saida.writeBytes("TO: gouveia\n");
            saida.writeBytes("\nBom dia! Tchau.!!!");
            saida.writeBytes("\r\n.\r\n");
            entrada.readLine();

            saida.close();
            entrada.close();
            conexao.close();    

        }
        catch (UnknownHostException e)
        {
                System.out.println("Trying to connect to unknown host: " + e);
        }
        catch (Exception e)
        {
                System.out.println("IOException:  " + e.getMessage());
        }

    }
}