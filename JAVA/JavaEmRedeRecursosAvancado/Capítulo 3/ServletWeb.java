/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 3.3
*
*/


import javax.servlet.*;
import javax.servlet.http.*; 
import java.io.*;

public class ServletWeb extends HttpServlet 
{

    public void doGet (HttpServletRequest pedido, HttpServletResponse resposta) throws ServletException, IOException
    {
         
    	resposta.setContentType("text/html");
        PrintWriter out = resposta.getWriter();

	out.print ("<html>");
	out.print ("<head>");
	out.print ("<title>Servlet</title>");
        out.print ("</head>");
        out.print ("<body>");
        out.print ("<h3>Servlet HTTP</h3>");
        out.print ("</body>"); 
        out.print ("</html>"); 
      
      	out.close(); 
   }
}

