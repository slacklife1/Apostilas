<?
########################################################################################
#	- Script Desenvolvido por: Olavo Alexandrino									   #
#	- E-mail: oalexandrino@hotmail.com											       #
#	- Vers�o: 1.00																	   #
# 	- Vers�o Original: Diego Mascarenhas 											   #
#	  (http://www.phpbrasil.com/articles/article.php/pagerRow/0/id/245)				   #
########################################################################################


// Consulta
$busca = "SELECT valor FROM tabela"; 

// N�meros de Registros por p�gina
$registrosPorPagina = 10; 

// Valida��o para n�o exibir a p�gina 0
if (empty($pagina)):    $pc = 1; 	else:    $pc = $pagina; endif;

// Retorna os "$registrosPorPagina" at� o n�mero passado por "$pagina"
$inicio = $pc - 1; 
$inicio = $inicio * $registrosPorPagina; 

// Pesquisa da p�gina atual
$limite = mysql_query("$busca LIMIT $inicio,$registrosPorPagina"); 

// N�mero total de registros da tabela
$totalRegistros = mysql_num_rows(mysql_query("$busca")); 

// verifica o n�mero total de p�ginas 
$numPaginas = $totalRegistros / $registrosPorPagina; 

// Visualiza��o dos dados da Tabela
while (list($valor)=mysql_fetch_row($limite)) 
{ 
    echo "Valor: $valor<br>"; 
} 

// Bot�es anterior e pr�ximo
$anterior = $pc - 1; 
$proximo =  $pc + 1; 
if ($pc>1):     		echo " <a href='?pagina=$anterior'><< Anterior</a> "; 	endif;
if ($pc<$numPaginas):	echo " <a href='?pagina=$proximo'>Pr�xima >></a>"; 		endif;


echo "<br><br><br>";

// Links para todas as p�ginas
if (($totalRegistros%$registrosPorPagina!=0)):
	while($totalRegistros%$registrosPorPagina!=0){$totalRegistros++;}
endif;
echo "<strong>P�ginas</strong><br>";
for ($a=1;$a<=$totalRegistros;$a++)
{
	if ($a%$registrosPorPagina==0):
		$link = $a;
		$link /= $registrosPorPagina;	
		if ($link!=$pagina):
			echo " <a href='?pagina=$link".$link."'>$link</a>&nbsp;";
		else:
			echo " ::<strong>$link</strong>::&nbsp;";		
		endif;
		$aux++;
	endif;
}
?>
