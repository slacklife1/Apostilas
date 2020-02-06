/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 7.7
*
*/


import javax.management.*;
import javax.management.remote.*;

public class GerenteProgramaNumero
{
 
    static public void main (String x[])
    {
        try
        {
            String endereco = "200.125.35.147:6789";
        	
            JMXServiceURL enderecoJMX = new JMXServiceURL("service:jmx:rmi:///jndi/rmi://" + endereco + "/jmxrmi");
            JMXConnector jmxConnector = JMXConnectorFactory.connect(enderecoJMX, null);
            MBeanServerConnection conexao = jmxConnector.getMBeanServerConnection();

            ObjectName nomeObjeto = new ObjectName ("AcessoNumero:type=Numero");
            NumeroMBean numero = JMX.newMBeanProxy(conexao, nomeObjeto, NumeroMBean.class, true);
            System.out.println ("Número: " + numero.getNumero());
        }
        catch (Exception exc)
        {
            System.err.println (exc.toString());
        }
    }    
}