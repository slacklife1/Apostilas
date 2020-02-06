/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 10.2
*
*/


import javax.media.Manager;
import javax.media.MediaLocator;
import javax.media.Player;

public class ReceptorRTP
{
    public static void main(String[] args)
    {
 	 try
 	 {
   	     String url = "rtp://187.65.34.219:4738/audio";
 	     MediaLocator localizacao = new MediaLocator(url);

 	     Player player = Manager.createPlayer(localizacao);

 	     player.realize();
 	     while (player.getState() != Player.Realized)
 	     {
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