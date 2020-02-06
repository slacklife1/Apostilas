/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 4.5
*
*/


import java.net.*;
import java.io.*;

public class ProgramaServidor
{

    public static void main (String entrada[])
    {

        int porta = 6666;

	try
        {
            ServerSocket servidor = new ServerSocket (porta);

	    for (;;)
            {
                Socket conexao = servidor.accept();
                new ThreadData (conexao).start();
            } 
        }
        catch (Exception exc)
	{
	    System.err.println (exc.toString());
	}
    }
}

class ThreadConexao extends Thread
{
    Socket conexao;
    ObjectOutputStream saida;

    public ThreadData (Socket con)
    {
        conexao = con;
    }
    public void run ()
    {
        try
        {
            saida = new ObjectOutputStream (conexao.getOutputStream());
                       
	    while (true)
            {
                if (conexao.isConnected())
                {
                    saida.writeObject (new java.util.Date());
                    Thread.sleep (1000);                           
                }
                else
                    break;           
            }
        }
        catch (Exception exc)
	{
	    System.err.println (exc.toString());
	}
    }
}
