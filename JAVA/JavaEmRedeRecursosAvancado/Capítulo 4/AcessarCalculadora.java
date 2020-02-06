/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 4.4
*
*/


import org.apache.axis.client.*;
import javax.xml.rpc.ServiceException;
import java.rmi.RemoteException;

public class AcessarCalculadora
{

    public static void main(String[] args) throws ServiceException, RemoteException
    {
        String url = "http://www.java.br:8080/axis/Calculadora.jws";
        Service service = new Service();
        Call call = (Call) service.createCall();
        call.setTargetEndpointAddress(url);

	Object[] parametros;
        parametros = new Object[2];
        parametros[0] = new Double (10);
        parametros [1] = new Double (4);

	call.setOperationName("somar");
        Double resultado = (Double) call.invoke(parametros);
        System.out.println("Resultado da soma: " + resultado);

	call.setOperationName("subtrair");
        resultado = (Double) call.invoke(parametros);
        System.out.println("Resultado da subtração: " + resultado);

	call.setOperationName("multiplicar");
        resultado = (Double) call.invoke(parametros);
        System.out.println("Resultado da multiplicação: " + resultado);

	call.setOperationName("dividir");
        resultado = (Double) call.invoke(parametros);
        System.out.println("Resultado da divisão: " + resultado);

	call.setOperationName("quadrado");
        parametros = new Object[1];
        parametros [0] = new Double (9);
        resultado = (Double) call.invoke(parametros);
        System.out.println("Número 9.0 ao quadrado: " + resultado);
    }
}
