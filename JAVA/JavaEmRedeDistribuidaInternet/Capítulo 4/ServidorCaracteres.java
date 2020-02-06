/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 4.8
*
*/

import java.net.*;
import java.io.*;

public class ServidorCaracteres
{
    public static void main (String numero[])
    {
        int porta = 21532;
        int contador = 0;

        try
        {
            ServerSocket servidor = new ServerSocket (porta);
            while (true)
            {                
                Socket conexao = servidor.accept();
                DataOutputStream saida = new DataOutputStream (conexao.getOutputStream());                
                if (contador % 4 == 0)
                {
                  System.out.println ("Enviando caractere \"J\" ao cliente.");
                  saida.writeChar('J');
                }
                else if (contador % 4 == 1)
                {
                  System.out.println ("Enviando caractere \"A\" ao cliente.");
                  saida.writeChar('A');
                }
                else if (contador % 4 == 2)
                {
                   System.out.println ("Enviando caractere \"V\" ao cliente.");
                   saida.writeChar('V');
                }
                else
                {
                    System.out.println ("Enviando caractere \"A\" ao cliente.");
                    saida.writeChar('A');
                }
                ++contador;
                conexao.close();
            }
        }
        catch (Exception exc)
        {
          System.out.println (exc.toString());
        }  
    }
}