/*
* Java em Rede: Recursos Avan�ados de Programa��o
*
* Daniel G. Costa
*
* Exemplo 1.7
*
*/


import java.text.DecimalFormat;

public final class ExemploArrays
{
    int numerosInteiros[];
    double[] numerosReais; 
    static final int TAMANHO=20;

    static public void main(String[] java)
    {
        ExemploArrays prog = new ExemploArrays();
	prog.numerosInteiros = new int [TAMANHO];
	prog.numerosReais = new double [TAMANHO*2];
	
	for (int i=0; i < TAMANHO; i ++)
	{
 	    prog.numerosInteiros[i] = (int)(Math.random() * 10);
	    prog.numerosReais[i] = (Math.random() * 10);
	}
	
	System.out.println("N�meros inteiros aleat�rios:");

 	for (int i=0; i < TAMANHO; i ++)
 	    System.out.print(prog.numerosInteiros[i] + " - ");

  	DecimalFormat formatacao = new DecimalFormat("0.00");
	System.out.println("\nN�meros reais aleat�rios:");

	for (int i=0; i < TAMANHO; i ++)
	    System.out.print(formatacao.format(prog.numerosReais[i]) + " - ");
    }
}