/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 10.1
*
*/


import javax.media.*;
import javax.media.control.*;
import javax.media.format.*;
import javax.media.protocol.*;
	
public class EmissorRTP
{	
     static String destino = "187.65.34.219:4738";
     public static void main(String[] args)
     {
          new EmissorRTP().iniciarTransmissao (destino, AudioFormat.MPEG_RTP);
     }
     public void iniciarTransmissao (String destino, String codec)
     {
          try
          {              
                String arquivo = "file:audio.wav";
                MediaLocator localizacao = null;
                DataSource dataSource = null;
                Processor processor = null;       

                localizacao = new MediaLocator (arquivo);       
                dataSource = Manager.createDataSource(localizacao);
                processor = Manager.createProcessor(dataSource);                 

                processor.configure();
                while (processor.getState() != Processor.Configured)
                {
                    Thread.sleep(100);
                }

                processor.setContentDescriptor(new ContentDescriptor(ContentDescriptor.RAW_RTP));

                TrackControl track[] = processor.getTrackControls();
                track[0].setFormat(new AudioFormat(codec));

                processor.realize();
                while (processor.getState() != Processor.Realized)
                {
                    Thread.sleep(100);
                }

                DataSource sourceFinal = processor.getDataOutput();

                String endDestino = "rtp://" + destino + "/audio";
                MediaLocator receptor = new MediaLocator(endDestino);

                DataSink sink = Manager.createDataSink(sourceFinal, receptor);
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