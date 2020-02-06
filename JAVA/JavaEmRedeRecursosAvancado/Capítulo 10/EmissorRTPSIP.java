/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 10.8
*
*/


import java.util.Vector;
import javax.media.*;
import javax.media.control.*;
import javax.media.format.*;
import javax.media.protocol.*;

public class EmissorRTPSIP
{
     public void iniciarTransmissao (String endereco, String tipo)
     {     
 	try
 	{
 	     AudioFormat format = new AudioFormat(AudioFormat.LINEAR, 8000, 8, 1);
 			
   	     Vector dispositivos = CaptureDeviceManager.getDeviceList(format);

 	     CaptureDeviceInfo info = null;

 	     if (dispositivos.size() > 0)
 	         info = (CaptureDeviceInfo) dispositivos.elementAt (0);

 	     Processor processor = null;
 	     processor = Manager.createProcessor(info.getLocator());

 	     processor.configure();
 	     while (processor.getState() != Processor.Configured)
 	     {
 	          Thread.sleep(100);
 	     }

 	     TrackControl track[] = processor.getTrackControls();
 	     track[0].setFormat( new AudioFormat(AudioFormat.ULAW_RTP, 8000, 8,1));

 	     processor.realize();
 	     while (processor.getState() != Processor.Realized)
 	     {
 	          Thread.sleep(100);
 	     }
 			
 	     DataSource sourceFinal = processor.getDataOutput();

 	     String url = "rtp://" + endereco + "/" + tipo;
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