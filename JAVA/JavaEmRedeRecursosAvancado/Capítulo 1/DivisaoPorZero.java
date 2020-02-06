/*
* Java em Rede: Recursos Avan�ados de Programa��o
*
* Daniel G. Costa
*
* Exemplo 1.30
*
*/   


public class DivisaoPorZero
{

    public static void main (String entrada[])
    {
        new DivisaoPorZero().calcularComTratamento();
        new DivisaoPorZero().calcular();
    }
                  }
    public void calcularComTratamento()
    {
        try
        {
            System.out.println ("Divis�o de 5 por 0 �: " + 5/0);
            System.out.println ("Essa mensagem n�o deve aparecer na tela.");
        }
        catch (java.lang.ArithmeticException exc)
        {
            System.err.println ("Divis�o de 5 por 0 n�o � poss�vel");
        }
    }
    
    public void calcular()
    {
        System.out.println ("Divis�o de 5 por 0 �: " + 5/0);
    }
}