<?php
/******************************************************************************************************
Classe:    		Authentix
Vers�o:			1.02
Autor:     		Gustavo Sampaio Villa
E-mail:    		php@sitework.com.br
Site:      		www.sitework.com.br

Descri��o: 		O grande objetivo dessa classe � facilitar a valida��o de usu�rios
		   		para acesso � �reas restritas.
		   		N�o � necess�rio criar tabelas espec�ficas no banco de dados,
		   		nem mesmo fazer altera��es no Script.
		   
Fluxograma:		Para a utiliza��o dessa classe � necess�rio que voc� utilize um
				formul�rio com dados a serem preenchidos na ordem:
				Identifica��o do usu�rio, Senha e um bot�o de submit que enviar� os dados a
				outra rotina chamada autentica��o. O script armazena as informa��es e verifica se o usu�rio
				existe. Retorna True caso o usu�rio tenha sido autenticado e false caso n�o.
				
Descri��o: 		authUser($BDLogin, $BDSenha, $BDTabela, $LoginInformado, $senhaInformada);
				$BDLogin: Nome do campo do banco de dados que ser� usado para identificar o usu�rio
				$BDSenha: Nome do campo do banco de dados que cont�m a senha do usu�rio
				$BDTabela: Tabela do banco de dados onde esses campos est�o contidos
				$LoginInformado: String contendo o login informado pelo usu�rio
				$senhaInformada: String contendo a senha informada pelo usu�rio
				
Exemplo: 		$authUsr = new authUser("inst_Email", "inst_Senha", "tbl_Usuarios", $_POST["frmEmail"], $_POST["frmSenha"]);

******************************************************************************************************/

class authUser {
	
	var $bdUsr, $bdPwd, $bdTbl, $frmUsr, $frmPwd;


	/*
	authUser($bdUser, $bdPwd, $bdTbl, $frmUsr, $frmPwd)
	M�todo construtor que armazena as informa��es passadas
	*/
	function authUser($bdUser, $bdPwd, $bdTbl, $frmUsr, $frmPwd){
		$this->bdUsr  = $bdUser;
		$this->bdPwd  = $bdPwd;
		$this->bdTbl  = $bdTbl;
		$this->frmUsr = $frmUsr;
		$this->frmPwd = $frmPwd;
	}

	/*
	bool verifica()
	M�todo que faz a verifica��o se o login informado e a senha existem no banco de dados.
	Caso afirmativo e se nunhuma sess�o ainda foi criada, ele autentica o usu�rio.
	Retorna True caso o usu�rio tenha sido aprovado ou False caso tenha sido rejeitado.
	*/
	function verifica(){
		session_start();
		
		if (!isset($HTTP_SESSION_VARS["usuario"])){
			$sql   = "select ". $this->bdUsr ." from ". $this->bdTbl ." where ". $this->bdUsr ."='". $this->frmUsr ."' and ". $this->bdPwd ."='". $this->frmPwd ."'";
			$query = mysql_query($sql);
			$usuario = mysql_fetch_row($query);
			$count = mysql_num_rows($query);
			
			if ($count == 1){
				session_register("usuario");
				return(true);
			} else {
				return(false);
			}
		} else {
			return(true);
		}
	}	
}
?>