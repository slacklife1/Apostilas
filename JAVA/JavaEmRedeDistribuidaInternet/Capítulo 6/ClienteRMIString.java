/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 6.3
*
*/

import java.rmi.Remote;
import java.rmi.RemoteException;
import java.rmi.Naming;

public class ClienteRMIString
{
  static public void main (String rmi[])
  {
    try
    {
      String localizacao = "//201.25.41.159/data";
      InterfaceRMIString objeto = (InterfaceRMIString) Naming.lookup(localizacao);
      System.out.println ("A data atual no servidor é: " + objeto.getData());
    }
    catch (Exception exc)
    {
      System.err.println (exc.toString());
    }      
  }
}