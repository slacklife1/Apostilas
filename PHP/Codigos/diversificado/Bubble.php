//**************************************
    //     
    // Name: Bubble Sort
    // Description:This is a simple bubbleso
    //     rt that takes 2 arrays as argument.The f
    //     irst one is the actual data used for sor
    //     ting, the second is data that will "tag 
    //     along" with the first array, for instanc
    //     e a descriptive text about the data in t
    //     he first array. by Petter Nilsen.
    // By: PHP Code Exchange
    //**************************************
    //     
    
    <?php
    function bubblesort($a1,$a2)
    {
    for($i = sizeof($a1); $i >= 1; $i--)
    {
    for($j = 1; $j <= $i; $j++)
    {
    if($a1[$j-1] > $a1[$j])
    {
    $t = $a1[$j-1];
    $t2 = $a2[$j-1];
    $a1[$j-1] = $a1[$j];
    $a2[$j-1] = $a2[$j];
    $a1[$j] = $t;
    $a2[$j] = $t2;
    }
    }
    }
    }
    ?>

