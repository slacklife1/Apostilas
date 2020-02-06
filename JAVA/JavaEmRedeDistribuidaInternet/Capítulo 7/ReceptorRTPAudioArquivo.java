/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 7.4
*
*/

import javax.media.Manager;
import javax.media.MediaLocator;
import javax.media.Player;

public class ReceptorRTPAudioArquivo
{

  public static void main(String[] args)
  {
    try
    {
        String url= "rtp://200.25.169.47:5530/audio";

        MediaLocator localizacao = new MediaLocator(url);

        Player player = Manager.createPlayer(localizacao);

        player.realize();

        while (player.getState() != Player.Realized){
            Thread.sleep(50);
        }

        player.start();
    } 
    catch (Exception exc)
    {
        System.err.println(exc.toString());
        System.exit(1);
    }
}

}