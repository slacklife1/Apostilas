/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 8.5
*
*/

import java.awt.*;
import javax.swing.*;
import java.awt.event.*;

public class SomaApplet2 extends JApplet implements ActionListener
{

  JButton botao;
  private JTextField campo1, campo2, campo3;

  public void init()
  {    
    Container content = getContentPane();
    content.setBackground(Color.white);
    content.setLayout(new FlowLayout());

    botao = new JButton ("Calcular");
    content.add(botao);
    botao.addActionListener(this);

    content.add (new JLabel ("Número 1"));
    campo1 = new JTextField (10);
    content.add (campo1);
    content.add (new JLabel ("Número 2"));
    campo2 = new JTextField (10);
    content.add (campo2);
    content.add (new JLabel ("Resultado"));
    campo3 = new JTextField (10);
    content.add (campo3);
  }
  public void actionPerformed (ActionEvent evento)
  {
    try
    {
      int num1 = Integer.parseInt(campo1.getText());
      int num2 = Integer.parseInt(campo2.getText());
      campo3.setText(String.valueOf (num1 + num2));
    }
    catch (NumberFormatException exc)
    {
      JOptionPane.showMessageDialog(this, "Número digitado é inválido!");
    }
    finally
    {
      campo1.setText("");
      campo2.setText("");
    }

  }
}

