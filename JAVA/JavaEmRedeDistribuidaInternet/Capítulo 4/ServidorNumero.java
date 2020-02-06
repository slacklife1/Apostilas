/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 4.6
*
*/

import java.net.*;
import java.io.*;

public class ServidorNumero
{
    public static void main (String numero[])
    {
        int porta = 12258;
        
        try
        {
            ServerSocket servidor = new ServerSocket (porta, 2);
            Socket conexao = servidor.accept();
            DataOutputStream saida = new DataOutputStream (conexao.getOutputStream());
            SocketAddress s = conexao.getRemoteSocketAddress();            
            System.out.println ("Enviando número ao cliente: " + s.toString());
            saida.writeInt(12);
	          conexao.close();            
        }
        catch (Exception exc)
        {
          System.out.println (exc.toString());
        }  
    }
}
