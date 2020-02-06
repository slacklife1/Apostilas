<?

/*
  Fun��o converte_data
  Autor : Adir Amaral - Taober.com.br
  Data  : 18/11/2002
  Vers�o: 1.0

Esta fun��o n�o necessita de par�metros
ela converte a data automaticamente no
padr�o americano para brasileiro e vice-versa
basta usar assim:

echo converte_data("data_a_converter");

*/

function converte_data($data){
	if (strstr($data, "/")){
		$A = explode ("/", $data);
		$V_data = $A[2] . "-". $A[1] . "-" . $A[0];
	}
	else{
		$A = explode ("-", $data);
		$V_data = $A[2] . "/". $A[1] . "/" . $A[0];	
	}
	return $V_data;
}
?>