<html>

<head>
<style type="text/css">
.scroll {font-weight:bold; font-size:36; text-align: center; font-family: Verdana, Courier, Courier New;}
</style>
</head>

<body>

<script language="JavaScript1.2">
if (document.all)
document.write('<script src="sinescroll.js"><\/script>')
</script>

</body>
</html>
<!-- Source for sinescroll.js-->


// globals
var initialx, initialy, scrolltext;
var frame = 0, frame2 = 0.5;
var amplitude1 = 50, amplitude2 = 30;
var offset = 0.2, speed = 0.2, speed2 = 0.35;
var offset2 = 0.6;
var scrollspeed = 6;
var charwidth = 30;

var twopi = Math.PI * 2;
var chracters, position, numvisible, nextchar, firstchar;
var skipsteps = 1;
var delaytimer = 0;
var interval;

// function to create sine scroller
function sinescroll (x, y, value, number_of_chars)
{
    // setup globals
    scrolltext = new String(value);
    initialx = x;
    initialy = y;
    numvisible = number_of_chars;
    nextchar = numvisible;
    firstchar = 0;

    // create fixed-size arrays of characters and positions
    characters = new Array(numvisible);
    position = initialx;

    // write DIVs to hold characters
    for (var i = 0; i < numvisible; i++)
    {
        document.write('<DIV ID="character" STYLE="position:absolute;top:',
            initialy, ';left:-10000', //(initialx + i * charwidth),
            ';width=', charwidth, ';height=30;" ><p class=scroll>', 
            scrolltext.charAt(i), '</p></DIV>');
    }
}

// animation function
function step ()
{
    // increment counters
    frame += speed;
    frame2 += speed2;

    // delay timer
    if (delaytimer > 0)
    {
        delaytimer--;
    }
    else
    {
        // update position
        position -= scrollspeed;
    }

    // check for 'offscreen'
    if (position < (initialx - charwidth))
    {
        while (scrolltext.charAt(nextchar) == '|')
        {
            delaytimer += 90;
            nextchar++;
        }

        // set nextchar into characters array
        characters[firstchar].innerHTML = '<p class=scroll>' + scrolltext.charAt(nextchar) + '</p>';

        // update nextchar
        nextchar++;

        // check for wrap-around
        if (nextchar >= scrolltext.length)
        {
            nextchar = 0;
        }

        // change position and counters by offset
        position += charwidth;
        frame += offset;
        frame2 += offset2;

        // update firstchar
        firstchar++;

        if (firstchar >= numvisible)
        {
            firstchar = 0;
        }
    }

    // wrap-around counters
    if (frame > twopi) frame -= twopi;
    if (frame2 > twopi) frame2 -= twopi;

    // set up loop variables
    var angle = frame;
    var angle2 = frame2;
    var pos = position;

    // update the html
    for (var i=firstchar; i < numvisible; i++)
    {
        characters[i].style.left = pos;
        characters[i].style.top = initialy + amplitude1 * Math.sin(angle) + amplitude2 * Math.sin(angle2);
        angle += offset; 
        angle2 += offset2;
        pos += charwidth;
    }

    for (var i=0; i < firstchar; i++)
    {
        characters[i].style.left = pos;
        characters[i].style.top = initialy + amplitude1 * Math.sin(angle) + amplitude2 * Math.sin(angle2);
        angle += offset; 
        angle2 += offset2;
        pos += charwidth;
    }
}

// start the animation
function start ()
{
if (!document.all)
return
    // get all of the DIV tags into an array (IE only?)
    characters = document.all.item('character');
    
    // setup timeout to call this function again
    interval = window.setInterval("step();", 20);
}

// stop the animation
function stop ()
{
if (!document.all)
return
    if (interval)
        clearInterval(interval);
}

window.onload=start
window.onunload=stop


// create the scroller
if (document.all)
sinescroll(30, 100, " **** Remember those great Amiga demos? You can recreate the endless sine-scrolling messages in JavaScript! Conversions to Netscape welcome, as are improvements - email to mark.baker@usa.net This script can cope with ** delays ** | and even longer delays - ** heloooo **||| Feel free to use it and rip it off (well you're going to anyway...) TTFN... **** ", 15);