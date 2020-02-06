<html>
<head>

<script language="javascript" src="xp_progress.js">

/***********************************************
* WinXP Progress Bar- By Brian Gosselin- http://www.scriptasylum.com/
* Script featured on Dynamic Drive- http://www.dynamicdrive.com
* Please keep this notice intact
***********************************************/

</script>

</head>

<body>

<script type="text/javascript">
createBar(300,15,'white',1,'black','blue',85,7);
</script>

</body>

</html>

<!--xp_progress.js-->

// xp_progressbar
// Copyright 2004 Brian Gosselin of ScriptAsylum.com

var w3c=(document.getElementById)?true:false;
var ie=(document.all)?true:false;
var N=-1;
var bars=new Array();

function createBar(w,h,bgc,brdW,brdC,blkC,speed,blocks){
if(ie||w3c){
var t='<div style="position:relative; overflow:hidden; width:'+w+'px; height:'+h+'px; background-color:'+bgc+'; border-color:'+brdC+'; border-width:'+brdW+'px; border-style:solid; font-size:1px;">';
t+='<span id="blocks'+(++N)+'" style="left:-'+(h*2+1)+'px; position:absolute; font-size:1px">';
for(i=0;i<blocks;i++){
t+='<span style="background-color:'+blkC+'; left:-'+((h*i)+i)+'px; font-size:1px; position:absolute; width:'+h+'px; height:'+h+'px; '
t+=(ie)?'filter:alpha(opacity='+(100-i*(100/blocks))+')':'-Moz-opacity:'+((100-i*(100/blocks))/100);
t+='"></span>';
}
t+='</span></div>';
document.write(t);
var bA=(ie)?document.all['blocks'+N]:document.getElementById('blocks'+N);
bA.blocks=blocks;
bA.w=w;
bA.h=h;
bars[bars.length]=bA;
setInterval('startBar('+N+')',speed);
}}

function startBar(bn){
var t=bars[bn];
t.style.left=((parseInt(t.style.left)+t.h+1-(t.blocks*t.h+t.blocks)>t.w)? -(t.h*2+1) : parseInt(t.style.left)+t.h+1)+'px';
}