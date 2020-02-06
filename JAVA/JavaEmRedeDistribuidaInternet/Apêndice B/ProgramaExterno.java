/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo B.1
*
*/

public class ProgramaExterno
{
  static public void main (String rede[])
  {
    try
    {
      Runtime run = Runtime.getRuntime();
      run.exec("notepad");
    }
    catch (java.io.IOException exc)
    {
      System.err.println ("Erro de entrada/saída: " + exc.toString());
    }
  }
}