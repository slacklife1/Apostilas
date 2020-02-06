/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 10.5
*
*/


import javax.sip.*;
import javax.sip.message.*;
import javax.sip.address.*;
import javax.sip.header.*;
import java.util.*;

public class ClienteSIPConexao implements SipListener
{
    String endLocal = null;
    String endDestino = null;
               
    int portaLocal = 5060;
    int portaDestino = 5060;
    
    String fromName = "Daniel";
    String fromDisplayName = "Daniel G. Costa";
    String toUser = "Bill Gates";
    String toDisplayName = "Bill";
    
    SipFactory sf;
    
    SipProvider udpP, tcpP, sp;
    
    Dialog dialog;
    
          
    public static void main (String args[])
    {
        new ClienteSIPConexao();
    }
    public ClienteSIPConexao ()
    {       
        try
        {                
            endLocal = java.net.InetAddress.getLocalHost().getHostAddress();
            endDestino = "200.123.45.207";
        
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
        HeaderFactory headerFactory = sf.createHeaderFactory();
        AddressFactory addressFactory = sf.createAddressFactory();
        MessageFactory messageFactory = sf.createMessageFactory();

	SipURI fromAddress = addressFactory.createSipURI(fromName, endLocal + ":" + portaLocal);      
        Address fromNameAddress = addressFactory.createAddress(fromAddress);            
	fromNameAddress.setDisplayName(fromDisplayName);
	FromHeader fromHeader = headerFactory.createFromHeader(fromNameAddress, "clienteteste");
				
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
		
        String texto = "Esse eh apenas um texto de exemplo.";
        ContentTypeHeader contentTypeHeader = headerFactory.createContentTypeHeader("text", "plain");
                                
	request.setContent(texto.getBytes(), contentTypeHeader);        
        
	ClientTransaction con = sp.getNewClientTransaction(request);              
        dialog = con.getDialog();
        con.sendRequest();

        System.out.println ("INVITE enviado.");
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
            System.out.println ("Mensagem recebida: " + resposta.getStatusCode());
           
            MessageFactory mF = sf.createMessageFactory();
            AddressFactory addressFactory = sf.createAddressFactory();
            HeaderFactory headerFactory = sf.createHeaderFactory();               
               
            if (resposta.getStatusCode() == Response.OK)
            {  
                Dialog dl = evento.getClientTransaction().getDialog();
		Request ackRequest = dl.createAck(1);
		dl.sendAck(ackRequest);                
                
                 System.out.println ("Enviei ACK");                
            }
            
        }
        catch (Exception exc)
        {
            System.err.println("E agora?: " + exc.toString());
            exc.printStackTrace();
        }
    }
    public void processRequest(RequestEvent evento)
    {
    }
}