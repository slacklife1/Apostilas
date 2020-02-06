<?php 
function escreveData($data) 
{ 

$vardia = substr($data, 8, 2); 
$varmes = substr($data, 5, 2); 
$varano = substr($data, 0, 4); 

$convertedia = date ("w", mktime (0,0,0,$varmes,$vardia,$varano)); 

$diaSemana = array("Domingo", "Segunda-feira", "Ter�a-feira", "Quarta-feira", "Quinta-feira", "Sexta-feira", "S�bado"); 
      
$mes = array(1=>"Janeiro", "Fevereiro", "Mar�o", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"); 

return $diaSemana[$convertedia] . ", " . $vardia  . " de " . $mes[$varmes] . " de " . $varano; 
} 

?> 

<?php 
// Utilizar da seguinte maneira 
echo escreveData("2005-12-02"); 
// Ou passar o campo do banco de dados 
?> 