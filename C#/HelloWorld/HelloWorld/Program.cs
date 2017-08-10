

#define MySymbol

#if (MySymbol)

#elif (MYSMBOL)

#else

#endif

//using 关键字用于 程序中包含System命名空间
using System;
using System.Text.RegularExpressions; //正则表达式
using System.IO;

namespace HelloWorld{
	
	class MainClass{
		public static void Main1(string[] args){
			/*我的第一个C#程序*/
			Console.WriteLine("Hello World!");

			//是针对 VS.NET 用户的。这使得程序会等待一个用户按键的动作，防止程序在 Visual Studio .NET 启动时屏幕会快速运行并关闭
			//Console.ReadKey();
			//Console.ReadLine();

			Rectangle r = new Rectangle();
			r.Acceptdetails();
			r.Display();

			//sizeof 计算字节数  int：4
			Console.WriteLine("Size of int: {0}", sizeof(int));


			//类型转换：
			int ii;
			double d=21.521;
			ii = (int)d;

			bool b = true;
			Console.WriteLine(b.ToString());
			Console.WriteLine(ii.ToString());


			//运算符：判断一个对象是否是特定的类型 	
			if(r is Rectangle){
				
			}
			//转换，如果转换失败则引发异常
			object obj = new Rectangle();
			Rectangle test = obj as Rectangle;


			//可空类型：
			int? num1 = null;
			int? num2 = 45;
			int? num3;


			//?? 空合并运算符：(和 ？ ： 一样的逻辑)
			num3 = num1 ?? 5;


			//数组： datetype[] arrayName;
			double[] balance = new double[10];
			balance[0] = 1231.24;

			double[] balance1 = {132.21, 4241.0, 141.0};

			int[] marks = new int[4] {242, 2, 412, 22};

			int[] mark2 = new int[] {13, 42, 22, 54};

			int[] score = marks;//则指向同一个地址

			double salary = balance[2];

			for(int j=0; j<4; j++){
				Console.Write("...");
			}

			foreach(int j in marks){
				int index = j-100;
				Console.WriteLine("element[{0}]={1}", index, j);
			}

			//字符串：
			string fname, lname;
			fname = "Rowan";
			lname = "Atkinson";
			string fullName = fname + lname;// RowanAtkinson

			char[] letters = {'h', 'a', 'b', 'd', 'c' };
			string greetings = new string(letters);// habdc

			string[] sarray = {"hello", "from", "point"};
			string message = String.Join("...", sarray);//hello...from...point

			DateTime wariting = new DateTime(2012, 10, 10, 17, 58, 1);
			string chat = String.Format("at{0:t} on {0:D}", wariting);//at17:58 on 2012年10月10日

			Console.WriteLine("String:\n {0}\n {1}\n {2}\n {3}", fullName, greetings, message, chat);

			//结构体：
			/*
    			类是引用类型，结构体是值类型
    			结构体不支持继承
    			结构体不能有默认构造函数
			*/
			Books book1;//声明一个book的类型
			book1.title = "安娜卡列宁娜";
			book1.author= "列夫托尔斯泰";
			book1.book_id=41241;
			Console.WriteLine("book's descript:{0}", book1.title);

			//枚举：

			int weekdayStart = (int)Days.mon;
			Console.WriteLine("start:{0}", weekdayStart);//3


			MainClass main = new MainClass();
			main.print(43);
			main.print(13.44);

			//运算符重载
			Box box1 = new Box();
			Box box2 = new Box();

			Box box3 = box1 + box2;

			//正则表达式
			string expStr = "A Thousand Splendid Suns";
			Console.WriteLine("匹配从S开始：");
			showMatch(expStr, @"\bS\S*");


			main.division(32, 0);

			/*	BinaryReader 	从二进制流读取原始数据
				BinaryWriter 	以二进制形式写入原始数据
				BufferedStream 	字节流的临时存储
				Directory 	用于操作目录结构
				DirectoryInfo 	用于创建复合条件指令。
				DriveInfo 	用于执行目录操作
				File 	用于操作文件
				FileInfo 	用于执行文件操作
				FileStream 	用于读写文件中任意位置的内容
				MemoryStream 	用于随机存取存储器中存储的流数据
				Path 	用于执行有关路径信息的操作
				StreamReader 	用于从字节流中读取字符
				StreamWriter 	用于向流中写字符
				StringReader 	用于读取字符串数组
				StringWriter 	用于写入字符串数组*/

			/*文件是存储在磁盘具有特定名称和目录路径的数据的集合。当一个文件被打开阅读或书写时，就变成了流。
			流基本上是通过通信路径中的字节顺序。主要有两个流：输入流和输出流。
			输入流用于从文件系统中读取数据，输出流用于向文件中写数据。


			FileMode 	
			fileMode 枚举定义了各种方法来打开文件。fileMode 枚举的成员是：
			Append: 打开一个已有的文件，并将光标放置在文件的末尾。如果文件不存在，则创建文件。
			Create: 它创建一个新的文件
			CreateNew: 指定操作系统应创建一个新的文件。如果文件已存在，则抛出异常。
			Open: 它会打开一个现有的文件
			OpenOrCreate: 指定操作系统应打开一个已有的文件。如果文件不存在，则用指定的名称创建一个新的文件打开。
			Truncate: 打开一个已有的文件，文件一旦打开，就将被截断为零字节大小。
			
			FileAccess 	
			FileAccess 枚举成员有：Read，ReadWrite 和 Write。
			
			FileShare 	
			FileShare 枚举有以下成员：
			Inheritable: 允许文件句柄可由子进程继承。
			None: 它拒绝共享当前文件
			Read: 它允许打开文件进行读取
			ReadWrite: 它允许打开文件进行读取和写入
			Write: 它允许打开文件写入
			*/

			FileStream F = new FileStream("test.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
			for(int i=1; i<=20; i++){
				F.WriteByte((byte)i);
			}

			F.Position = 0;
			for(int i=0; i<=20; i++){
				Console.Write(F.ReadByte()+ "~");
			}

			F.Close();

		}

		//===================================================================================
		//多态： 1.函数的重载	2.运算符重载
		void print(int i){
			Console.WriteLine("Printing int: {0}", i );
		}

		void print(double f){
			Console.WriteLine("Printing float: {0}" , f);
		}

		//正则表达式 IsMatch, Matches, Replace, Split
		private static void showMatch(string text, string expr){
			Console.WriteLine("正则表达式:"+expr);
			MatchCollection mc = Regex.Matches(text, expr);
			foreach(Match m in mc){
				Console.WriteLine(m);
			}
		}

		//错误处理:
		int result;
		public void division(int num1, int num2){
			
			try{
				result = num1/num2;
			}catch(DivideByZeroException e){
				Console.WriteLine("exception caught:{0}", e);
			}finally{
				Console.WriteLine("result:{0}", result);
			}
		}

	}

