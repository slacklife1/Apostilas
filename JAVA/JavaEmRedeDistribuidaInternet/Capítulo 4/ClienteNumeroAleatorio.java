/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 4.11
*
*/

import java.net.*;
import java.io.*;

public class ClienteNumeroAleatorio
{
    public static void main (String numero[])
    {
        String endereco = "176.54.206.79";
        int porta = 26147;
        
        try
        {
            Socket conexao = new Socket (endereco, porta);
            ObjectInputStream entrada = new ObjectInputStream (conexao.getInputStream());
            while (true)
            {
                Numero num = (Numero) entrada.readObject();
                System.out.print (num.retornarNumero() + " - ");
                Thread.sleep (1000);
            }
	 
        }
        catch (Exception exc)
        {
           System.out.println (exc.toString());
        }
   }
}

