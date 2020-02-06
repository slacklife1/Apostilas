/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 2.3
*
*/


import java.net.*;
import java.io.*;

public class ClienteTCPNumero
{

    public static void main (String numero[])
    {
        String enderecoServidor = "201.25.196.84";
        int portaServidor = 12258;
        
        try
        {
            Socket conexao = new Socket (enderecoServidor, portaServidor);
            
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