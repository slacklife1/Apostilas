<?php 
// P�gina que faz conex�o ao banco 
include ('../../common_db.inc'); 

// Conex�o ao banco 
$conexao = db_connect(); 
  mysql_select_db("database", $conexao); 

// Nome da tabela a ter os registros paginados 
$tabela="menu"; 

// Verifica se a vari�vel de complementa��o de link esta vazia 
if($_REQUEST["pagina"]=="") { 
  $pagina="1"; 
}else{ 
     $pagina=$_REQUEST["pagina"]; 
} 

// quantidade de registro por pagina��o 
$maximo="2"; 

// Vari�veis de contagem de registro 
$inicio=$pagina-1; 
$inicio=$maximo*$inicio; 

// sele��o de registro com limita��o da vari�veis de contagem 
$sql=mysql_query("SELECT menu_id,titulo FROM $tabela LIMIT $inicio,$maximo"); 

// Mostragem dos dados 
while($dados=mysql_fetch_array($sql)) { 

   ## EXIBA OS DADOS AQUI 
   echo $dados['titulo']; 
   ?> 
   <br> 
<?php 
} 
?> 
<br> 

<?php 
// Calculando pagina anterior 
$menos=$pagina-1; 

// Calculando pagina posterior 
$mais=$pagina+1; 

// Calculos para a mostragem de paginas 
$p_ini=$mais-1; 
$p_ini=$maximo*$p_ini; 

// Querys para a mostragem de paginas 
$p_query=mysql_query("SELECT * FROM $tabela LIMIT $p_ini,$maximo"); 
$p_total=mysql_num_rows($p_query); 

// Mostragem de pagina 
if($menos>0) { 
   echo "<a href=\"?pagina=$menos\">:: anterior</a> "; 
} if($p_total>0) { 
   echo  "<a href=\"?pagina=$mais\">proxima ::</a>"; 
} 
?> 