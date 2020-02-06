/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 8.12
*
*/

import java.awt.*;
import javax.swing.*;
import java.awt.event.*;
import java.net.URL;
import java.applet.AppletContext;

public class AppletURL extends JApplet implements ActionListener
{
  JButton botao1, botao2;
  public void init()
  {
    Container content = getContentPane();
    content.setBackground(Color.white);
    content.setLayout(new FlowLayout());

    botao1 = new JButton ("Site da Brasport");
    content.add(botao1);
    botao2 = new JButton ("Site do Java");
    content.add(botao2);

    botao1.addActionListener(this);
    botao2.addActionListener(this);
  }
  public void actionPerformed (ActionEvent evento)
  {
    URL url = null;
    try
    {
      if (evento.getSource() == botao1)
      {
        url = new URL ("http://www.brasport.com.br.");
      }
      else
      {
        url = new URL ("http://www.java.sun.com");
      }
      AppletContext browser = getAppletContext();
      browser.showDocument(url);

    }
    catch (Exception exc)
    {
      JOptionPane.showMessageDialog(this, "Erro no acesso a página.");
    }
  }
}

