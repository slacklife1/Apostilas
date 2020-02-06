/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 10.3
*
*/


import javax.sip.*;
import javax.sip.message.*;
import javax.sip.address.*;
import javax.sip.header.*;
import java.util.*;
import javax.swing.JOptionPane;

public class ClienteSIPTexto implements SipListener
{
    String endLocal = null;
    String endDestino = null;
               
    int portaLocal = 5060;
    int portaDestino = null;
    
    String remetente = "Daniel G. Costa";
    String remetenteSIP = "danielgcosta@uefs.br"; 
    
    SipFactory sf;
    SipProvider sp;
    HeaderFactory headerFactory;
    AddressFactory addressFactory;
    MessageFactory messageFactory;
       
    public static void main (String args[])
    {
        new ClienteSIPTexto();
    }
    public ClienteSIPTexto ()
    {       
        try
        {                
            endLocal = java.net.InetAddress.getLocalHost().getHostAddress();        
        
            sf = SipFactory.getInstance();
            sf.setPathName ("gov.nist");
		
            Properties prop = new Properties ();
                
            prop.setProperty ("javax.sip.STACK_NAME", "gov.nist");
            prop.setProperty ("javax.sip.IP_ADDRESS", endLocal);
					
            SipStack pilhaSip = sf.createSipStack (prop);            
                		
            ListeningPoint esperarUdp =  pilhaSip.createListeningPoint (endLocal, portaLocal, "udp");
            sp = pilhaSip.createSipProvider (esperarUdp);
            sp.addSipListener (this);
            
            headerFactory = sf.createHeaderFactory();
            addressFactory = sf.createAddressFactory();
            messageFactory = sf.createMessageFactory();
                
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
        
        endDestino = JOptionPane.showInputDialog(null, "Digite o endereço de destino");
        portaDestino = Integer.parseInt (JOptionPane.showInputDialog(null, "Digite a porta de destino"));
        String mensagem = JOptionPane.showInputDialog(null, "Digite a mensagem a ser enviada");
        
	SipURI fromAddress = addressFactory.createSipURI(remetente, remetenteSIP);      
        Address fromNameAddress = addressFactory.createAddress(fromAddress);            
	fromNameAddress.setDisplayName(remetente);                
	FromHeader fromHeader = headerFactory.createFromHeader(fromNameAddress, null);
				
        SipURI toAddress = addressFactory.createSipURI(endDestino, endDestino);
        Address toNameAddress = addressFactory.createAddress(toAddress);
	toNameAddress.setDisplayName(endDestino);
	ToHeader toHeader = headerFactory.createToHeader(toNameAddress, null);

        SipURI enderecoDestino = addressFactory.createSipURI("destino", endDestino + ":" + portaDestino);

	ArrayList viaHeaders = new ArrayList();                
        ViaHeader viaHeader = headerFactory.createViaHeader(endDestino,portaDestino,"udp",null);
	viaHeaders.add(viaHeader);
		
        ContentTypeHeader contentTypeHeader = headerFactory.createContentTypeHeader("text", "plain");
		
        Request request = messageFactory.createRequest(enderecoDestino,Request.MESSAGE,
		sp.getNewCallId(), headerFactory.createCSeqHeader((long)1, Request.MESSAGE),
		fromHeader, toHeader, viaHeaders, headerFactory.createMaxForwardsHeader(70));
                      
                               
	SipURI contato = addressFactory.createSipURI(remetente, endLocal);

	Address contactAddress = addressFactory.createAddress(contato);

	ContactHeader contactHeader = headerFactory.createContactHeader(contactAddress);
	request.addHeader(contactHeader);       
                                
	request.setContent(mensagem, contentTypeHeader);

	sp.sendRequest(request);

        System.out.println ("Mensagem enviada.");	
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
    }
}