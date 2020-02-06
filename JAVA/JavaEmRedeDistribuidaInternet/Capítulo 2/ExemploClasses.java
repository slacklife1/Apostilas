/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 2.2
*
*/ 

import java.text.DecimalFormat;

public class ExemploClasses
{

  private Calculadora calc, calc2 = null;
  public ExemploClasses(int valor)
  {

    calc =  new Calculadora();

    System.out.println (valor + " mais 6 é " + calc.somar (valor, 6));
    System.out.println (valor + " vezes 2 é " + calc.somar (valor));

    calc2 =  new Calculadora();
    Calculadora calc3 = calc2;

    System.out.println ("9 menos " + valor + " é " + calc2.subtrair(9, valor));
    DecimalFormat saida = new DecimalFormat("0.000");
    System.out.println (valor + " vezes " + valor + " é " + saida.format(calc3.quadrado(valor)));

    System.out.println ("Ao final, o valor da variavel \"resultado\" é " + calc.resultado + ", " + calc2.resultado + " e " + calc3.resultado);

  }
  static public void main (String args[])
  {
     new ExemploClasses(58);
  } 
}
class Calculadora
{
  public int resultado = 0;

  public int somar(int a, int b)
  {
    resultado = a + b;
    return resultado;
  }
  protected int somar(int a)
  {
    resultado = a + a;
    return resultado;
  }
  public int subtrair(int a, int b)
  {
    resultado = a - b;
    return resultado;
  }
  protected double quadrado(int a)
  {
    resultado = a;
    return Math.pow(resultado, 2);
  }
}