/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo A.1
*
*/

import javax.swing.*;
import java.awt.event.*;
import java.awt.*;
import java.io.*;
import java.util.*;

public class ProgramaArquivoTexto extends JFrame implements ActionListener
{
	private JMenuItem menuAbrir;
	private JMenuItem menuNovo;
	private JMenuItem menuSair;
	private JMenuItem menuSalvar;
  private JTextArea texto;

  private String arquivo = "texto.txt";

	private ObjectInputStream entrada;
	private ObjectOutputStream saida;

	public ProgramaArquivoTexto()
	{
		super ("Processador de texto");

		JMenuBar bar = new JMenuBar();
		setJMenuBar (bar);

		JMenu menuPrinc = new JMenu ("Principal");

		menuPrinc.setMnemonic ('P');

    menuNovo = new JMenuItem ("Novo");
		menuAbrir = new JMenuItem ("Abrir");
		menuSalvar = new JMenuItem ("Salvar");
    menuSair = new JMenuItem ("Sair");

		menuPrinc.add (menuNovo);
		menuPrinc.add (menuAbrir);
 		menuPrinc.add (menuSalvar);
		menuPrinc.addSeparator();
		menuPrinc.add (menuSair);

		menuSair.addActionListener (this);
		menuNovo.addActionListener (this);
		menuAbrir.addActionListener (this);
		menuSalvar.addActionListener (this);

		texto = new JTextArea ();
		texto.setFont (new Font ("Serif", Font.BOLD, 13));
		getContentPane().add (new JScrollPane (texto), BorderLayout.CENTER);

		bar.add (menuPrinc);

		setResizable (false);
		setSize (400, 300);
		setLocation (250, 250);
		setVisible (true);
	}
	static public void main (String[] obj)
	{
		final ProgramaArquivoTexto prog = new ProgramaArquivoTexto();
		prog.addWindowListener (new WindowAdapter ()
		{
			public void windowClosing (WindowEvent e)
			{

				prog.sair();
			}
		});
	}
	public void actionPerformed (ActionEvent ev)
	{
		if (ev.getSource () == menuSair)
		{
       sair();
		}
		else if (ev.getSource() == menuAbrir)
		{
			abrirArquivo();
		}
		else if (ev.getSource() == menuNovo)
		{
			texto.setText ("");
		}
		else if (ev.getSource() == menuSalvar)
		{
			salvarArquivo();
		}
	}
	public void abrirArquivo()
	{
		File file = new File (arquivo);

		try
		{
			entrada = new ObjectInputStream (new FileInputStream (file));
			texto.setText ("");
			texto.setText ((String)entrada.readObject());
		}
		catch (Exception e)
		{
			JOptionPane.showMessageDialog (this, "Erro de processamento do Arquivo", "Erro", JOptionPane.ERROR_MESSAGE);
		}
	}
	public void salvarArquivo()
	{
		File file = new File (arquivo);
		
		try
		{
			saida = new ObjectOutputStream (new FileOutputStream (file));
			saida.writeObject (texto.getText());		
			saida.flush();
		}
		catch (Exception e)
		{
			JOptionPane.showMessageDialog (this, "Erro de processamento do Arquivo", "Erro", JOptionPane.ERROR_MESSAGE);
		}
	}
  public void sair()
  {
   		try
			{
				if (entrada != null)
					entrada.close();
				if (saida != null)
					saida.close();
			}
      catch (Exception exc)
			{
				JOptionPane.showMessageDialog (this, exc.toString());
			}
      System.exit (0);
  }
}
