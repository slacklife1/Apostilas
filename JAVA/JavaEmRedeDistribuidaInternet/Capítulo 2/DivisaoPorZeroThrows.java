/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 2.39
*
*/ 

import javax.swing.JOptionPane;

public class DivisaoPorZeroThrows {
    
    public static void main (String entrada[])
    {            
            new DivisaoPorZeroThrows().calcularComTratamento();     
    }
    public void calcularComTratamento()
    {
        try 
        {
            int ent1 = Integer.parseInt (JOptionPane.showInputDialog(null, "Digite o primeiro número."));
            int ent2 = Integer.parseInt (JOptionPane.showInputDialog(null, "Digite o segundo número."));

            int resultado = calcular  (ent1, ent2);
            JOptionPane.showMessageDialog(null, "O valor da divisão inteira de " + ent1 + " por " + ent2 + " é: " + resultado);
        }
        catch (ArithmeticException exc)
        {
            JOptionPane.showMessageDialog (null, "Divisão de um número por zero não é possível.\n" + exc.getMessage());
        }
        catch (NumberFormatException exc)
        {
            JOptionPane.showMessageDialog (null, "Conversão do argumento passado para o tipo inteiro não é possível.\n" + exc.toString());
            exc.printStackTrace();
        }
        finally
        {
            System.out.println ("Programa encerrado");
        }
    }
    public int calcular (int a, int b) throws ArithmeticException
    {
       return a/b;         
    }
}
