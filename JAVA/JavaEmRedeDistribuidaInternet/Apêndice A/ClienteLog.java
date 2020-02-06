/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo A.3
*
*/

import java.net.*;
import java.io.*;
import java.util.*;

public class ClienteLog
{
    public static void main (String args[])
    {
    
        //Endereço IP e porta do servidor
        String endereco = "201.25.48.239";
        int porta = 9988;

        try
        {
            BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
            System.out.print ("Digite o nome do arquivo de log: ");
            String arquivo = teclado.readLine();

            BufferedWriter saida = new BufferedWriter(new FileWriter(arquivo,false));
            saida.write("Log do cliente");
            saida.newLine();

            Socket conexao = new Socket (endereco, porta);
            DataInputStream entrada = new DataInputStream (conexao.getInputStream());
            for (int i=0; i < 10; i++)
            {
                int numero = (int) entrada.readInt();
                System.out.print (numero + " - ");
                Date data = new Date();
                String hora = data.getHours() + ":" + data.getMinutes() + ":" + data.getSeconds();
                saida.write(hora);
                saida.newLine();
                saida.write("Recebido: " + numero);
                saida.newLine();
                saida.newLine();
                Thread.sleep (500);
            }
            saida.close();

        }
        catch (Exception exc)
        {
           System.out.println (exc.toString());
        }
   }
}

