/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 7.6
*
*/

import javax.media.Manager;
import javax.media.MediaLocator;
import javax.media.Player;

public class ReceptorRTPAudioMulticast
{
  public static void main(String[] args)
  {
    try
    {
        String url = "rtp://224.147.85.1:55885/audio";
        MediaLocator localizacao = new MediaLocator(localizacao);

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