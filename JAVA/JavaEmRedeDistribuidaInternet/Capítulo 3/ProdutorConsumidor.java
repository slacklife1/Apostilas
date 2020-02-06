/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 3.4
*
*/


public class ProdutorConsumidor
{
    public static void main (String args[])
    {
        Recipiente rec = new Recipiente();
        Produtor p = new Produtor (rec);
        Consumidor c = new Consumidor (rec);
        
        p.start();
        c.start();
    }
}

class Recipiente
{

    int valor;

    public Recipiente()
    {
        valor = 0;
    }
    public void escreverValor (int v)
    {
        valor = v;
        System.out.println ("Recipiente recebeu o valor " + v);
    }
    public int lerValor()
    {
        System.out.println ("O valor " + valor + " foi lido do recipiente");
        return valor;
    }
}

class Produtor extends Thread
{
    
    int cont = 0, soma = 0;
    Recipiente rec;
    
    public Produtor(Recipiente c)
    {
        rec = c;
    }
    public void run()
    {
        //Produzir valores de 1 a 15
        for (int v = 1; v <= 15; v++)
        {
            try
            {
              Thread.sleep ((int)(Math.random()*4000));
            }
            catch(Exception excecao)
            {
              System.err.println ("Exce��o encontrada: " + excecao.getMessage());
            }
            
            rec.escreverValor(v);
        }
  }
}

class Consumidor extends Thread
{

    int cont = 0, soma = 0;
    Recipiente rec;

    public Consumidor(Recipiente c)
    {
        rec = c;
    }
    public void run()
    {
        do
        {
            try
            {
              Thread.sleep ((int)(Math.random()*4000));
            }
            catch(Exception excecao)
            {
              System.err.println ("Exce��o encontrada: " + excecao.getMessage());
            }
            cont = rec.lerValor();
            soma += cont;
        }
        while (cont != 15);
        System.out.println ("A soma dos valores lidos pelo consumidor foi " + soma);
    }            
}
