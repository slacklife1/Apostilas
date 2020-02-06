/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo B.4
*
*/

import java.io.*;
import javax.swing.JOptionPane;

public class ProgramaPing3
{
  static public void main (String rede[])
  {
    try
    {
      String endereco = JOptionPane.showInputDialog (null, "Digite o endereço do host a ser verificado.");

      String arquivo = "comandoPing.txt";

      BufferedWriter saida = new BufferedWriter(new FileWriter(arquivo,false));
      saida.write("Resultado do comando ping");
      saida.newLine();

      Process processo = Runtime.getRuntime().exec("ping " + endereco);
      InputStream in = processo.getInputStream();
      BufferedReader entrada = new BufferedReader(new InputStreamReader(in));
      String linha = null;

      while ((linha = entrada.readLine()) != null)
      {
            saida.write (linha);
            saida.newLine();
      }
      System.out.println ("Programa encerrado.");
      System.out.println ("Resultado gravado em " + arquivo);
      saida.close();
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