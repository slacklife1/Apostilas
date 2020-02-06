/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 8.3
*
*/

import javax.swing.JApplet;
import javax.swing.JOptionPane;
import java.awt.Graphics;

public class SomaApplet extends JApplet
{
  private int resultado;
  public void init ()
  {
    try
    {
      String entrada1 = JOptionPane.showInputDialog(this, "Digite o primeiro número.");
      int num1 = Integer.parseInt (entrada1);

      String entrada2 = JOptionPane.showInputDialog(this, "Digite o segundo número.");
      int num2 = Integer.parseInt (entrada2);

      resultado = num1 + num2;

    }
    catch (NumberFormatException exc)
    {
      JOptionPane.showMessageDialog(this, "Número digitado é inválido!");
    }
  }
  public void paint (Graphics g)
  {
    g.drawString("A soma dos números digitados é: " + (resultado), 10, 10);
  }
}