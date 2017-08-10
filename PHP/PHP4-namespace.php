
<?php
//用户编写的代码与PHP内部的类/函数/常量或第三方类/函数/常量之间的名字冲突。 
//为很长的标识符名称(通常是为了缓解第一类问题而定义的)创建一个别名（或简短）的名称，提高源代码的可读性。 
//在声明命名空间之前唯一合法的代码是用于定义源文件编码方式的 declare 语句。所有非 PHP 代码包括空白符都不能出现在命名空间的声明之前
//命名空间必须是程序脚本的第一条语句
declare(encoding='UTF-8');
//定义代码在 myProject 命名空间中
namespace MyProject;


//也可以同时定义多个命名空间
namespace MyProject1;

//另外一种语法
namespace MyProject2{
	const CONNECT_OK = 1;

	class Connection{
		
		function connect(){
			# code...
		}
	}
}

namespace{
	//全局代码：
	session_start();
	$a = MyProject2\connect();
	echo MyProject2\Connection::start();
}

namespace MyProject\Sub\Level;  //声明分层次的单个命名空间



//当做 file1.php文件的内容
namespace Foo\Bar\subnamespace;
const FOO = 1;
function foo(){

}
class foo{
	static function staticmethod(){

	}
}

?>



<?php//file2.php 文件代码
namespace Foo\Bar;
include  'file1.php';

const FOO = 2;
function foo(){}
class foo{
	static function staticmethod(){};
}

/* 非限定名称 */
foo(); //解析为 Foo\Bar\foo 
foo()::staticmethod(); //解析为类 Foo\Bar\foo的静态方法staticmethod
echo FOO; //解析为常量 Foo\Bar\FOO


/* 限定名称 */
subnamespace\foo(); //解析为函数 Foo\Bar\subnamespace\foo
subnamespace\foo::staticmethod(); //解析为类 Foo\Bar\subnamespace\foo,
								  //以及类的方法 staticmethod
echo subnamespace\FOO; //解析为常量 Foo\Bar\subnamespace\FOO


/* 完全限定名称 */
\Foo\Bar\foo(); //解析为函数 Foo\Bar\foo
\Foo\Bar\foo::staticmethod(); //解析为类 Foo\Bar\foo, 
							  //以及类的方法staticmathod
echo \Foo\Bar\FOO; //解析为常量 Foo\Bar\FOO

?>

<?php
namespace Foo;

function strlen(){}
const INI_ALL =3;
class Exception{}

$a = \strlen('hi');//调用全局的strlen,不是上面自定义的
$b = \INI_ALL; //b=7

$c = INI_ALL;//调用上面自定义的 c=3
echo $b;

/* 名称解析遵循下列规则：

    对完全限定名称的函数，类和常量的调用在编译时解析。例如 new \A\B 解析为类 A\B。
    所有的非限定名称和限定名称（非完全限定名称）根据当前的导入规则在编译时进行转换。例如，如果命名空间 A\B\C 被导入为 C，那么对 C\D\e() 的调用就会被转换为 A\B\C\D\e()。
    在命名空间内部，所有的没有根据导入规则转换的限定名称均会在其前面加上当前的命名空间名称。例如，在命名空间 A\B 内部调用 C\D\e()，则 C\D\e() 会被转换为 A\B\C\D\e() 。
    非限定类名根据当前的导入规则在编译时转换（用全名代替短的导入名称）。例如，如果命名空间 A\B\C 导入为C，则 new C() 被转换为 new A\B\C() 。
    在命名空间内部（例如A\B），对非限定名称的函数调用是在运行时解析的。例如对函数 foo() 的调用是这样解析的：
        在当前命名空间中查找名为 A\B\foo() 的函数
        尝试查找并调用 全局(global) 空间中的函数 foo()。
    在命名空间（例如A\B）内部对非限定名称或限定名称类（非完全限定名称）的调用是在运行时解析的。下面是调用 new C() 及 new D\E() 的解析过程： new C()的解析:
        在当前命名空间中查找A\B\C类。
        尝试自动装载类A\B\C。
    new D\E()的解析:
        在类名称前面加上当前命名空间名称变成：A\B\D\E，然后查找该类。
        尝试自动装载类 A\B\D\E。
    为了引用全局命名空间中的全局类，必须使用完全限定名称 new \C()。
*/

?>





