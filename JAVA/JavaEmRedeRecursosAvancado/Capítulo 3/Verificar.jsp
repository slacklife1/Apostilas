<!--
* Java em Rede: Recursos Avan�ados de Programa��o
*
* Daniel G. Costa
*
* Exemplo 3.14
*
-->


<html>
	<head>
		<title>Verificar</title>
	</head>
	
	<body>

		<%@ page language="java" %>

		<%

			out.print ("Endere�o do cliente: " + request.getRemoteAddr() + "<br>");
			out.print ("Porta do cliente: " + request.getRemotePort() + "<br>");
			out.print ("Protocolo utilizado: " + request.getProtocol() + "<br>");
			out.print ("M�todo HTTP utilizado: " + request.getMethod() + "<br>");

			String parametro = request.getParameter ("numero");

			if (parametro != null)
			        out.print ("Par�metro passado: " + parametro);

		%>

	</body>
</html>
