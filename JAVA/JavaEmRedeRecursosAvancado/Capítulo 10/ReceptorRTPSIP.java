/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 10.10
*
*/


import javax.media.Manager;
import javax.media.MediaLocator;
import javax.media.Player;

public class ReceptorRTPSIP
{
     public void iniciarRecepcao (String origem, String tipo)
     {
         try
 	 {
   	     String url = "rtp://" + origem + "/" + tipo;
 	     MediaLocator localizacao = new MediaLocator(url);

 	     Player player = Manager.createPlayer(localizacao);

 	     player.realize();
 	     while (player.getState() != Player.Realized)
 	     {
 	 	Thread.sleep(50);
 	     }

             System.out.println ("Iniciando recepção de pacotes de aúdio");
 	     player.start();
 	} 
 	catch (Exception exc)
 	{
 	     System.err.println(exc.toString());
 	     System.exit(1);
 	}
     }
}