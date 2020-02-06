/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 6.8
*
*/

import java.rmi.Remote;
import java.rmi.RemoteException;
import java.rmi.Naming;

public class ClienteRMIPessoa
{
  static public void main (String rmi[])
  {
    try
    {
      String localizacao = "//200.125.64.53/pessoa";
      InterfaceRMIPessoa objeto = (InterfaceRMIPessoa) Naming.lookup(localizacao);

      while (true)
      {
        Pessoa pessoa = (Pessoa)objeto.retornarPessoa();
        System.out.println ("Nome da pessoa: " + pessoa.getNome());
        System.out.println ("Idade: " + pessoa.getIdade() + "\n");
        Thread.sleep (4000);
      }
    }
    catch (Exception exc)
    {
      System.err.println (exc.toString());
    }      
  }
}