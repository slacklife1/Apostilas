/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 7.5
*
*/

import java.util.Vector;
import javax.media.*;
import javax.media.control.*;
import javax.media.format.*;
import javax.media.protocol.*;

public class EmissorRTPAudioMulticast
{
    public static void main(String[] args)
    {
        try
        {
            AudioFormat format = new AudioFormat(AudioFormat.LINEAR, 8000, 8, 1);

            Vector dispositivos = CaptureDeviceManager.getDeviceList(format);

            CaptureDeviceInfo info = null;

            if (dispositivos.size() > 0)
                info = (CaptureDeviceInfo)dispositivos.elementAt (0);

            Processor processor = null;
            processor = Manager.createProcessor(info.getLocator());

            processor.configure();
            while (processor.getState() != Processor.Configured)
            {
                Thread.sleep(100);
            }

            TrackControl track[] = processor.getTrackControls();
            track[0].setFormat( new AudioFormat(AudioFormat.GSM_RTP, 8000, 8,1));     

            processor.realize();
            while (processor.getState() != Processor.Realized)
            {
                   Thread.sleep(100);
            }

            DataSource sourceFinal = processor.getDataOutput();

            String url = "rtp://224.147.85.1:55885/audio";
            MediaLocator destino = new MediaLocator(url);

            DataSink sink = Manager.createDataSink(sourceFinal, destino);
            sink.open();
            sink.start();
            processor.start();
        }
        catch (Exception exc)
        {
            System.err.println (exc.toString());
            System.exit(1);
        }
    }
}
