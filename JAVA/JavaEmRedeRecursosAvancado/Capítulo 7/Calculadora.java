/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 7.6
*
*/


import java.lang.management.*;
import javax.management.*;

public class Calculadora
{
 
    public static void main(String[] args)
    {
        try
   	{
   	    MBeanServer mbs = ManagementFactory.getPlatformMBeanServer();
 
    	    ObjectName nomeObjeto = new ObjectName("calcular:type=calc");
 
      	    Calcular calc = new Calcular();
 
            mbs.registerMBean(calc, nomeObjeto);
 
      	    System.out.println("Programa iniciado. Aguardando acesso remoto.");
      	    
	    Thread.sleep(Long.MAX_VALUE);
        }
      	catch (Exception exc)
      	{
      	    exc.printStackTrace();
      	}
    }
}