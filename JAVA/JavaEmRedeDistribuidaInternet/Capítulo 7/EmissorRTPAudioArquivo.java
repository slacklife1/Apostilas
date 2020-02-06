/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 7.3
*
*/

import javax.media.*;
import javax.media.control.*;
import javax.media.format.*;
import javax.media.protocol.*;

public class EmissorRTPAudioArquivo
{
    public static void main(String[] args)
    {
        try
        {
            String arquivo = "file:musica.wav";

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

            processor.setContentDescriptor(new ContentDescriptor(ContentDescriptor.RAW));

            TrackControl track[] = processor.getTrackControls();
            track[0].setFormat(new AudioFormat(AudioFormat.MPEG_RTP));

            processor.realize();
            while (processor.getState() != Processor.Realized)
            {
                Thread.sleep(100);
            }

            //Dados já processados
            DataSource sourceFinal = processor.getDataOutput();

            String url = "rtp://200.25.169.47:5530/audio";
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
