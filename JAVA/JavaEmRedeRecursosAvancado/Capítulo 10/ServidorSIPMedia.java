/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 10.9
*
*/


import javax.sip.*;
import javax.sip.message.*;
import javax.sip.address.*;
import javax.sip.header.*;
import java.util.*;
import javax.sdp.*;

public class ServidorSIPMedia implements SipListener
{
        SipFactory sf;      
        SipProvider udpP, tcpP, sp;
        
        String endLocal;
        final static int portaLocal = 5060;
        
        MessageFactory messageFactory;
        AddressFactory addressFactory;
        HeaderFactory headerFactory; 
        
        SessionDescription sdpRemoto;
        
        public static void main (String args[])
        {
            new ServidorSIPMedia();
        }
	public ServidorSIPMedia ()
	{	
            try
            {                
		sf = SipFactory.getInstance();
		sf.setPathName ("gov.nist");
		
		Properties prop = new Properties ();
                
                endLocal = java.net.InetAddress.getLocalHost().getHostAddress();
                                
		prop.setProperty ("javax.sip.STACK_NAME", "gov.nist");
                prop.setProperty ("javax.sip.IP_ADDRESS", endLocal);
					
		SipStack pilhaSip = sf.createSipStack (prop);
		
                ListeningPoint esperarTcp=  pilhaSip.createListeningPoint (endLocal, portaLocal, "tcp");
		tcpP = pilhaSip.createSipProvider (esperarTcp);
		tcpP.addSipListener (this);
                
                ListeningPoint esperarUdp=  pilhaSip.createListeningPoint (endLocal, portaLocal, "udp");
		udpP = pilhaSip.createSipProvider (esperarUdp);
		udpP.addSipListener (this);       
                
                sp = udpP;
                
                messageFactory = sf.createMessageFactory();
                addressFactory = sf.createAddressFactory();
                headerFactory = sf.createHeaderFactory(); 
                
                System.out.println ("Estou aguardando conexões.");     
                
	}
	catch (Exception exc)
	{
		System.out.println (exc.toString());
		exc.printStackTrace();
                System.exit (-1);
	}
	}

	public void processDialogTerminated(DialogTerminatedEvent evento)
	{
	}
	public void processTransactionTerminated(TransactionTerminatedEvent evento)
	{
	}
	public void processIOException(IOExceptionEvent evento)
	{
	}
	public void processTimeout(TimeoutEvent evento)
	{
	}
	public void processResponse(ResponseEvent evento)
	{
	}
	public void processRequest(RequestEvent evento)
	{
            try
            {
                if (evento.getRequest().getMethod().equals(Request.INVITE))
                    processarInvite(evento);
                else if (evento.getRequest().getMethod().equals(Request.ACK))
                    processarAck(evento);
            }
            catch (Exception exc)
            {
                System.err.println (exc.toString());
                exc.printStackTrace();
            }
            
        }
        public void processarInvite (RequestEvent evento) throws Exception
        {
                Request requisicao = evento.getRequest();
                System.out.println ("Mensagem recebida: " + requisicao.getMethod() + " - " + requisicao.getSIPVersion());
            
                //Retirar e processar a mensagem SDP
                byte [] recebido = requisicao.getRawContent();
                SdpFactory sdpF = SdpFactory.getInstance();
                sdpRemoto = sdpF.createSessionDescription(new String (recebido));
                
                Response resposta = messageFactory.createResponse(200, requisicao);
                
                ToHeader toHeader = (ToHeader)resposta.getHeader(ToHeader.NAME);
                toHeader.setTag("1234"); //informação de controle em nível de aplicação
                
                Address address = addressFactory.createAddress("Server <sip:" + endLocal + ":" + portaLocal + ">");                
            	ContactHeader contactHeader = headerFactory.createContactHeader(address);
                resposta.addHeader(contactHeader);
                
                ContentTypeHeader content = headerFactory.createContentTypeHeader("application", "sdp");
                SessionDescription sdpEnviar = (SessionDescription) sdpRemoto.clone();                
                                
                resposta.setContent(sdpEnviar, content);
                
                SipProvider provedor = (SipProvider) evento.getSource();
                ServerTransaction st = evento.getServerTransaction();
                if (st == null)
                {                    
                    st = provedor.getNewServerTransaction(requisicao);
                }
                st.sendResponse(resposta);
                System.out.println ("200 OK enviado.");
                
        }
        public void processarAck (RequestEvent evento) throws Exception
        {
            System.out.println ("Recebi um ACK");
            
            String endereco = null;
            int porta = 0;
            String tipo = null;      
            
            endereco = sdpRemoto.getOrigin().getAddress();
            
            Vector medias = sdpRemoto.getMediaDescriptions(true);
            Enumeration enu = medias.elements();
            while (enu.hasMoreElements())
            {
                MediaDescription md = (MediaDescription)enu.nextElement();
                porta = md.getMedia().getMediaPort();
                tipo = md.getMedia().getMediaType();                
            }
            
            new ReceptorRTPSIP().iniciarRecepcao(endereco + ":" + porta, tipo);
        }    
}

