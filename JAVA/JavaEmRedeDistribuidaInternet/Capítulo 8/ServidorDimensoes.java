/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 8.9
*
*/

import java.net.*;
import java.io.*;

public class ServidorDimensoes
{
    public static void main (String app[])
    {
        int porta = 6565;

        try
        {
            ServerSocket servidor = new ServerSocket (porta);
            while (true)
            {
                Socket conexao = servidor.accept();
                DataOutputStream saida = new DataOutputStream (conexao.getOutputStream());

                int numero = (int)(Math.random()*400);
                saida.writeInt (numero);
                saida.flush();
                conexao.close();
            }
        }
        catch (Exception exc)
        {
          System.err.println (exc.toString());
        }
    }

}
