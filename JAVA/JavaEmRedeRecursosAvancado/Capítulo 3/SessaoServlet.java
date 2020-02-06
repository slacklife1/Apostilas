/*
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 3.10
*
*/


import javax.servlet.*;
import javax.servlet.http.*; 
import java.io.*;

public class SessaoServlet extends HttpServlet 
{

    public void doPost (HttpServletRequest pedido,HttpServletResponse resposta) throws ServletException, IOException
    {
        String recebido = pedido.getParameter ("numero");
        int num = Integer.parseInt (recebido);

	HttpSession sessao = pedido.getSession (true);

	resposta.setContentType("text/html");

	PrintWriter retorno = resposta.getWriter();

        StringBuffer saida = new StringBuffer();
        saida.append ("<html>\n<head>\n<title>Testando HttpSession</title>\n<body>");
        saida.append ("<h3>A raiz quadrada do número " + num + " é: " + Math.sqrt (num)); 
        saida.append ("</h3>\n</body>\n</html>");
        retorno.println (saida.toString());

	Integer inteiro =  (Integer)sessao.getAttribute("valor"); 
        if (inteiro != null)
        	retorno.println ("O último valor fornecido foi " + inteiro.toString());
                 
        retorno.close(); 
                
        sessao.setAttribute ("valor", new Integer (num)); 
   }
}

