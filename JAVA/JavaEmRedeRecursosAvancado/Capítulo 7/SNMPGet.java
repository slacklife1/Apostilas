/*
* Java em Rede: Recursos Avan�ados de Programa��o
*
* Daniel G. Costa
*
* Exemplo 7.9
*
*/


import org.snmp4j.*;
import org.snmp4j.smi.*;
import org.snmp4j.mp.*;
import org.snmp4j.transport.*;
import org.snmp4j.event.*;

public class SNMPGet
{

    public static void main (String args[])
    {
        try
        {
            String remoto = "201.125.36.129/161";
            ResponseEvent resposta;
            Snmp snmp;
            
            OctetString comunidade = new OctetString("public");
            Address destino = new UdpAddress(remoto);
            TransportMapping transport = new DefaultUdpTransportMapping();
            transport.listen();
            snmp = new Snmp(transport);
            
            CommunityTarget target = new CommunityTarget();
            target.setCommunity(comunidade);
            target.setVersion(SnmpConstants.version1);
            target.setAddress(destino);
            target.setRetries(2);
            target.setTimeout(5000);
            
            PDU pdu = new PDU();
            pdu.add(new VariableBinding(new OID("1.3.6.1.2.1.1.3")));
            pdu.setType(PDU.GETNEXT);
            
            resposta = snmp.send(pdu,target);
            if(resposta != null)
            {
               PDU pduresponse = resposta.getResponse();
               String valor = pduresponse.getVariableBindings().firstElement().toString();

               if(valor.contains("="))
               {
                  int indice = valor.indexOf("=");
                  valor = valor.substring(indice+1, valor.length());
               }
               System.out.println ("Tempo de funcionamento do sistema: " + valor.trim());
            }
            else
            {
                System.out.println("Falha no acesso.");
            }

            snmp.close();
	}
        catch (Exception exc)
        {
            System.err.println (exc.toString());
        }
    }
}