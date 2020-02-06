/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 3.4
*
*/


import javax.servlet.*;
import javax.servlet.http.*; 
import java.io.*;

public class ServletWeb2 extends HttpServlet 
{

    public void doGet (HttpServletRequest pedido, HttpServletResponse resposta) throws ServletException, IOException
    {
         
	resposta.setContentType("text/html");
	PrintWriter retorno = resposta.getWriter();

	retorno.println ("<html>");
        retorno.println ("<head>");
                
        retorno.println ("<title>Outro servlet de exemplo</title>");
        retorno.println ("</head>");
        retorno.println ("<body>");

	retorno.println ("<font size=8 color=blue>Servlet HTTP</font>");
	
	int num = 8;
        retorno.println ("<h2 align=center>O quadrado de 8 é: " + Math.pow (num, 2) + "</h2>");
	
	retorno.println ("</body>"); 
        retorno.println ("</html>"); 
      
        retorno.close(); 
   }
}
