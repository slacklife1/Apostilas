/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 3.9
*
*/


import javax.servlet.*;
import javax.servlet.http.*; 
import java.io.*;
	
public class CalculadoraCookie extends HttpServlet 
{

    public void doPost (HttpServletRequest pedido, HttpServletResponse resposta) throws ServletException, IOException
    {

        String recebido = pedido.getParameter ("numero");
	int num = Integer.parseInt (recebido);

	Cookie novoCookie = new Cookie ("anterior", String.valueOf (num));

	resposta.setContentType("text/html");
	resposta.addCookie (novoCookie);

	PrintWriter retorno = resposta.getWriter();

	StringBuffer saida = new StringBuffer();
	saida.append ("<html>\n<head>\n<title>Testando Cookies</title> \n<body>");
	saida.append ("<h3>A raiz quadrada do número " + num + " é " + Math.sqrt (num) + "</h3>\n");  		

	Cookie cookieRecebido [] = pedido.getCookies(); 

	if (cookieRecebido != null)
	{
            for (int i=0; i < cookieRecebido.length;i++)
	    {
	        if (cookieRecebido[i].getName().equals ("anterior"))
		    retorno.println ("<h4>O último número para cálculo foi " + Integer.parseInt  (cookieRecebido[i].getValue()) + "</h4>\n");
	    }
	} 

	saida.append ("</body>\n</html>");
	retorno.println (saida.toString());
	retorno.close(); 
    }
}