	//===================================================================================
	//===================================================================================
	//===================================================================================
	class Box{
		private double length;   // box 的长度
		private double breadth;  // box 的宽度
		private double height;   // box 的高度

		public double getVolume()
		{
			return length * breadth * height;
		}

		public void setLength( double len )
		{
			length = len;
		}

		public void setBreadth( double bre )
		{
			breadth = bre;
		}

		public void setHeight( double hei )
		{
			height = hei;
		}

		// 重载 + operator 来增加两个 Box 对象
		public static Box operator+ (Box b, Box c)
		{
			Box box = new Box();
			box.length = b.length + c.length;
			box.breadth = b.breadth + c.breadth;
			box.height = b.height + c.height;
			return box;
		}
		public static bool operator == (Box a, Box b){
			return true;
		}

		public static bool operator !=(Box a, Box b){
			return false;
		}
	}

	//抽象类：abstract
	abstract class AShape{
		public abstract int aArea();
	}




	//枚举
	enum Days  { sun=2, mon, tue, wed, thu, fri, sat };

	//结构体
	struct Books{
		public string title;
		public string author;
		public int book_id;
	};

	//抽象类只能单继承，
	class Shape : AShape{
		public int width;
		public int height;

		public void setWidth(int w){
			width = w;
		}
		public void setHeight(int h){
			height = h;
		}

		public override int aArea(){
			return width * height;
		}

		//虚函数 virtual
		//虚函数可以在不同的被继承的类中实现，并且将在程序运行时调用此类函数。
		public virtual int vArea(){
			Console.WriteLine("parent class area:");
			return 0;
		}
	}

	//接口，可以实现多个接口
	public interface PainCost{
		int getCost(int area);
	}

	class Rectangle: Shape, PainCost{//继承
		//成员变量
		double length;
		//double width;

		//无论有多少类的对象被创建，只有一个副本的静态成员
		public static int num;

		//成员函数
		public void Acceptdetails(){
			length = 4.5;
			width = 3;
		}

		public double GetArea(){
			return length * width;
		}

		public void Display(){
			Console.WriteLine("length: {0} ", length);
			Console.WriteLine("width: {0} ", width);
			Console.WriteLine("Area: {0} ", GetArea());
			
		}

		//接口方法：
		public int getCost(int area){
			return area*69;
		}

		//虚函数：
		public override int vArea(){
			return width * height;
			//return base.vArea();
		}
	}
}
