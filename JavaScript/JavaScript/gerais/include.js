<script type="text/javascript">

/***********************************************
* Ajax Rotating Includes script- © Dynamic Drive DHTML code library (www.dynamicdrive.com)
* This notice MUST stay intact for legal use
* Visit Dynamic Drive at http://www.dynamicdrive.com/ for full source code
***********************************************/

//To include a page, invoke ajaxinclude(files_array, "ROTATETYPE") in the BODY of page.
//* file_array is the name of the array containing your list of files to include.
//* For "ROTATETYPE", valid values are "dailyw", "dailym", and "random", for each day of the week, each day of the month, and random, respectively.
//* Included file MUST be from the same domain as the page displaying it.

//Enter path to list of files to display.
//For rotatetype="dailyw", there must be 7 files, and for "dailym", 31 files. Otherwise, no restriction:

var includefiles=["ajaxfiles/file.htm", "ajaxfiles/file2.htm", "ajaxfiles/file3.htm", "ajaxfiles/file4.htm", "ajaxfiles/file5.htm", "ajaxfiles/file6.htm", "ajaxfiles/file7.htm"]

var rootdomain="http://"+window.location.hostname

function ajaxinclude(files_array, rotatetype){
var page_request = false
if (window.XMLHttpRequest) // if Mozilla, Safari etc
page_request = new XMLHttpRequest()
else if (window.ActiveXObject){ // if IE
try {
page_request = new ActiveXObject("Msxml2.XMLHTTP")
} 
catch (e){
try{
page_request = new ActiveXObject("Microsoft.XMLHTTP")
}
catch (e){}
}
}
else
return false
var url=choosefile(files_array, rotatetype)
if (typeof files_array[url]=="undefined"){
document.write("Error: No file for this day has been found.")
return
}
else
url=files_array[url]
page_request.open('GET', url, false) //get page synchronously 
page_request.send(null)
writecontent(page_request)
}

function writecontent(page_request){
if (window.location.href.indexOf("http")==-1 || page_request.status==200)
document.write(page_request.responseText)
}

function choosefile(files_array, rotatetype){
var today=new Date()
var selectedfile=(rotatetype=="dailyw")? today.getDay() : rotatetype=="dailym"? today.getDate() : Math.floor(Math.random()*files_array.length)
if (rotatetype=="dailyw" && selectedfile==0) //if display type=="week days" and today is Sunday 
selectedfile=7
if (rotatetype=="dailyw" || rotatetype=="dailym")
selectedfile--  //remove 1 to sync with array index
return selectedfile
}

</script>