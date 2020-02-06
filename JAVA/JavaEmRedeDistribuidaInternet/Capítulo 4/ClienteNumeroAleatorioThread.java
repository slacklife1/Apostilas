/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 4.13
*
*/

import java.net.*;
import java.io.*;
import java.text.DecimalFormat;

public class ClienteNumeroAleatorioThread
{
    public static void main (String numero[])
    {

        String endereco = "201.98.158.67";
        int porta = 36598;

        try
        {
            Socket conexao = new Socket (endereco, porta);
            DataInputStream entrada = new DataInputStream (conexao.getInputStream());

            DecimalFormat formatador = new DecimalFormat ("0.000");                

            while (true)
            {
                System.out.print (formatador.format(entrada.readDouble()) + " - ");
                Thread.sleep (1000);
            }

        }
        catch (Exception exc)
        {
           System.out.println (exc.toString());
        }

   }
                
}