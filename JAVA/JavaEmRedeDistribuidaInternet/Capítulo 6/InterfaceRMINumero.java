/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 6.4
*
*/

import java.rmi.Remote;
import java.rmi.RemoteException;

public interface InterfaceRMINumero extends Remote
{
  public int quadrado(int num) throws RemoteException;
  public int cubo(int num) throws RemoteException;
}
