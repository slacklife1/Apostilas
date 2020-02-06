/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 3.3
*
*/

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class ThreadDesenho extends JFrame
{
    public ThreadDesenho()
    {
        super ("Ponto gráfico.");
        setBounds(350, 250, 270, 290);
        Quadro quadro = new Quadro(Color.blue);
        getContentPane().add (quadro);
        quadro.repaint();
        setVisible(true);              
    }
    public static void main (String args[])
    {
        ThreadDesenho desenho = new ThreadDesenho();
        desenho.addWindowListener( new WindowAdapter ()
        {
            public void windowClosing (WindowEvent evento)
            {
                System.exit (0);
            }
        });              
    }    
}

class Ponto extends Thread
{

    Quadro quadro;
    int x, y;
    int contador = 0;

    public Ponto (Quadro qq)
    {
        quadro = qq;
        x = 0;
        y = 0;
    }
    public void run ()
    {
        while (true)
        {
            if (contador < 50)
            {
                x += 5;
                contador++;
            }
            else if (contador < 100)
            {
                y += 5;
                contador++;
            }
            else if (contador < 150)
            {
                x -= 5;
                contador++;
            }
            else if (contador < 200)
            {
                y -= 5;
                contador++;
                if (contador == 200)
                    contador=0;
            }
            quadro.alterarValores(x, y);
            quadro.repaint();
            try
            {
              sleep (100);
            }
            catch (Exception excecao)
            {
              System.err.println ("Exceção encontrada: " + excecao.getMessage());
            }
        }
    }
}

class Quadro extends JPanel
{

    int x, y;
    Color cor;

    public Quadro(Color cc)
    {
        repaint();
        cor = cc;
        x = 0;
        y = 0;
        Ponto ponto = new Ponto(this);
        ponto.start();
    }
    public void paintComponent(Graphics g)
    {     
        super.paintComponent(g);      
        g.setColor (cor);
        g.fillOval (x, y, 10, 10);
  
    }
    public void alterarValores (int posicaox, int posicaoy)
    {
        x = posicaox;
        y = posicaoy;
    }
}
        

