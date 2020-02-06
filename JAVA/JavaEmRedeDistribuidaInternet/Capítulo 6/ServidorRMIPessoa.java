/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 6.7
*
*/
    
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.rmi.*;

interface InterfaceRMIPessoa extends Remote
{
  public Pessoa retornarPessoa() throws RemoteException;
}

public class ServidorRMIPessoa extends UnicastRemoteObject implements InterfaceRMIPessoa
{  
  static public Pessoa pessoa=null;

  public ServidorRMIPessoa () throws RemoteException
  {
    super ();
  }

  static public void main (String rmi[])
  {
    try
    {
      new GerarPessoa().start();

      ServidorRMIPessoa servidor = new ServidorRMIPessoa();
      String localizacao = "//200.125.64.53/pessoa";
      Naming.rebind (localizacao, servidor);      
    }
    catch (Exception exc)
    {
      System.err.println (exc.getMessage());
    }    
  }
  
  public Pessoa retornarPessoa()
  {
    return pessoa;
  }
}

class Pessoa implements java.io.Serializable
{
    private String nome;
    private int idade;
    public Pessoa (String n, int i)
    {
        nome = n;
        idade = i;
    }
    public int getIdade()
    {
      return idade;
    }
    public String getNome()
    {
      return nome;
    }
}

class GerarPessoa extends Thread
{
  int cont=0;
  public void run()
  {
    try
    {
      for (;;)
      {
        sleep (2000);
        String nome = null;
        if ((cont % 4) == 0)
          nome = "Daniel";
        else if ((cont % 4) == 1)
          nome = "Henrique";
        else if ((cont % 4) == 2)
          nome = "Pedro";
        else if ((cont % 4) == 3)
          nome = "João";

        int idade = (int)(Math.random()*80 + 1);
        ServidorRMIPessoa.pessoa = new Pessoa (nome, idade);
        cont++;
      }
    }
    catch (Exception exc)
    {
      System.err.println ("Exceção gerada na geração dos objetos Pessoa");
    }
  }
}




