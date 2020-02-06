/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 6.2
*
*/

import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.rmi.Naming;
import java.util.Date;

public class ServidorRMIString extends UnicastRemoteObject implements InterfaceRMIString
{
  public ServidorRMIString() throws RemoteException
  {
    super ();
  }
  static public void main (String rmi[])
  {
    try
    {
      ServidorRMIString objetoServidor = new ServidorRMIString();
      String localizacao = "//201.25.41.159/data";
      Naming.rebind (localizacao, objetoServidor);      
    }
    catch (Exception exc)
    {
      System.err.println (exc.toString());
    }    
  }
  
  public String getData()
  {
    String data = new Date().toString();
    return data;
  }


}