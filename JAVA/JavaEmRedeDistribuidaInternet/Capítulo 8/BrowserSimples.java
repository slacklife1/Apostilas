/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 8.14
*
*/

import javax.swing.*;
import java.awt.event.*;
import java.awt.*;

public class BrowserSimples extends JFrame implements ActionListener
{
private JTextField campo;
private JEditorPane area; 
  public BrowserSimples()
  {
    super ("Browser Simples");

    campo = new JTextField();
    campo.addActionListener(this);
    area = new JEditorPane();
    area.setEditable(false);

    getContentPane().add(campo, BorderLayout.NORTH);
    getContentPane().add (new JScrollPane (area));

    setSize (800, 600);
    setVisible (true);
  }
  public static void main (String web[])
  {
    BrowserSimples browser = new BrowserSimples();
    browser.addWindowListener( new WindowAdapter ()
    {
       public void windowClosing (WindowEvent evento)
       {
          System.exit (0);
      }
    });
  }
  public void actionPerformed (ActionEvent evento)
  {
    try
    {
      area.setPage(evento.getActionCommand());
    }
    catch (Exception exc)
    {
      System.err.println (exc.toString());
    }
  }
}