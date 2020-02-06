/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 1.31
*
*/


public class TesteThread
{
    static public void main (String parametros[])
    {
        new MinhaThread().start();
        MinhaThread teste = new MinhaThread("Thread de exemplo");
        teste.start();
        System.out.println ("Final da Thread main");
    }
}

class MinhaThread extends Thread
{
    public MinhaThread (String texto)
    {
        super (texto);
    }
    public MinhaThread ()
    {
    }
    public void run ()
    {
        System.out.println ("Thread sendo chamada: " + this.getName());
    }
}