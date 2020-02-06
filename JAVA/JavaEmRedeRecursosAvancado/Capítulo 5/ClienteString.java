/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 5.2
*
*/


import java.net.*;
import java.io.*;

public class ClienteString 
{

    public static void main (String args[])
    {
        try
        {
            int porta = 5678;
            String endereco = "www.java.br";
        
            Socket conexao = new Socket (endereco, porta);
            DataOutputStream out = new DataOutputStream (conexao.getOutputStream());
            out.writeUTF ("Usuario: root, senha: AsD587");
                        
            DataInputStream in = new DataInputStream (conexao.getInputStream());
            String retorno = in.readUTF();
            System.out.println ("Resposta do servidor: " + retorno);

	    conexao.close();          
           
        }
        catch (Exception exc)
        {
            System.err.println (exc.getMessage());
        }
    }
}
