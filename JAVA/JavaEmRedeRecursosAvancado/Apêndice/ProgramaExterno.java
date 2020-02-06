/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo A.4
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