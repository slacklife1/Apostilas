/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 3.8
*
*/


import javax.servlet.*;
import javax.servlet.http.*; 
import java.io.*;

public class ServletCodigos extends HttpServlet 
{
 
    public void doPost (HttpServletRequest pedido,HttpServletResponse resposta) throws ServletException, IOException
    {

        try
	{
            String recebido = pedido.getParameter ("numero");
            int num = Integer.parseInt (recebido);

            if (num == 25)
            {
		resposta.sendError (404, "25");
            }
            else
            {
            	resposta.setContentType("text/html");

		PrintWriter retorno = resposta.getWriter();

		StringBuffer saida = new StringBuffer();
        	saida.append ("<html>\n<head>\n<title>Método POST</title>\n<body>");
                saida.append ("<h3>A raiz quadrada do número " + num + " é "  + Math.sqrt (num)); 
	        saida.append ("</h3>\n</body>\n</html>");
        	retorno.println (saida.toString());
                 
	        retorno.close();
            } 
        }
        catch (NumberFormatException exc)
        {
            resposta.sendRedirect ("http://www.java.br/Calculadora.html");
        } 
   }
}