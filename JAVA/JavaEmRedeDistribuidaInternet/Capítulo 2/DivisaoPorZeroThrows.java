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
            int ent1 = Integer.parseInt (JOptionPane.showInputDialog(null, "Digite o primeiro n�mero."));
            int ent2 = Integer.parseInt (JOptionPane.showInputDialog(null, "Digite o segundo n�mero."));

            int resultado = calcular  (ent1, ent2);
            JOptionPane.showMessageDialog(null, "O valor da divis�o inteira de " + ent1 + " por " + ent2 + " �: " + resultado);
        }
        catch (ArithmeticException exc)
        {
            JOptionPane.showMessageDialog (null, "Divis�o de um n�mero por zero n�o � poss�vel.\n" + exc.getMessage());
        }
        catch (NumberFormatException exc)
        {
            JOptionPane.showMessageDialog (null, "Convers�o do argumento passado para o tipo inteiro n�o � poss�vel.\n" + exc.toString());
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
