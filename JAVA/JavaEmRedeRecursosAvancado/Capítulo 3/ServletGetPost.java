/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 3.7
*
*/


import javax.servlet.*;
import javax.servlet.http.*; 
import java.io.*;

public class ServletGetPost extends HttpServlet 
{

    public void doPost (HttpServletRequest pedido,HttpServletResponse resposta) throws ServletException, IOException
    {
        try
	{
	    String recebido = pedido.getParameter ("numero");
            int num = Integer.parseInt (recebido);

	    resposta.setContentType("text/html");

	    PrintWriter retorno = resposta.getWriter();

	    StringBuffer saida = new StringBuffer();
            saida.append ("<html>\n<head>\n<title>Método POST</title>\n<body>");
            saida.append ("<h3>A raiz quadrada do número " + num + " é "  + Math.sqrt (num)); 
            saida.append ("</h3>\n</body>\n</html>");
            retorno.println (saida.toString());
                 
            retorno.close(); 
        }
        catch (NumberFormatException exc)
        {
            resposta.sendRedirect ("http://www.java.br/Calculadora.html");
        } 
    }

    public void doGet (HttpServletRequest pedido,HttpServletResponse resposta) throws ServletException, IOException
    {
        resposta.setContentType("text/html");

 	PrintWriter retorno = resposta.getWriter();
        retorno.println ("<html>\n<head>\n<title>Método GET</title>\n<body>");

	retorno.println   ("<h2>Protocolo utilizado: " + pedido.getProtocol () + "</h2>");
        retorno.println   ("<h2>Método utilizado: " + pedido.getMethod () + "</h2><br>");
	retorno.println  ("<h2>Endereço remoto: " + pedido.getRemoteAddr() + "</h2>");
        retorno.println  ("<h2>Porta remota: " + pedido.getRemotePort() + "</h2><br>");
        retorno.println  ("<h2>Endereço local: " + pedido.getLocalAddr() + "</h2>");
        retorno.println  ("<h2>Porta local: " + pedido.getLocalPort() + "</h2><br>");

	retorno.println ("</html></body>");

	retorno.close();
   }
}
