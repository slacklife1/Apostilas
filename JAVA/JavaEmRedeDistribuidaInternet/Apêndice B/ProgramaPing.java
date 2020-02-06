/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo B.2
*
*/

import java.io.*;

public class ProgramaPing
{
  static public void main (String rede[])
  {
    try
    {
      BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
      System.out.print ("Digite o endere�o a ser verificado: ");
      String endereco = teclado.readLine();

      Process processo = Runtime.getRuntime().exec("ping " + endereco);
      
      int retorno = processo.waitFor();
      if (retorno == 0)
        System.out.println("O host " + endereco + " est� acess�vel");
      else
        System.out.println("O host " + endereco + " n�o est� acess�vel");

    }
    catch (IOException exc)
    {
      System.err.println ("Erro de E/S");
    }
    catch (Exception exc)
    {
      System.err.println ("Erro geral: " + exc.toString());
    }
  }
}
