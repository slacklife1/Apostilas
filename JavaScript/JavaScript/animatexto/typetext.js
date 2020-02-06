<html>
<body>
<span id="typing">Pluto is the ninth planet in the solar system. Discovered in 1930 and immediately classified as a planet, its status is currently under dispute. Pluto has an eccentric orbit that is highly inclined in respect to the other planets and takes it inside the orbit of Neptune. Its largest moon is Charon, discovered in 1978; two smaller moons were discovered in 2005.</span>

<script type="text/javascript">

/****************************************************
* Typing Text script- Dy Trey @ Dynamic Drive Forums
* Visit Dynamic Drive for this script and more: http://www.dynamicdrive.com
* This notice MUST stay intact for legal use
****************************************************/

interval = 100; // Interval in milliseconds to wait between characters

if(document.getElementById) {
t = document.getElementById("typing");
if(t.innerHTML) {
typingBuffer = ""; // buffer prevents some browsers stripping spaces
it = 0;
mytext = t.innerHTML;
t.innerHTML = "";
typeit();
}
}

function typeit() {
mytext = mytext.replace(/<([^<])*>/, ""); // Strip HTML from text
if(it < mytext.length) {
typingBuffer += mytext.charAt(it);
t.innerHTML = typingBuffer;
it++;
setTimeout("typeit()", interval);
}
}
</script>
</body>
</html>