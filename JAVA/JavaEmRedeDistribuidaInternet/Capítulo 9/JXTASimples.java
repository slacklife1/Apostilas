/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 9.4
*
*/

import net.jxta.membership.*;
import net.jxta.peer.*;
import net.jxta.peergroup.*;

public class JXTASimples
{

    static PeerGroup peerGroup = null;

    public static void main(String args[])
    {

        JXTASimples prog = new JXTASimples();
        try
        {
            peerGroup = PeerGroupFactory.newNetPeerGroup();
        }
        catch (Exception exc)
        {
            System.err.println (exc.getMessage());
            System.exit(1);
        }

        System.out.println("Nome do peer: " + peerGroup.getPeerName());
    }
}
