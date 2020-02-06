/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 4.7
*
*/


import org.apache.axis.client.*;
import javax.xml.rpc.ServiceException;
import java.rmi.RemoteException;

public class AcessarDataHoraWS 
{

    public static void main(String[] args) throws ServiceException, RemoteException
    {
    	String url = "http://www.java.br:8080/axis/DataHoraWS.jws";
        Service service = new Service();
        Call call = (Call) service.createCall();
        call.setTargetEndpointAddress(url);

	Object[] parametros;
        parametros = new Object[0];

	call.setOperationName("lerDataHora");
        String resultado = (String) call.invoke(parametros);
        System.out.println("Data e hora: " + resultado);
    }
}
