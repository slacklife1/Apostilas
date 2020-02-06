/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 4.9
*
*/

import java.net.Socket;
import java.io.DataInputStream;

public class ClienteCaracteres
{
    public static void main (String numero[])
    {
        String endereco = "200.98.132.54";
        int porta = 21532;

        try
        {
            Socket conexao = new Socket (endereco, porta);
            DataInputStream entrada = new DataInputStream (conexao.getInputStream());
            System.out.println ("Caractere: " + entrada.readChar());
	          conexao.close();
        }
        catch (Exception exc)
        {
            System.out.println (exc.toString());
        }           

   }

}