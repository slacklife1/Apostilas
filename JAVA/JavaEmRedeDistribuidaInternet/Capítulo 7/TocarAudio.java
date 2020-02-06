/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 7.1
*
*/

import javax.media.*;
import java.io.*;
import javax.swing.*;

public class TocarAudio
{
    Player audioPlayer = null;
    public TocarAudio (File arquivo)  
    {
        try
        {
            audioPlayer = Manager.createRealizedPlayer(arquivo.toURI().toURL());
        }
        catch (Exception exc)
        {
            System.err.println (exc.toString());
        }
    }
    static public void main (String args[])
    {        
        String entrada = JOptionPane.showInputDialog(null, "Digite o nome do arquivo.");
        File arquivo = new File(entrada);
        TocarAudio tocar = new TocarAudio(arquivo);
        tocar.play();
    }
    public void play() 
    {
        audioPlayer.start();
    }
    public void stop() 
    {
        audioPlayer.stop();
        audioPlayer.close();
    }
}
