/*
* Java em Rede: Recursos Avançados de Programação
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
            System.out.print ("Digite o endereço a ser verificado: ");
            String endereco = teclado.readLine();

            Process processo = Runtime.getRuntime().exec("ping " + endereco);
      
            int retorno = processo.waitFor();
            if (retorno == 0)
                System.out.println("O host " + endereco + " está acessível");
            else
                System.out.println("O host " + endereco + " não está acessível");

        }
        catch (IOException exc)
        {
            System.err.println ("Erro de entrada/saída");
        }
        catch (Exception exc)
        {
            System.err.println ("Erro geral: " + exc.toString());
        }
    }
}