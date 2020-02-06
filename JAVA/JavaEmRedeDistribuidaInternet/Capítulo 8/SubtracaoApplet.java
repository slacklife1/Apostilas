/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 8.7
*
*/

import javax.swing.JApplet;
import java.awt.Graphics;

public class SubtracaoApplet extends JApplet
{

  public void paint(Graphics obj)
  {
    int num1 = Integer.parseInt (getParameter("numero1"));
    int num2 = Integer.parseInt (getParameter("numero2"));
    String saida = "O resultado da subtra��o de " + num1 + " por " + num2 + " � " + (num1 - num2);
    obj.drawString (saida, 10, 50);
  }

}
