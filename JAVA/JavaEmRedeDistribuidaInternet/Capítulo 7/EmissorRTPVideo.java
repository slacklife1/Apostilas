/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 7.9
*
*/

import java.util.Vector;
import javax.media.format.*;
import javax.media.protocol.*;
import javax.media.rtp.*;
import javax.media.*;
import javax.media.control.*;

public class EmissorRTPVideo
{ 
    public EmissorRTPVideo() 
    {        
        try
        {
            Vector deviceList = CaptureDeviceManager.getDeviceList(new VideoFormat(VideoFormat.YUV));
            CaptureDeviceInfo device = (CaptureDeviceInfo)deviceList.get(0);
            Processor processor = Manager.createProcessor(device.getLocator());
            
            processor.configure();
            while (processor.getState() != Processor.Configured)
            {
                Thread.sleep(100);
            }

            processor.setContentDescriptor(new ContentDescriptor(ContentDescriptor.RAW));

            TrackControl track[] = processor.getTrackControls();
            track[0].setFormat(new VideoFormat (VideoFormat.JPEG_RTP));

            processor.realize();
            while (processor.getState() != Processor.Realized)
            {
                Thread.sleep(100);
            }

            DataSource sourceFinal = processor.getDataOutput();

            String url= "rtp://10.65.97.94:6666/video";
            MediaLocator destino = new MediaLocator(url);

            DataSink sink = Manager.createDataSink(sourceFinal, destino);
            sink.open();
            sink.start();
            processor.start();            
        }
        catch (Exception exc)
        {
            exc.printStackTrace();
        }
    }
   
    public static void main (String args[])
    {
        new EmissorRTPVideo();
    }
}