/*
* Java em Rede: Recursos Avan�ados de Programa��o
*
* Daniel G. Costa
*
* Exemplo A.6
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
            System.out.print ("Digite o endere�o a ser verificado: ");
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
            System.err.println ("Erro de entrada/sa�da");
        }
        catch (Exception exc)
        {
            System.err.println ("Erro geral: " + exc.toString());
        }
    }
}