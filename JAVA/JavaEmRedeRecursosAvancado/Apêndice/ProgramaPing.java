/*
* Java em Rede: Recursos Avan�ados de Programa��o
*
* Daniel G. Costa
*
* Exemplo A.5
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
            System.err.println ("Erro de entrada/sa�da");
        }
        catch (Exception exc)
        {
            System.err.println ("Erro geral: " + exc.toString());
        }
    }
}