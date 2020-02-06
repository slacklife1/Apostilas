/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 7.7
*
*/

import java.util.Vector;
import javax.media.*;
import javax.media.control.*;
import javax.media.format.*;
import javax.media.protocol.*;
import javax.media.rtp.*;
import java.net.InetAddress;

public class EmissorRTPAudioEstatisticas
{
    int portaLocal = 9910;
    int portaRemota = 9920;

    public static void main(String[] args)
    {
        try
        {
            AudioFormat formato = new AudioFormat(AudioFormat.LINEAR, 8000, 8, 1);

            Vector devices = CaptureDeviceManager.getDeviceList(formato);

            CaptureDeviceInfo info = null;

            if (devices.size() > 0)
                info = (CaptureDeviceInfo) devices.elementAt(0);

            Processor processor = null;
            processor = Manager.createProcessor(info.getLocator());

            processor.configure();
            while (processor.getState() != Processor.Configured)
            {
                Thread.sleep(100);
            }

            processor.setContentDescriptor(new ContentDescriptor(ContentDescriptor.RAW_RTP));

            TrackControl track[] = processor.getTrackControls();
            track[0].setFormat( new AudioFormat(AudioFormat.GSM_RTP, 8000, 8,1));

            processor.realize();
            while (processor.getState() != Processor.Realized)
            {
                Thread.sleep(100);
            }

            DataSource sourceFinal = processor.getDataOutput();

            RTPManager rtp = RTPManager.newInstance();
            
            SessionAddress endLocal = new SessionAddress (InetAddress.getLocalHost(), portaLocal);

            String destino = "139.25.136.84";
            SessionAddress endRemoto = new SessionAddress (InetAddress.getByName(destino), portaRemota);

            rtp.initialize(endLocal);
            rtp.addTarget(endRemoto);
            SendStream send = rtp.createSendStream(sourceFinal, 0);
            send.start();
            processor.start();
                        
            while (true)
            {
                TransmissionStats stats = send.getSourceTransmissionStats();
                int bytes = stats.getBytesTransmitted();
                int rtcp = stats.getRTCPSent();
                
                System.out.println ("bytes transmitidos: " + bytes);
                System.out.println ("Pacotes RTCP enviados: " + rtcp);
                Thread.sleep (10000);            
            }     
        }
        catch (Exception exc)         
        {
            System.err.println (exc.toString());
            exc.printStackTrace();
        }
    }
}
