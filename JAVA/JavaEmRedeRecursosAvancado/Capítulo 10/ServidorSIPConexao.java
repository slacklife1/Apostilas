/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 10.6
*
*/


import javax.sip.*;
import javax.sip.message.*;
import javax.sip.address.*;
import javax.sip.header.*;
import java.util.*;

public class ServidorSIPConexao implements SipListener
{
        Dialog dialog;
        SipFactory sf;
        
        SipProvider udpP, tcpP, sp;
        
        String endLocal;
        final static int portaLocal = 5060;
        
        public static void main (String args[])
        {
            new ServidorSIPConexao();
        }
	public ServidorSIPConexao ()
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
                
                System.out.println ("Estou aguardando conexÃµes.");     
                
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
                System.err.println ("Erro resposta: " + exc.toString());
            }
            
        }
        public void processarInvite (RequestEvent evento) throws Exception
        {
                Request requisicao = evento.getRequest();
                System.out.println ("Mensagem recebida: " + requisicao.getMethod() + " - " + requisicao.getSIPVersion());
            
                MessageFactory mF = sf.createMessageFactory();
                AddressFactory addressFactory = sf.createAddressFactory();
                HeaderFactory headerFactory = sf.createHeaderFactory();                
                
                Response resposta = mF.createResponse(180, requisicao);
                
                ToHeader toHeader = (ToHeader)resposta.getHeader(ToHeader.NAME);
                toHeader.setTag("9999");
                
                Address address = addressFactory.createAddress("Server <sip:" + endLocal + ":" + portaLocal + ">");                
            	ContactHeader contactHeader = headerFactory.createContactHeader(address);
                resposta.addHeader(contactHeader);
                
                SipProvider provedor = (SipProvider) evento.getSource();
                ServerTransaction st = evento.getServerTransaction();
                if (st == null)
                {                    
                    st = provedor.getNewServerTransaction(requisicao);
                }
                st.sendResponse(resposta);
                System.out.println ("180 enviado.");
                
                
                resposta = mF.createResponse(200, requisicao);
                
                toHeader = (ToHeader)resposta.getHeader(ToHeader.NAME);
                toHeader.setTag("9999");
                
                address = addressFactory.createAddress("Server <sip:" + endLocal + ":" + portaLocal + ">");                
            	contactHeader = headerFactory.createContactHeader(address);
                resposta.addHeader(contactHeader);                
                
                st.sendResponse(resposta);
                System.out.println ("Resposta enviada.");
                
        }
        public void processarAck (RequestEvent evento)
        {
            System.out.println ("Recebi um ACK");
        }    
}

