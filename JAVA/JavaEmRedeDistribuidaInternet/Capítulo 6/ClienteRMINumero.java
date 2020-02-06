/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 6.6
*
*/

import java.rmi.Remote;
import java.rmi.RemoteException;
import java.rmi.Naming;

public class ClienteRMINumero
{
  static public void main (String rmi[])
  {
    try
    {
      String localizacao = "//200.14.57.32/numero";
      InterfaceRMINumero objeto = (InterfaceRMINumero) Naming.lookup(localizacao);
      System.out.println ("8 ao quadrado é: " + objeto.quadrado(8));
      System.out.println ("8 ao cubo é: " + objeto.cubo(8));
    }
    catch (Exception exc)
    {
      System.err.println (exc.toString());
    }
  }
}