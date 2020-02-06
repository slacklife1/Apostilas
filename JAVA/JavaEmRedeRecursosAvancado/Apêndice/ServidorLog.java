/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo A.1
*
*/


import java.net.*;
import java.io.*;

public class ServidorLog
{
    public static void main (String args[])
    {
        int porta = 9988;

        try
        {
            ServerSocket servidor = new ServerSocket (porta);
            Socket conexao = servidor.accept();
            DataOutputStream saida = new DataOutputStream (conexao.getOutputStream());

            while (true)
            {
                int numero = ((int)(Math.random()*1000));
                saida.writeInt (numero);
                saida.flush();
                Thread.sleep (500);
            }
        }
        catch (Exception exc)
        {
          System.out.println (exc.toString());
        }
    }
}