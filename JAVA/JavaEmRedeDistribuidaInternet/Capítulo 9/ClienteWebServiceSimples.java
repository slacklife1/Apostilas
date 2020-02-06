/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 9.3
*
*/

import org.apache.axis.client.Service;
import org.apache.axis.client.Call;

public class ClienteWebServiceSimples
{
     public static void main(String[] args)
     {
       try
       {
        String endereco = "http://www.java.com.br:8080/axis/Quadrado.jws";

         Call call = (Call) new Service().createCall();
         call.setTargetEndpointAddress(endereco);
         call.setOperationName("quadrado");

         Object[] paramametros = new Object[]{new Integer(5)};
         Integer resultado = (Integer)call.invoke(paramametros);

         System.out.println("O número 5 ao quadrado é: " + resultado);
       }
       catch (Exception exc)
       {
        exc.printStackTrace();
       }
    }
}
