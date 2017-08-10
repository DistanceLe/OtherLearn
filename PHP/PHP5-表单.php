<!DOCTYPE html>
<html>
<head>
	<title>表单</title>
	<style>
		.error{color: #FF0000;}
	</style>
</head>
<body>

<?php
//定义变量并默认设置为空
$nameErr = $emailErr = $genderErr = $websitErr = "";
$name = $email = $gender = $comment = $websit = "";

if ($_SERVER["REQUEST_METHOD"] == "POST"){
	if(empty($_POST["name"])){
		$nameErr = "名字是必须的";
	}else{
		$name = test_input($_POST["name"]);
		//preg_match — 进行正则表达式匹配。
		if(!preg_match("/^[a-zA-Z]*$/", $name)){
			$nameErr = "只允许字母和空格";
		}
	}

	if (empty($_POST["email"])) {
		$emailErr = "邮箱是必须的";
	}else{
		$email = test_input($_POST["email"]);
		if (!preg_match("/([\w\-]+\@[\w\-]+\.[\w\-]+)/", $email)) {
			$emailErr = "非法邮箱格式";
		}
	}

	if (empty($_POST["websit"])) {
		$websit = "";
	}else{
		$websit = test_input($_POST["websit"]);
		if (!preg_match("/\b(?:(?:https?|ftp):\/\/|www\.)[-a-z0-9+&@#\/%?=~_|!:,.;]*[-a-z0-9+&@#\/%=~_|]/i",$website)){
			$websitErr = "非法的URL地址";
		}
	}

	if (empty($_POST["comment"])) {
		$comment = "";
	}else{
		$comment = test_input($_POST["comment"]);
	}
	if (empty($_POST["gender"])) {
		$genderErr  = "性别是必须的";
	}else{
		$gender = test_input($_POST["gender"]);
	}
}

function test_input($data){
	// PHP trim() 函数去除用户输入数据中不必要的字符 (如：空格，tab，换行)
	$data = trim($data);
	//PHP stripslashes()函数去除用户输入数据中的反斜杠 (\) 
	$data = stripslashes($data);
	$data = htmlspecialchars($data);
	return $data;
}
?>

<h2>PHP 表单验证实例</h2>
<p><span class="error">* 必需字段。</span></p>
<!-- $_SERVER["PHP_SELF"]是超级全局变量，返回当前正在执行脚本的文件名，与 document root相关 所以，
     $_SERVER["PHP_SELF"] 会发送表单数据到当前页面，而不是跳转到不同的页面。
     htmlspecialchars() 函数把一些预定义的字符转换为 HTML 实体。 
     & （和号） 成为 &amp;  （双引号） 成为 &quot;    ' （单引号） 成为 &#039; 
     < （小于） 成为 &lt;    > （大于） 成为 &gt;-->

<!-- 当黑客使用跨网站脚本的HTTP链接来攻击时，$_SERVER["PHP_SELF"]服务器变量也会被植入脚本。原因就是跨网站脚本是附在执行文件的路径后面的，因此$_SERVER["PHP_SELF"]的字符串就会包含HTTP链接后面的JavaScript程序代码。-->

<!-- 在 PHP 中，预定义的 $_GET 变量用于收集来自 method="get" 的表单中的值。
从带有 GET 方法的表单发送的信息，对任何人都是可见的（会显示在浏览器的地址栏），并且对发送信息的量也有限制
在 HTML 表单中使用 method="get" 时，所有的变量名和值都会显示在 URL 中。
所以在发送密码或其他敏感信息时，不应该使用这个方法！
然而，正因为变量显示在 URL 中，因此可以在收藏夹中收藏该页面。在某些情况下，这是很有用的。
HTTP GET 方法不适合大型的变量值。它的值是不能超过 2000 个字符的。-->

<!--在 PHP 中，预定义的 $_POST 变量用于收集来自 method="post" 的表单中的值。
从带有 POST 方法的表单发送的信息，对任何人都是不可见的（不会显示在浏览器的地址栏），并且对发送信息的量也没有限制。
注释：然而，默认情况下，POST 方法的发送信息的量最大值为 8 MB（可通过设置 php.ini 文件中的 post_max_size 进行更改） 
-->

<form method="post" action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]);?>"> 
   名字: 
   <input type="text" name="name" value="<?php echo $name;?>">
   <span class="error">* <?php echo $nameErr;?></span>
   <br><br>

	E-mail: 
	<input type="text" name="email" value="<?php echo $email;?>">
   <span class="error">* <?php echo $emailErr;?></span>
   <br><br>


   网址: 
   <input type="text" name="website" value="<?php echo $website;?>">
   <span class="error"><?php echo $websiteErr;?></span>
   <br><br>


   备注: <textarea name="comment" rows="5" cols="40"><?php echo $comment;?></textarea>
   <br><br>


   性别:
   <input type="radio" name="gender" <?php if (isset($gender) && $gender=="female") echo "checked";?>  value="female">女
   <input type="radio" name="gender" <?php if (isset($gender) && $gender=="male") echo "checked";?>  value="male">男
   <span class="error">* <?php echo $genderErr;?></span>
   <br><br>
   <input type="submit" name="submit" value="Submit"> 
</form>

<?php
echo "<h2> 您输入的内容是：</h2>";
echo $name, "<br>";
echo $email, "<br>";
echo $website, "<br>";
echo $comment, "<br>";
echo $gender, "<br>";
?>


</body>
</html>












