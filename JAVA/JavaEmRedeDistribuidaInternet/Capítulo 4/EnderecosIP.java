/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 4.1
*
*/

import java.net.*;

class EnderecosIP
{
  public static void main (String args[])
  {
    byte endereco1[] = new byte[4];
    endereco1[0]=-56;
    endereco1[1]=-108;
    endereco1[2]= 23;
    endereco1[3]= 12;
    
    try
    {
        System.out.print ("Enderešo 1: ");
        for (int num=0; num < endereco1.length; num++)
        {            
            if (num == 3)
                System.out.print (endereco1[num]);
            else
                System.out.print (endereco1[num] + ".");
        }
        
        InetAddress endereco2 = InetAddress.getByAddress(endereco1);
        System.out.print ("\nEnderešo 2: " + endereco2.getHostAddress());

        InetAddress endereco3 = InetAddress.getByName("www.brasport.com.br");
        System.out.println ("\nEnderešo 3: " + endereco3.getHostAddress());       
        System.out.print ("Nome DNS do enderešo 3: " + endereco3.getHostName ());       
                    
        endereco1 = endereco3.getAddress();        
        
    }
    catch (UnknownHostException exc)
    {
        System.err.println (exc.getMessage());
    }
  }
}