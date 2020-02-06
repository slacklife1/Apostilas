/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 4.12
*
*/

import java.net.*;
import java.io.*;

public class ServidorNumeroAleatorioThread
{
    public static void main (String numero[])
    {
        int porta = 36598;
        
        try
        {
            ServerSocket servidor = new ServerSocket (porta);
            while (true)
            {
                Socket conexao = servidor.accept();
                System.out.println ("Porta do cliente: " + conexao.getPort());
                System.out.println ("Porta do servidor: " + conexao.getLocalPort());
                new ThreadConexao(conexao).start();
            }              
        }
        catch (Exception exc)
        {
          System.out.println (exc.toString());
        }  
    }
}

class ThreadConexao extends Thread
{
    Socket conexao;
    DataOutputStream saida;
    
    public ThreadConexao(Socket s) throws IOException
    {
        conexao = s;
        saida = new DataOutputStream (conexao.getOutputStream());
    }
    public void run()
    {
        try
        {
            while (true)
            {
                if (conexao.isConnected())
                {
                  saida.writeDouble(Math.random()*100);
                  saida.flush();
                  Thread.sleep (1000);
                }
                else
                {
                   break;
                }
            }
        }
        catch (Exception exc)
        {
          System.out.println (exc.toString());
        }  
    }
}

