/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 10.7
*
*/


import javax.sip.*;
import javax.sip.message.*;
import javax.sip.address.*;
import javax.sip.header.*;
import java.util.*;
import javax.sdp.*;
import javax.swing.JOptionPane;

public class ClienteSIPMedia implements SipListener
{
    String endLocal = null;
    String endDestino = null;
               
    int portaLocal = 5060;
    int portaDestino = 5060;
    int portaPacotesAudio = 9999;
    
    String fromName = "Daniel";
    String fromDisplayName = "Daniel G. Costa";    
    String toUser = "Java Man";
    String toDisplayName = "O Grande!";
    
    SipFactory sf;
    
    SipProvider udpP, tcpP, sp;
    
    HeaderFactory headerFactory;
    AddressFactory addressFactory;
    MessageFactory messageFactory;
    
          
    public static void main (String args[])
    {
        new ClienteSIPMedia();
    }
    public ClienteSIPMedia ()
    {       
        try
        {                
            endLocal = java.net.InetAddress.getLocalHost().getHostAddress();
            endDestino = JOptionPane.showInputDialog ("Digite o endereço do UAS", null);
        
            sf = SipFactory.getInstance();
            sf.setPathName ("gov.nist");
		
            Properties prop = new Properties ();
                
            prop.setProperty ("javax.sip.STACK_NAME", "cliente");            
					
            SipStack pilhaSip = sf.createSipStack (prop);            
                		
            ListeningPoint esperarTcp = pilhaSip.createListeningPoint (endLocal, portaLocal, "tcp");
            tcpP = pilhaSip.createSipProvider (esperarTcp);
            tcpP.addSipListener (this);
            
            ListeningPoint esperarUdp =  pilhaSip.createListeningPoint (endLocal, portaLocal, "udp");
            udpP = pilhaSip.createSipProvider (esperarUdp);
            udpP.addSipListener (this);            
            
            headerFactory = sf.createHeaderFactory();
            addressFactory = sf.createAddressFactory();
            messageFactory = sf.createMessageFactory();
            
            sp = udpP;
                    
            enviarMensagem ();
        }
        catch (Exception exc)
	{
            System.out.println (exc.toString());
            exc.printStackTrace();
            System.exit (-1);
	}
    }
    public void enviarMensagem () throws Exception
    {        
	SipURI fromAddress = addressFactory.createSipURI(fromName, endLocal + ":" + portaLocal);      
        Address fromNameAddress = addressFactory.createAddress(fromAddress);            
	fromNameAddress.setDisplayName(fromDisplayName);
	FromHeader fromHeader = headerFactory.createFromHeader(fromNameAddress, "clientemedia");
				
        SipURI toAddress = addressFactory.createSipURI(toUser, endDestino + ":" + portaDestino);
        Address toNameAddress = addressFactory.createAddress(toAddress);
	toNameAddress.setDisplayName(toDisplayName);
	ToHeader toHeader = headerFactory.createToHeader(toNameAddress, null);

        SipURI enderecoDestino = addressFactory.createSipURI(toUser, endDestino + ":" + portaDestino);
        enderecoDestino.setTransportParam("udp");

	ArrayList viaHeaders = new ArrayList();                
        ViaHeader viaHeader = headerFactory.createViaHeader(endDestino,portaDestino,"udp",null);
	viaHeaders.add(viaHeader);      
		
        Request request = messageFactory.createRequest(enderecoDestino,Request.INVITE,
		sp.getNewCallId(), headerFactory.createCSeqHeader((long)1, Request.INVITE),
		fromHeader, toHeader, viaHeaders, headerFactory.createMaxForwardsHeader(70));
                      
                               
	SipURI contato = addressFactory.createSipURI(fromName, endLocal);
        contato.setPort(portaLocal);
	
        Address contactAddress = addressFactory.createAddress(contato);
        contactAddress.setDisplayName(fromName);
	ContactHeader contactHeader = headerFactory.createContactHeader(contactAddress);
        
	request.addHeader(contactHeader);		
        
        ContentTypeHeader contentTypeHeader = headerFactory.createContentTypeHeader("application", "sdp");
        
        SessionDescription sdp = criarSDP ();              
	request.setContent(sdp, contentTypeHeader);
        
	ClientTransaction con = sp.getNewClientTransaction(request);        
        con.sendRequest();

        System.out.println ("INVITE enviado.");
    }
    public SessionDescription criarSDP () throws Exception
    {
        SdpFactory sdpF = SdpFactory.getInstance();
        SessionDescription sessionDesc = sdpF.createSessionDescription();
        Vector medias = sessionDesc.getMediaDescriptions(true);
        int codecs [] = {0};
        
        MediaDescription mDesc = sdpF.createMediaDescription("audio",9999, 1, "RTP/AVP", codecs);
        Vector atributos = mDesc.getAttributes(true);
        atributos.add (sdpF.createAttribute("rtpmap", "0 pcmu/8000/1"));
        mDesc.setAttributes(atributos);
        
        medias.add(mDesc);        
        sessionDesc.setMediaDescriptions(medias);
        
        return sessionDesc;
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
        try
        {
            Response resposta = evento.getResponse();
            
            if (resposta.getStatusCode() == Response.OK)
            {  
                Dialog dl = evento.getClientTransaction().getDialog();
		Request ackRequest = dl.createAck(1);
		dl.sendAck(ackRequest);                
                
                System.out.println ("Enviei ACK");
                
                new EmissorRTPSIP().iniciarTransmissao(endDestino + ":" + portaPacotesAudio, "audio");
            }
            
        }
        catch (Exception exc)
        {
            System.err.println(exc.toString());
            exc.printStackTrace();
        }
    }
    public void processRequest(RequestEvent evento)
    {
    }
}