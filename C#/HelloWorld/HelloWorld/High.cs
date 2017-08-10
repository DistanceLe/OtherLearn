
#define DEBUG
using System;
using System.Diagnostics;


/*特性（Attribute）是用于在运行时传递程序中各种元素（比如类、方法、结构、枚举、组件等）的行为信息的声明性标签。
 * 您可以通过使用特性向程序添加声明性信息。一个声明性标签是通过放置在它所应用的元素前面的方括号（[ ]）来描述的。

特性（Attribute）用于添加元数据，如编译器指令和注释、描述、方法、类等其他信息。
.Net 框架提供了两种类型的特性：预定义特性和自定义特性。

特性的名称和值都是在方括号内规定的，放在这个特性应用的元素之前。
表示位置的参数规定出特性的基本信息，名称参数规定了可选择的信息。

预定义特性

.Net Framework 提供了三种预定义的特性：

    AttributeUsage
    Conditional
    Obsolete
*/

[HelpAttribute("infomation.. on the class MyClass..")]
public class MyClass{
	[Conditional("DEBUG")]
	public static void message(string msg){
		Console.WriteLine(msg);
	}

	/*
    参数 message，是一个字符串，描述项目为什么过时的原因以及该替代使用什么。
    参数 iserror，是一个布尔值。如果该值为 true，编译器应把该项目的使用当作一个错误。默认值是 false（编译器生成一个警告）。
*/
	[Obsolete("don't use oldMethod, use newMethod instead", false)]
	public static void oldMethod(){
		Console.WriteLine("it is the old method");
	}
	public static void newMethod(){
		Console.WriteLine("it is the new Method");
	}

}

[AttributeUsage(AttributeTargets.All)]
public class HelpAttribute: System.Attribute{
	public readonly string Url;
	private string topic;
	public string Topic{
		get{
			return topic;
		}
		set{
			topic = value;
		}
	}

	public HelpAttribute(string url){
		//url 是一个 表示位置的参数
		this.Url = url;
	}
}

//===========================================================
//===========================================================
/*    [AttributeUsage(
        validon,
        AllowMultiple=allowmultiple,
        Inherited=inherited
    )]
其中，
    参数 validon 规定特性了能承载特性的语言元素。它是枚举器 AttributeTargets 的值的组合。默认值是 AttributeTargets.All。
    参数 allowmultiple（可选的）为该特性的 AllowMultiple 属性提供了一个布尔值。如果为 true，则该特性是多用的。默认值是 false（单用的）。
    参数 inherited（可选的）为该特性的 Inherited 属性提供一个布尔值。如果为 true，则该特性可被派生类继承。默认值是 false（不可继承）。
*/
//创建自定义的特性
[AttributeUsage(AttributeTargets.Class |
                AttributeTargets.Constructor |
                AttributeTargets.Field |
                AttributeTargets.Method |
                AttributeTargets.Property,
                AllowMultiple = true)]
public class DeBugInfo: System.Attribute{
	private int bugNO;
	private string developer;
	private string lastReview;
	public string message;

	public DeBugInfo(int bg, string dev, string d){
		this.bugNO = bg;
		this.developer = dev;
		this.lastReview = d;
	}
	public int BugNo{
		get{
			return bugNO;
		}
	}

	public string Developer{
		get{
			return developer;
		}
	}

	public string LastReview{
		get{
			return lastReview;
		}
	}

	public string Message{
		get{
			return message;
		}
		set{
			message = value;
		}
	}
}
[DeBugInfo(45, "zara Ali", "12/4/2012", Message="Return type mismatch...")]
[DeBugInfo(49, "Nuha Ali", "10/10/2012", Message="Unused variable")]
class Rectangle{
	protected double length;
	protected double width;
	public Rectangle(double l, double w){
		length = l;
		width = w;
	}

	[DeBugInfo(55, "Zara Ali", "19/10/2012", Message = "return type misMatch***")]
	public double GetArea(){
		return length*width;
	}

	[DeBugInfo(56, "Zara Ali", "19/10/2012")]
	public void Display(){
		Console.WriteLine("length:{0}", length);
		Console.WriteLine("width:{0}", width);
		Console.WriteLine("area:{0}", GetArea());
	}
}

class Student{
	private string name = "xiaoming";
	//访问器：
	public string Name{
		get{
			return name;
		}
		set{
			name = value;
		}
	}

	static public int size =10;
	private string[] nameLists=new string[size];
	public Student(){
		for(int i=0; i<size; i++){
			nameLists[i]="~~~";
		}
	}

	//索引器
	public string this[int index]{
		get{
			return nameLists[index];
		}
		set{
			nameLists[index]=value;
		}
	}

	//重载 索引器，可以设置不同的类型
	public int this[string str]{
		get{
			return 100;
		}

	}
}

//===========================================================
//===========================================================
//===========================================================
class Test{
	static void function1(){
		MyClass.message("in function1");
		function2();
	}
	static void function2(){
		MyClass.message("in function2");
	}
	public static void Main2(){
		MyClass.message("in main function");
		function1();

		MyClass.oldMethod();

		//映射 reflection:
		System.Reflection.MemberInfo info = typeof(MyClass);
		object[] attributes = info.GetCustomAttributes(true);
		for(int i =0; i<attributes.Length; i++){
			System.Console.WriteLine(attributes[i]);
		}

		Student xiaoMing = new Student();
		Console.WriteLine(xiaoMing.Name);
		xiaoMing.Name= "abc";
		Console.WriteLine(xiaoMing.Name);

		xiaoMing[2] = "xiaohon";
		Console.WriteLine(xiaoMing[0]+xiaoMing[2]+xiaoMing[3]);
	}
}