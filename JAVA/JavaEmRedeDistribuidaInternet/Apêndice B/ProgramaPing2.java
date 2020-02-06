/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo B.3
*
*/

import java.io.*;

public class ProgramaPing2
{
  static public void main (String rede[])
  {
    try
    {
      BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
      System.out.print ("Digite o endereço a ser verificado: ");
      String endereco = teclado.readLine();

      Process processo = Runtime.getRuntime().exec("ping " + endereco);
      InputStream in = processo.getInputStream();
      BufferedReader entrada = new BufferedReader(new InputStreamReader(in));
      String linha = null;

      while ((linha = entrada.readLine()) != null)
      {
            System.out.println(linha);
      }

      processo.destroy();

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