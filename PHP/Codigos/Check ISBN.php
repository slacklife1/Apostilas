//**************************************
    //     
    // Name: Check ISBN
    // Description:Checks an entered isbn (w
    //     ith or without hyphens) to see if it is 
    //     valid. by Keith Nunn
    // By: PHP Code Exchange
    //**************************************
    //     
    
    <?php
    	/*
    	 *	Check to see if the entered isbn is valid and return
    	 *	true or false depending.
    	 *	I'm not even going to try to claim copyright for such 
    	 *	a simple thing. Do what you will with it. 
    	 *	8-) Keith Nunn, kapn@anglican.ca
    	 */
    	function checkisbn($isbn) {
    		$isbn10 = ereg_replace("[^0-9X]","",$isbn);
    		$checkdigit = 11 - ( ( 10 * substr($isbn10,0,1) + 9 * substr($isbn10,1,1) + 8 * substr($isbn10,2,1) + 7 * substr($isbn10,3,1) + 6 * substr($isbn10,4,1) + 5 * substr($isbn10,5,1) + 4 * substr($isbn10,6,1) + 3 * substr($isbn10,7,1) + 2 * substr($isbn10,8,1) ) % 11);
    		if ( $checkdigit == 10 ) $checkdigit = "X";
    		if ( $checkdigit == 11 ) $checkdigit = 0;
    		if ( $checkdigit == substr($isbn10,9,1) ) {
    			return true;
    		} else {
    			return false;
    		}
    	}
    ?>

