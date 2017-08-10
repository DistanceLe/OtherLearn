<!DOCTYPE html>
<html>
<head>
	<title> Hello PHP</title>
</head>
<body>

<h1>My first PHP page</h1>

<?php
//输出语句
print("hello <br>");
echo "Hello World! <br>";

//单行注释
/*多行注释*/

//变量
$txt="hello World!";
$x=5;
$y=6;
$z=$x+$y;
echo $z;

//======================================
function myTest(){
	$y=10;
	$x=11;
	echo "inside variable x is: $x <br>";
	echo "inside variable y is $y <br>";
}
myTest();
echo "outside x is: $x <br>";
echo "outside y is: $y <br>";


//======================================
function myTestGlobal(){
	global $x, $y;
	$y=$x+$y;
}
myTestGlobal();
echo "global change y is: $y <br>";


//======================================
function myStaticTest(){
	static $s=0;
	echo "s = ", $s, "<br>";
	$s++;
}
myStaticTest();
myStaticTest();
myStaticTest();

//======================================
function myParamTest($a){
	echo "param: a = ", $a;
}
myParamTest(4);


?>

</body>
</html>