<!--
* Java em Rede: Recursos Avan�ados de Programa��o
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

		<%-- Aqui a informa��o � criada apenas uma vez, mesmo em acessos sucessivos --%>

		<%! int cont=0; %> 

		O valor de cont � <%= ++cont%>

	</body>
</html>