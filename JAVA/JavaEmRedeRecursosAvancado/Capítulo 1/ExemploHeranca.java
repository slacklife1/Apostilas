/*
* Java em Rede: Recursos Avan�ados de Programa��o
*
* Daniel G. Costa
*
* Exemplo 1.3
*
*/  


public class ExemploHeranca
{

    public ExemploHeranca()
    {
    }
    public static void main (String exemplo[])
    {
        Quadrado q = new Quadrado(10);
        System.out.println ("A �rea de um quadrado de lado 10 � " + q.area ());
        Triangulo t = new Triangulo(6, 3);
        System.out.println ("A �rea de um tri�ngulo reto de base 6 e altura 3 � " + t.area ());
    }
}

class Forma
{
    double lado;
    public double area()
    {
        return lado * lado;
    }
}

class Quadrado extends Forma
{
    public Quadrado (double l)
    {
        lado = l;
    }
}

class Triangulo extends Forma
{
    double base, altura;
    public Triangulo (double b, double a)
    {
        base = b;
        altura = a;
    }
    public double area ()
    {
        return base * altura / 2;
    }
}