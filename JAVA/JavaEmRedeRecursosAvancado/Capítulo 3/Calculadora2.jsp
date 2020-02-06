<%--
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 3.13
*
--%>


<%@ page language="java" %>

<%!
	public int somar (int a, int b)
	{
	        return a + b;
	}
	public int subtrair(int a, int b)
	{
	        return a - b;
	}
	public int multiplicar (int a, int b)
	{
	        return a * b;
	}
	public int dividir (int a, int b)
	{
	        return a / b;
	}

%>

<%

	out.print ("<html><body>");
	out.print ("<h1>5 + 6 é igual a " + somar(5, 6) + "</h1>");
	out.print ("<h2>5 - 6 é igual a " + subtrair(5, 6)  + "</h2>");
	out.print ("<h3>5 * 6 é igual a " + multilicar(5, 6)  + "</h3>");
	out.print ("<h4>5 / 6 é igual a " + dividir(5, 6)  + "</h4>");
 
	out.print ("</body></html>");

%>