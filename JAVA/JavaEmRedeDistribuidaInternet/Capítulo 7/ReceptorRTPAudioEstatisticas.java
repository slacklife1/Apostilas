/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 7.8
*
*/

import javax.media.*;
import javax.media.protocol.*;
import javax.media.rtp.*;
import javax.media.rtp.event.*;
import javax.media.format.*;
import java.net.InetAddress;
import javax.swing.JFrame;

public class ReceptorRTPAudioEstatisticas extends JFrame implements ReceiveStreamListener
{
  int portaLocal = 9920;
  int portaRemota = 9910;
  Player player;

  public static void main(String[] args)
  {
      new ReceptorRTPAudioEstatisticas();
  }
  public ReceptorRTPAudioEstatisticas()
  {
    try
    {
        RTPManager rtp = RTPManager.newInstance();
        rtp.addFormat(new AudioFormat(AudioFormat.GSM_RTP), 0);

        SessionAddress endLocal = new SessionAddress(InetAddress.getLocalHost(), portaLocal);

        String destino = "157.54.36.158";
        SessionAddress endRemoto = new SessionAddress(InetAddress.getByName(destino), portaRemota);

        rtp.initialize(endLocal);
        rtp.addTarget(endRemoto);

        rtp.addReceiveStreamListener(this);
        
        setVisible (true);
    }
    catch (Exception exc)
    {
        exc.printStackTrace();
    }
  }
  public synchronized void update(ReceiveStreamEvent evento)
  {
     if ((player == null) && (evento.getReceiveStream() != null))
     {

        DataSource dadosRecebidos = evento.getReceiveStream().getDataSource();

        if(dadosRecebidos != null)
        {
            try
            {
                player = Manager.createRealizedPlayer(dadosRecebidos);
                player.start();
            }
            catch (Exception exc)
            {
                System.out.println (exc.toString());
            }
        }
     }
  }
}
