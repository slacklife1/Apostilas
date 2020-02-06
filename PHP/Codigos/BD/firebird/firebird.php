<?php 

  /*################################################################## 
  #                                                                  # 
  #           Desenvolvimento: Lib�rio de Oliveira J�nior            # 
  #                    junior@candoinet.com.br                       # 
  #                                                                  # 
  ##################################################################*/ 

  /*----------------------------------------------------------------*/ 
  # Conex�o com o Banco de dados 
  $host     = "localhost:D:\banco.gdb"; //-> Caminho do Banco de Dados 
  $username = "SYSDBA";                           //-> Usu�rio 
  $password = "masterkey";                        //-> Senha 
  $charset  = "ISO8859_1"; 
  $db       = ibase_connect($host, $username, $password,$charset) or die ("N�o foi poss�vel conectar com a base de dados!"); 

  /*----------------------------------------------------------------*/ 
  # CONSTANTES 
  $tabela    = "TABELA"; //-> Nome da Tabela 
  $total_reg = "10";    //-> N�mero de registros por p�gina 

  /*----------------------------------------------------------------*/ 
  # VARIAVEIS 
  if(!$pagina) 
    { 
      $pc   = "1";  //-> P�gina Nro 1 
      $skip = "0"; 
    } 
  else 
    { 
      $pc   = $pagina;  //-> Numero da p�gina 
      $skip = (($total_reg * $pagina) - $total_reg); //-> Pega o valor para o skip do SQL 
    } 

  /*----------------------------------------------------------------*/ 
  # Instrucoes SQL 
  $sql   = ibase_query($db,"SELECT FIRST $total_reg SKIP $skip * FROM $tabela"); 

  $count = ibase_query($db,"SELECT COUNT(*) FROM $tabela"); //-> Retorna  a qtd de registros 
  $count = ibase_fetch_object($count); 
  $tr    = $count->COUNT; 

  /*----------------------------------------------------------------*/ 
  # Retorna o Numero de Paginas 
  $resto = $tr % $total_reg;  //-> Retorna o resto da divis�o 

  if ($resto > 0) 
    $tp = intval($tr / $total_reg) + 1;  //-> Arredonda o valor da variavel 
  else 
    $tp = $tr / $total_reg; 

  /*----------------------------------------------------------------*/ 
  # Imprime os Registros 
  print("P�gina $pc de $tp<br> Total de registros: $tr<br><br>"); 

  while($dados = ibase_fetch_object($sql)) 
    { 
      $nome = $dados->NOME; 
      print("� $nome<br>"); 
    } 

  /*----------------------------------------------------------------*/ 
  # Barra de Navega��o 
  print("<br>P�ginas: "); 

  for ($pi;$pi <= $tp;$pi++) 
    { 
      if ($pc == $pi) 
        print("<b>$pi</b>&nbsp;"); 
      else 
        print("<b><a href='$PHP_SELF?pagina=$pi'>$pi</a></b>&nbsp;"); 
    } //for 

  /*----------------------------------------------------------------*/ 
  # Fecha a conex�o 
  ibase_close($db); 

?> 