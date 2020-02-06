/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo A.4
*
*/

import java.net.*;
import java.io.*;
import java.util.logging.*;

public class ClienteLog2
{
    public static void main (String args[])
    {

        //Endereço IP e porta do servidor
        String endereco = "201.25.48.239";
        int porta = 9988;

        try
        {
            Logger logger = Logger.getAnonymousLogger();
            FileHandler arquivo = new FileHandler ("logCliente2.txt");
            arquivo.setFormatter(new SimpleFormatter());
            logger.addHandler (arquivo);

            Socket conexao = new Socket (endereco, porta);
            DataInputStream entrada = new DataInputStream (conexao.getInputStream());
            for (int i=0; i < 10; i++)
            {
                int numero = (int) entrada.readInt();
                System.out.println (numero + "\n");
                logger.info ("Número recebido: " + numero);
                Thread.sleep (500);
            }
        }
        catch (Exception exc)
        {
           System.out.println (exc.toString());
        }
   }
}
