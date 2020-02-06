/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 7.11
*
*/


import org.snmp4j.*;
import org.snmp4j.smi.*;
import org.snmp4j.mp.*;
import org.snmp4j.transport.*;
import org.snmp4j.event.*;

public class SNMPGetbulk
{

    public static void main (String args[])
    {
        try
        {
            TransportMapping transport = new DefaultUdpTransportMapping();
            Snmp snmp = new Snmp(transport);
            snmp.listen();
            
            PDU pdu = new PDU();
            pdu.setType(PDU.GETBULK);
            pdu.add(new VariableBinding(new OID("1.3.6.1.2.1")));
            pdu.setMaxRepetitions(500);
            
            Address endereco = GenericAddress.parse("www.java.br/161");
            CommunityTarget target = new CommunityTarget();
            target.setCommunity(new OctetString("public"));
            target.setAddress(endereco);
            target.setVersion(SnmpConstants.version2c);
				
            ResponseEvent resposta = snmp.send(pdu, target);
             
            System.out.println ("Informações da MIB-2");

            for (Object variavel : resposta.getResponse().getVariableBindings())
            {
                System.out.println(variavel.toString());
            }
	}
        catch (Exception exc)
        {
            System.err.println (exc.toString());
        }
    }
}