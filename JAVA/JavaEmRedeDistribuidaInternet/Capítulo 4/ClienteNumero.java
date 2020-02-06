/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 4.7
*
*/

import java.net.*;
import java.io.*;

public class ClienteNumero
{
    public static void main (String numero[])
    {
        String endereco = "201.25.196.84";
        int porta = 12258;
        
        try
        {
            Socket conexao = new Socket (endereco, porta);
            DataInputStream entrada = new DataInputStream (conexao.getInputStream());
            System.out.println ("Número recebido: " + entrada.readInt()); 
	          conexao.close();           
        }
        catch (Exception exc)
        {
            System.out.println (exc.toString());           
        }
   }
                
}
