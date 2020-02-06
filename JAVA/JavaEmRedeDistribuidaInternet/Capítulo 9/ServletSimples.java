/*
* Java em Rede
* Daniel Gouveia Costa
*
* Exemplo 9.1
*
*/

import javax.servlet.*;
import javax.servlet.http.*;
import java.io.*;

public class ServletSimples extends HttpServlet
{
  public void doGet (HttpServletRequest req, HttpServletResponse res) throws IOException, ServletException
  {
    res.setContentType ("text/html");
    PrintWriter saida = res.getWriter();
    saida.println ("<html>");
    saida.println ("<head>");
    saida.println ("<title>Teste</title>");
    saida.println ("</head>");
    saida.println ("<body>Teste de servlet!");
    saida.println ("</body>");
    saida.println ("</html>");
    saida.close();
  }
}