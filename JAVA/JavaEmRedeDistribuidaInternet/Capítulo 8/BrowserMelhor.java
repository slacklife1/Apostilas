/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 8.15
*
*/

import javax.swing.*;
import javax.swing.event.*;
import java.net.*;
import java.awt.event.*;
import java.awt.*;
import java.io.*;

public class BrowserMelhor extends JFrame implements ActionListener, HyperlinkListener
{
private JTextField campo;
private JEditorPane area;
  public BrowserMelhor()
  {
    super ("Browser Melhor");

    campo = new JTextField("http://");
    campo.addActionListener(this);
    area = new JEditorPane();
    area.setEditable (false);
    area.addHyperlinkListener(this);

    getContentPane().add(campo, BorderLayout.NORTH);
    getContentPane().add (new JScrollPane (area));

    setSize (800, 600);
    setVisible (true);
  }
  public static void main (String web[])
  {
    BrowserMelhor browser = new BrowserMelhor();
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
    buscarPagina(evento.getActionCommand());
  }
  public void hyperlinkUpdate(HyperlinkEvent evento)
  {
    if (evento.getEventType() == HyperlinkEvent.EventType.ACTIVATED)
      buscarPagina(evento.getURL().toString());
  }
  public void buscarPagina(String endereco)
  {
    try
    {
      setCursor(Cursor.getPredefinedCursor(Cursor.WAIT_CURSOR));
      area.setPage (endereco);
      setCursor(Cursor.getDefaultCursor());
    }
    catch (UnknownHostException exc)
    {
      JOptionPane.showMessageDialog(this, "Endereço inválido.");
    }
    catch (MalformedURLException exc)
    {
      JOptionPane.showMessageDialog(this, "URL inválida.");
    }
    catch (Exception exc)
    {
      System.err.println (exc.toString());
    }
  }
}