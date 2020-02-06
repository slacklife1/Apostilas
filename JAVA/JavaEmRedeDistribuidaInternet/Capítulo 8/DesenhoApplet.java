/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 8.1
*
*/ 

import javax.swing.JApplet;
import java.awt.Graphics;
import java.awt.Color;

public class DesenhoApplet extends JApplet
{
  public void paint (Graphics g)
  {
    g.setColor (Color.blue);
    g.drawString("Esse é um exemplo de Applet", 30, 30);

    g.setColor (Color.red);
    g.fillOval(100, 100, 100, 100);

    g.setColor (Color.yellow);
    g.drawOval(80, 80, 100, 100);

    g.setColor (Color.green);
    g.fillRect(100, 210, 100, 100);

    g.setColor (Color.black);
    g.drawLine (50, 50, 70, 70);
    g.drawLine (50, 50, 120, 70);
  }
}