/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 7.5
*
*/


public class Calcular implements CalcularMBean
{
    public int somar(int a, int b)
    {
        return a + b;
    }
    public int subtrair(int a, int b)
    {
	return a - b;
    }
    public int multiplicar(int a, int b)
    {
	return a * b;
    }
    public int dividr(int a, int b)
    {
	return a / b;
    }
}