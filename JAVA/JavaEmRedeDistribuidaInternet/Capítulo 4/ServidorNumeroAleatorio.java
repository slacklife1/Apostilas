/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 4.10
*
*/

import java.net.*;
import java.io.*;

public class ServidorNumeroAleatorio
{
    public static void main (String numero[])
    {
        int porta = 26147;
        
        try
        {
            ServerSocket servidor = new ServerSocket (porta);
            Socket conexao = servidor.accept();
            ObjectOutputStream saida = new ObjectOutputStream (conexao.getOutputStream());
            
            while (true)
            {
                Numero num = new Numero((int)(Math.random()*100));
                saida.writeObject (num);
                saida.flush();
                Thread.sleep (1000);
            }
        }
        catch (Exception exc)
        {
          System.out.println (exc.toString());
        }  
    }
}

class Numero implements Serializable
{
  private int numero;
  public Numero (int num)
  {
    numero = num;
  }
  public int retornarNumero()
  {
    return numero;
  }
}
