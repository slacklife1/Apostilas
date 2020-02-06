/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 10.4
*
*/


import javax.sip.*;
import javax.sip.message.*;
import javax.sip.address.*;
import javax.sip.header.*;
import java.util.*;

public class ServidorSIPTexto implements SipListener
{
        SipStack pilhaSip;
        SipFactory sf;
       
        static String endLocal;             
        final static int portaLocal = 5060;      
       
        public static void main (String args[])
        {
            new ServidorSIPTexto();
        }
        public ServidorSIPTexto ()
  	{	
            try
            {                
		sf = SipFactory.getInstance();
		sf.setPathName ("gov.nist");
	
		Properties prop = new Properties ();
                
      	        endLocal = java.net.InetAddress.getLocalHost().getHostAddress();                     
                
		prop.setProperty ("javax.sip.STACK_NAME", "gov.nist");
				
		pilhaSip = sf.createSipStack (prop);                     
	
                ListeningPoint esperarUdp =  pilhaSip.createListeningPoint (endLocal, portaLocal, "udp");
		SipProvider sp = pilhaSip.createSipProvider (esperarUdp);
		sp.addSipListener (this);       
                
                System.out.println ("Aguardando solicitacoes SIP.");                
            }
            catch (Exception exc)
            {
		System.out.println (exc.toString());
		exc.printStackTrace();
                System.exit (-1);
            }
	}
	public void processRequest(RequestEvent evento)
	{
            Request requisicao = evento.getRequest();  
             
            System.out.println ("\nTexto recebido: " + new String (requisicao.getRawContent()));
             
            System.out.println ("\nTipo da mensagem SIP: " + requisicao.getMethod());
             
            System.out.println ("\nMensagem SIP recebida:\n" + requisicao.toString());
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
}
