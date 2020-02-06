/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 7.10
*
*/

import javax.media.*;
import javax.swing.JFrame;

public class ReceptorRTPVideo extends JFrame
{
    public static void main (String entrada[])
    {
        new ReceptorRTPVideo();
    }
    public ReceptorRTPVideo()
    {
        try
        {
            String url= "rtp://10.65.97.94:5530/video";

            MediaLocator dadosRecebidos = new MediaLocator(url);

            Player player = Manager.createRealizedPlayer(dadosRecebidos);

            player.start();

            setSize (300, 300);
            getContentPane().add (player.getVisualComponent());
            setVisible(true);
        }
        catch (Exception exc)
        {
            exc.printStackTrace();
        }
    }
}
