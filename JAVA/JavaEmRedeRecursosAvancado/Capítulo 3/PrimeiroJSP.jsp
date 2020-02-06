<!--
* Java em Rede: Recursos Avançados de Programação
*
* Daniel G. Costa
*
* Exemplo 3.11
*
-->


<html>
	<head>
		<title>Iniciando em JSP</title>
	</head>

	<body bgcolor="blue">

		<%@ page language="java" %>

		<%-- Aqui a informação é criada apenas uma vez, mesmo em acessos sucessivos --%>

		<%! int cont=0; %> 

		O valor de cont é <%= ++cont%>

	</body>
</html>