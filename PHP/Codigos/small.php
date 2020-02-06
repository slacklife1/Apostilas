    //**************************************
    //     
    // Name: A Small Oracle Class
    // Description:a small oracle class with
    //     OCI easy to manipulate Oracle database b
    //     y Likai
    // By: PHP Code Exchange
    //**************************************
    //     
    
    <?PHP
    /* 
    Defination of ORACLE db CLASS and ORACLE query CLASS
    Author: Likai
    */
    if ( !defined( "_ORACLE_CLASS" ) )
    {
    define("_ORACLE_CLASS", 1 );
    /* 
    ORACLE database class 
    function open :open oraclass database connection 
    function close: close the database connection and free the smtm
    function addqury: add the smtm ready for free
    */
    class ora_db
    {
    var $connect_id; 
    
    //function to open ORACLE database
    function open($database, $user, $password) 
    {
    $this->connect_id = OCILogon($user, $password, $database); 
    if( $this->connect_id )
    return $this->connect_id;
    else
    return FALSE;
    }
    
    
    // Closes the database connection and fr
    //     ees any query results left.
    function close()
    {
    if($this->stmt_id && is_array($this->stmt_id))
    {
    while (list($key,$val)=each($this->stmt_id))
    {
    @OCIFreeStatement($val) ;
    }
    }
    $result = OCILogoff($this->connect_id); 
    return$result; 
    }
    
    // Function used by the constructor of q
    //     uery.
    function addstmt($stmt_id)
    {
    $this->stmt_id[]=$stmt_id;
    }
    }
    
    /* End of Defination of ORACLE db Class */
    /* 
    Defination of ORACLE query Class 
    
    */
    class ora_query
    {
    var $row;
    var $smtm;
    var $bind_data;
    
    //new a query and directly execute the n
    //     ormal query
    function ora_query(&$db, $query="")
    {
    if($query!=""&&$db->connect_id)
    {
    $this->stmt = OCIParse($db->connect_id, $query); 
    if (!$this->stmt)
    { 
    return false; 
    } 
    if (OCIExecute($this->stmt)) 
    { 
    $db->addstmt($this->stmt);
    return $this->stmt; 
    } 
    OCIFreeStatement($this->stmt); 
    return false; 
    }
    else
    return FALSE;
    }
    /* 
    before execute the query ,BIND the query with the php extern variables 
    for example $query = "insert into ? values(?,'?',?,0)
    then the function analye the string 
    */
    function prepare(&$db,$query="")
    {
    $pieces = explode( "?", $query); 
    $new_query = ""; 
    $last_piece = sizeof($pieces) - 1; 
    while (list($i, $piece) = each($pieces)) 
    { 
    $new_query .= $piece; 
    if ($i < $last_piece) 
    { 
    $new_query .= ":var$i"; 
    } 
    } 
    print "<br>new_query=$new_query\n<br>";
    //for debug
    $this->stmt = OCIParse($db->connect_id, $new_query); 
    if (!$this->stmt) 
    { 
    return false; 
    } 
    for ($i = 0; $i < $last_piece; $i++) 
    { 
    $bindvar = ":var$i"; 
    if (!OCIBindByName($this->stmt, $bindvar, &$this->bind_data[$i],32))
    { 
    	OCIFreeStatement($this->stmt); 
    return FALSE;
    } 
    } 
    return $this->stmt; 
    }
    //after prepare query then execute the q
    //     uery
    function execute(&$db,$data)
    {
    while (list($i, $value) = each($data)) 
    { 
    $this->bind_data[$i] = $data[$i]; 
    	 echo $this->bind[$i];
    } 
    if (OCIExecute($this->stmt)) 
    { 
    $db->addstmt($this->stmt);
    return $this->stmt;
    	}
    return FALSE;
    }
    // fetch the next row of stmt
    function getrow()
    { 
    if(!OCIFetchInto($this->stmt, &$this->row,OCI_ASSOC)) 
    { 
    return FALSE;
    } 
    	var_dump($this->row);
    return $this->row;
    } 
    // get the number of rows of $stmt
    function numrows()
    {
    $number=OCIRowCount($this->stmt) ;
    return $number;
    }
    //get oracle runtime error 
    function error()
    {
    $error=OCIError($this->stmt);
    if( $error )
    return $errot;
    else
    return OCIError($db->connect_id);
    }
    
    
    }
    
    
    /* End of Defination of ORACLE query Class */
    }
    /*End ifdefined */
    //example:
    $DB = new ora_class;
    $DB->open("","scott","tiger");
    $q = "Select * from scott.emp";
    $test_query = new ora_query($DB,$q);
    while($test_query->getrow())
    {
    echo "<br>".$test_query->row["JOB"];
    }
    $q = "Insert into testtable values(?,?,?,?);
    $data[] = "something";
    $data[] = "something";
    $data[] = "something";
    $data[] = "something";
    $test1_query->prepare($DB,$q);
    $test1_query->execute($DB,$data);
    ?>

