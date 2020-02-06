/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 7.8
*
*/


import org.snmp4j.*;
import org.snmp4j.smi.*;
import org.snmp4j.mp.*;
import org.snmp4j.transport.*;
import org.snmp4j.event.*;

public class PrimeiroExemploSNMP
{

    public static void main (String args[])
    {
        try
        {
	    String remoto = "www.java.br/161";
         
            TransportMapping transport = new DefaultUdpTransportMapping();
            Snmp snmp = new Snmp(transport);
            snmp.listen();
            
            PDU pdu = new PDU();
            pdu.setType(PDU.GETNEXT);
            pdu.add(new VariableBinding(new OID("1.3.6.1.2.1.1.5")));
            
            Address endereco = GenericAddress.parse(remoto);
            CommunityTarget target = new CommunityTarget();
            target.setCommunity(new OctetString("public"));
            target.setAddress(endereco);
            target.setVersion(SnmpConstants.version1);
				
            ResponseEvent resposta = snmp.send(pdu, target);
            
            PDU PDUResposta = resposta.getResponse();
            System.out.println("Resposta: " + PDUResposta);
	}
        catch (Exception exc)
        {
            System.err.println (exc.toString());
        }
    }
}