/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 7.2
*
*/


public class Numero implements NumeroMBean
{
    
    private int numero = 0;
    
    public int getNumero()
    {
        return numero;
    }
    public synchronized void setNumero (int n)
    {
    	numero = n;
    }
}