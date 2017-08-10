<!DOCTYPE html>
<html>
<head>
	<title>PHP 2</title>
</head>
<body>

<?php

//布尔类型
$x=true;
$y=false;

//数组
$cars=array("volvo", "bmw", "toyota");

//对象
class Car{
	var $color;
	function Car($color = "green"){
		$this->color = $color;
	}

	function what_color(){
		return $this->color;
	}
}
function print_vars($obj) {
   foreach (get_object_vars($obj) as $prop => $val) {
     echo "\t$prop = $val\n";
   }
}

$herbie = new Car("white");
echo "Car's properties \n";
print_vars($herbie);

//null
$a="hello";
$a=null;
var_dump($a);

//返回类型和值
var_dump($cars);


//常量 是全局的, 最后的true 表示不区分大小写，默认为false
define("defineName", "isValue", true);
echo defineName;
echo definename;

//字符串
echo strlen("hello world!");
//返回第一个匹配的字符位置 0开始。如果未找到匹配，则返回 FALSE
echo strpos("hollo world!", "world");


//运算符
$test = "PHP 2";
$username = isset($test) ? $test : "nobody";

$username = $test ?: "nobody";

//PHP_EOL 是一个换行符，兼容更大平台。
echo "<br>", $username, PHP_EOL;

$myResult = false;
//与
myResult = x and y;
//或
myResult = x or y;
//异或 仅有一个为true
myResult = x xor y;
//与
myResult = x && y;



?>

</body>
</html>






