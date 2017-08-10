using System;

using System.IO;


delegate int NumberChange(int n);

namespace DelegateApp1
{
	 class TestDelegate{
		static int num = 10;
		public static int AddNum(int p){
			num += p;
			return num;
		}

		public static int MultNum(int q){
			num *= q;
			return num;
		}

		public static int getNum(){
			return num;
		}

		static void Main3(string[] args){
			//创建委托实例
			NumberChange numChange1 = new NumberChange(AddNum);
			NumberChange numChange2 = new NumberChange(MultNum);

			//使用委托对象调用方法
			numChange1(20); 
			Console.WriteLine(getNum());
			numChange2(11);
			Console.WriteLine(getNum());

			NumberChange numberChange;
			numberChange = numChange1;
			numberChange +=  numChange2;
			//调用多播
			numberChange(10);
			Console.WriteLine(getNum());

		}
	}



	class PrintString{
		static FileStream fs;
		static StreamWriter sw;

		//委托声明
		public delegate void printString(string s);

		//该方法打印到控制台
		public static void WriteToScreen(string str){
			Console.WriteLine("....:{0}", str);
		}

		//打印到文件：
		public static void WriteToFile(string s){
			fs = new FileStream("message.txt", FileMode.Append, FileAccess.Write);
			sw = new StreamWriter(fs);
			sw.WriteLine(s);
			sw.Flush();
			sw.Close();
			sw.Close();
		}

		//该方法 吧委托作为参数，并使用它调用方法
		public static void sendString(printString ps){
			ps("~~~~hello");
		}

		static void Main4(string[] args){
			printString ps1 = new printString(WriteToFile);
			printString ps2 = new printString(WriteToScreen);

			//....:~~~~hello
			sendString(ps1);
			sendString(ps2);


		}
	}
}
