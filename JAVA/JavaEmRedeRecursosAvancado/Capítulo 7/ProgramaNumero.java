/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 7.3
*
*/


import java.lang.management.*;
import javax.management.*;
 
public class ProgramaNumero
{
 
    public static void main(String[] args)
    {
        try
   	{
 	    MBeanServer mbs = ManagementFactory.getPlatformMBeanServer();
 
       	    ObjectName nomeObjeto = new ObjectName("AcessoNumero:type=Numero");
 
       	    Numero numero = new Numero();
 
            mbs.registerMBean(numero, nomeObjeto);
            
            System.out.println("Programa iniciado. Aguardando acesso remoto.");
      	    
      	    for (;;)
      	    {
  	        Thread.sleep (2000);
  		int novo = (int)(Math.random()*1000);
  		numero.setNumero (novo);
            }
      	 }
      	 catch (Exception exc)
      	 {
      	     exc.printStackTrace();
      	 }
    }
}