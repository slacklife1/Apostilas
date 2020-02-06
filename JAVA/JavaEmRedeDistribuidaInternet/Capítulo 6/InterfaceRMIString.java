/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 6.1
*
*/

import java.rmi.Remote;
import java.rmi.RemoteException;

public interface InterfaceRMIString extends Remote
{
  public String getData() throws RemoteException;
}
