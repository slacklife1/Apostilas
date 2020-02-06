/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 3.6
*
*/


import javax.servlet.*;
import javax.servlet.http.*; 
import java.io.*;

public class ServletPost extends HttpServlet 
{

    public void doPost (HttpServletRequest pedido, HttpServletResponse resposta) throws ServletException, IOException
    {

        String recebido = pedido.getParameter ("numero");
        int num = Integer.parseInt (recebido);
 
 	resposta.setContentType("text/html");
        PrintWriter retorno = resposta.getWriter();

	StringBuffer saida = new StringBuffer();
        saida.append ("<html>\n<head>\n<title>Testando o POST HTTP</title>\n<body>");
        
	saida.append ("<h3>A raiz quadrada do numero " + num + " é: " + Math.sqrt (num)); 
	saida.append (“</h3>\n<br>\n”);
	saida.append (“<h4>O método HTTP usado foi: “ + pedido.getMethod());
	saida.append ("</h4>\n</body>\n</html>");  
	                
        retorno.println (saida.toString());
      
	retorno.close(); 
   }
}



