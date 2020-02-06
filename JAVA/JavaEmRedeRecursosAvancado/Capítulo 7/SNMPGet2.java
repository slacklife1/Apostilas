/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 7.10
*
*/


import org.snmp4j.*;
import org.snmp4j.smi.*;
import org.snmp4j.mp.*;
import org.snmp4j.transport.*;
import org.snmp4j.event.*;
import javax.swing.JOptionPane;

public class SNMPGet2
{
 
    public static void main (String args[])
    {
        try
        {
            TransportMapping transport = new DefaultUdpTransportMapping();
            Snmp snmp = new Snmp(transport);
            snmp.listen();
            
            PDU pdu = new PDU();
            pdu.setType(PDU.GET);
            VariableBinding vb = new VariableBinding(SnmpConstants.sysDescr);
            pdu.add(vb);
            vb = new VariableBinding(SnmpConstants.sysName);
            pdu.add(vb);
            vb = new VariableBinding(SnmpConstants.sysLocation);
            pdu.add(vb);
            vb = new VariableBinding(SnmpConstants.sysUpTime);
            pdu.add(vb);
            
            String destino = JOptionPane.showInputDialog("Digite o endereço do elemento que será gerenciado.", null);
            Address endereco = GenericAddress.parse(destino + "/161");

            CommunityTarget target = new CommunityTarget();
            target.setCommunity(new OctetString("public"));
            target.setAddress(endereco);
            target.setVersion(SnmpConstants.version1);
            
            ResponseEvent resposta = snmp.send(pdu,target);
            PDU pduResposta = resposta.getResponse();
            System.out.println ("Descrição: " + pduResposta.get(0).getVariable());
            System.out.println ("Nome: " + pduResposta.get(1).getVariable());
            System.out.println ("Localização: " + pduResposta.get(2).getVariable());
            System.out.println ("Tempo de funcionamento do sistema: " + pduResposta.get(3).getVariable());
            
            snmp.close();
	}
        catch (Exception exc)
        {
            System.err.println (exc.toString());
        }
    }
}