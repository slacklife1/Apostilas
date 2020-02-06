/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 2.37
*
*/

public class DivisaoPorZero {
    
    public static void main (String entrada[])
    {
            new DivisaoPorZero().calcularComTratamento();
            new DivisaoPorZero().calcular();
              
    }
    public void calcularComTratamento()
    {
        try 
        {
            System.out.println ("Divisão de 5 por 0 é: " + 5/0);
            System.out.println ("Essa mensagem não deve aparecer na tela.");
        }
        catch (java.lang.ArithmeticException exc)
        {
            System.err.println ("Divisão de 5 por 0 não é possível");
        }     
    }
    public void calcular()
    {
        System.out.println ("Divisão de 5 por 0 é: " + 5/0);
    }
}
