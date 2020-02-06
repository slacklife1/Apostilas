/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 5.1
*
*/


import java.net.*;
import java.io.*;

public class ServidorString
{

    static public void main (String entrada [])
    {
        try
        {
	    int porta = 5678;
            System.out.println ("Servidor iniciado na porta " + porta + "...\n");
	
            ServerSocket servidor = new ServerSocket (porta);

            Socket conexao = servidor.accept();

            DataInputStream in = new DataInputStream (conexao.getInputStream());
            String mensagemCliente = in.readUTF();
            System.out.println ("Usuario e senha recebidos do cliente: " + mensagemCliente);

            DataOutputStream out = new DataOutputStream (conexao.getOutputStream());
            out.writeUTF ("Recebi os dados.");

	    conexao.close();
        }
        catch (Exception exc)
        {
            System.err.println (exc.toString());
        }
    }
}
