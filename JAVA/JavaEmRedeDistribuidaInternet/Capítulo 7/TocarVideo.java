/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 7.2
*
*/

import java.awt.*;
import java.io.*;
import java.net.*;
import javax.media.*;
import javax.swing.*;
   
public class TocarVideo extends JFrame
{
    Container conteudo;
    public TocarVideo(URL localizacao)
    {
        super ("Player de Vídeo");

        conteudo = getContentPane();

        try
        {
             Player player = Manager.createRealizedPlayer(localizacao);
  
             Component video = player.getVisualComponent();
             Component controles = player.getControlPanelComponent();

             if (video != null)
                conteudo.add (video, BorderLayout.CENTER );

             if (controles != null)
                conteudo.add (controles, BorderLayout.SOUTH );

             player.start();

             setSize (350, 350);
             setVisible(true);
         }
         catch (Exception exc)
         {
            System.err.println(exc.getMessage());
         }
    }
    public static void main (String media[])
    {
        JFileChooser chooser = new JFileChooser();   
        int retorno = chooser.showOpenDialog (null);

        URL url = null;
        try
        {
            if (retorno == JFileChooser.APPROVE_OPTION)        
            {
                url = chooser.getSelectedFile().toURI().toURL();
                if (url != null)
                    new TocarVideo(url);
                else
                    System.out.println ("Programa encerrado.");
            }
        }
        catch (Exception exc)
        {
           System.out.println ("Arquivo não pôde ser aberto ou é inválido.");
        }        
       
    }
}