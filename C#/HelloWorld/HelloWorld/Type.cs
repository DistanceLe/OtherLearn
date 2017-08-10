using System;

/*你可以创建泛型集合类。.NET 框架类库在 System.Collections.Generic 命名空间中包含了一些新的泛型集合类，
 * 你可以使用这些泛型集合类来替代 System.Collections 中的集合类*/
using System.Collections.Generic;

//泛型允许推迟类或方法中编程元素的数据类型规范的编写，直到实际在程序中使用它的时候再编写。
//换句话说，泛型允许编写一个可以与任何数据类型协作的类或方法。
namespace TyepTest{

	public class MyGenericArray<T>{
		private T[] array;
		public MyGenericArray(int size){
			array = new T[size+1];
		}

		public T getItem(int index){
			return array[index];
		}

		public void setItem(int index, T value){
			array[index] = value;
		}
	}

	class Tester{
		static void Main7(string[] args){
			//声明一个整形数组
			MyGenericArray<int> intArray = new MyGenericArray<int>(5);
			//设置值
			for(int c=0; c<5; c++){
				intArray.setItem(c, c*5);
			}

			//获取值
			for(int c=0; c<5; c++){
				Console.Write(intArray.getItem(c) + " ");
			}
			Console.WriteLine();

			//声明一个字符数组
			MyGenericArray<char> charArray = new MyGenericArray<char>(5);
			for(int c = 0; c<5; c++){
				charArray.setItem(c, (char)(c+97));
			}
			for(int c=0; c<5; c++){
				Console.Write(charArray.getItem(c)+ " ");
			}
			Console.WriteLine();
		}
	}

	
}

namespace GenericMethodApp1{
	class Program{
		static void Swap<T>(ref T lhs, ref T rhs){
			T temp;
			temp = lhs;
			lhs = rhs;
			rhs = temp;
		}

		static void Main8(string[] args){
			int a, b;
			char c, d;
			a = 10;
			b = 20;
			c = 'I';
			d = 'V';
			//显示交换之前的值
			Console.WriteLine("int value before:");
			Console.WriteLine("a= {0}, b= {1}", a, b);
			Console.WriteLine("c= {0}, d= {1}", c, d);

			//调用swap 进行交换
			Swap<int>(ref a, ref b);
			Swap<char>(ref c, ref d);

			//显示交换之后的值
			Console.WriteLine("int value after:");
			Console.WriteLine("a= {0}, b= {1}", a, b);
			Console.WriteLine("c= {0}, d= {1}", c, d);
		}
	}
}


//泛型委托：
delegate T NumberChange<T>(T n);
namespace GenericDelegatApp1{
	class TestDelegate{
		static int num =10;
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

		static void Main9(string[] args){
			//创建委托实例
			NumberChange<int> nc1 = new NumberChange<int>(AddNum);
			NumberChange<int> nc2 = new NumberChange<int>(MultNum);

			//使用委托对象调用方法
			int temp = nc1(24);
			Console.WriteLine("value of num: {0}--{1}", getNum(), temp);
			nc2(5);
			Console.WriteLine("value of num: {0}", getNum());
		}
	}
}


//匿名方法
namespace AnonymityApp1{
	class TestDelegate{
		static int num = 10;
		public static int AddNum(int p){
			num += p;
			Console.WriteLine("name method: {0}", num);
			return num;
		}

		public static int MultNum(int q){
			num *= q;
			Console.WriteLine("name method:{0}", num);
			return num;
		}

		public static int getNum(){
			return num;
		}

		static void Main10(string[] args){
			//使用匿名方法创建委托实例
			NumberChange nc = delegate(int x){
				Console.WriteLine("anonymous method : {0}", x);
				return 0;
			};

			//使用匿名方法调用委托
			nc(10);

			//使用命名方法实例化委托
			NumberChange<int> tempNc = new NumberChange<int>(AddNum);
			tempNc(5);

			//使用另一个命名方法实例化委托
			tempNc = new NumberChange<int>(MultNum);

			//调用委托
			tempNc(2);


		}
	}
}