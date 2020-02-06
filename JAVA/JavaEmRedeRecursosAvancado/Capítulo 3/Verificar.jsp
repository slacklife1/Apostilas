<!--
* Java em Rede: Recursos Avançados de Programação
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

			out.print ("Endereço do cliente: " + request.getRemoteAddr() + "<br>");
			out.print ("Porta do cliente: " + request.getRemotePort() + "<br>");
			out.print ("Protocolo utilizado: " + request.getProtocol() + "<br>");
			out.print ("Método HTTP utilizado: " + request.getMethod() + "<br>");

			String parametro = request.getParameter ("numero");

			if (parametro != null)
			        out.print ("Parâmetro passado: " + parametro);

		%>

	</body>
</html>
