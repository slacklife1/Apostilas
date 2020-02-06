/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 4.2
*
*/


import org.apache.axis.client.Call;
import org.apache.axis.client.Service;

public class AcessarPrimeiroWS
{

    public static void main(String entrada[])
    {
        try
 	{
 	    String url = "http://www.java.br:8080/axis/PrimeiroWS.jws";
 	    Service service = new Service();
	    Call call = (Call) service.createCall();

	    call.setTargetEndpointAddress(url);
	    call.setOperationName("getMensagem");

	    String resultado = (String) call.invoke(new Object [0]);
 	    System.out.println("Informação recuperada: " + resultado);
 	}
 	catch(Exception exc)
 	{
 	    System.err.println (exc.toString());
	}
    }
}
