/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 8.16
*
*/

import java.net.*;
import java.io.*;

public class LeitorURL
{
  public static void main(String args[])
  {
    try
    {
      URL url = new URL("http://www.brasport.com.br");
      BufferedReader entrada = new BufferedReader(new InputStreamReader(url.openStream()));

      String recebido;
      while ((recebido = entrada.readLine()) != null)
      {
        System.out.println(recebido);
      }
      entrada.close();

    }
    catch (Exception exc)
    {
      System.out.println(exc.toString());
    }
  }
}
