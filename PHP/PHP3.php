<!DOCTYPE html>
<html>
<head>
	<title>PHP 3</title>
</head>
<body>

<?php

//数组
$cars=array("volvo", "bmw", "toyota");
$arrlength=count($cars);

for ($x=0; $x < $array; $x++) { 
	echo $cars[$x], "<br>";
}

$age=array("Peter"=>"35","Ben"=>"37","Joe"=>"43");
foreach ($age as $key => $value) {
	echo "key = $key, value = $value <br>";
}

/*
    sort() - 对数组进行升序排列
    rsort() - 对数组进行降序排列
    asort() - 根据关联数组的值，对数组进行升序排列
    ksort() - 根据关联数组的键，对数组进行升序排列
    arsort() - 根据关联数组的值，对数组进行降序排列
    krsort() - 根据关联数组的键，对数组进行降序排列
*/


//超级全局变量 在一个脚本的全部作用域中都可用。
/*
    $GLOBALS
    $_SERVER
    $_REQUEST 用于收集HTML表单提交的数据。
    $_POST 应用于收集表单数据，在HTML form标签的指定该属性："method="post"
    $_GET 应用于收集表单数据，在HTML form标签的指定该属性："method="get"
    $_FILES
    $_ENV
    $_COOKIE
    $_SESSION
*/

$x = 75;
$y = 25;
function addition(){
	$GLOBALS['z'] = $GLOBALS['x'] + $GLOBALS['y'];
}
addition();
echo "global z = $z <br>";

//$_SERVER 是一个包含了诸如头信息(header)、路径(path)、以及脚本位置(script locations)等等信息的数组。这个数组中的项目由 Web 服务器创建。不能保证每个服务器都提供全部项目；服务器可能会忽略一些，或者提供一些没有在这里列举出来的项目
echo $_SERVER['PHP_SELF'];
echo "<br>";
echo $_SERVER['SERVER_NAME'];
echo "<br>";
echo $_SERVER['HTTP_HOST'];
echo "<br>";
echo $_SERVER['HTTP_REFERER'];
echo "<br>";
echo $_SERVER['HTTP_USER_AGENT'];
echo "<br>";
echo $_SERVER['SCRIPT_NAME'];

//预定义常量 

/*
__LINE__  文件中的当前行号。
__FILE__ 文件的完整路径和文件名 E:\wamp\www\test\index.php
__DIR__  文件所在的目录
__FUNCTION__ 函数名称
__CLASS__ 类的名称
__TRAIT__ 实现了代码复用的一个方法
__METHOD__ 类的方法名（PHP 5.0.0 新加）。返回该方法被定义时的名字（区分大小写）。
__NAMESPACE__ 当前命名空间的名称
*/




?>

</body>
</html>