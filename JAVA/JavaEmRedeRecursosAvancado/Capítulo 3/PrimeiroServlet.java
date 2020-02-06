/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 3.1
*
*/


import javax.servlet.*;
import java.io.*;

public class PrimeiroServlet extends GenericServlet
{

    public void service (ServletRequest request, ServletResponse response)
    {
    	try
	{
            response.setContentType("text/plain");
	    PrintWriter out = response.getWriter();

	    out.print ("Bem vindo aos servlets");
	}
	catch (IOException exc)
	{
	    System.err.println (exc.toString());
	}
    }
}