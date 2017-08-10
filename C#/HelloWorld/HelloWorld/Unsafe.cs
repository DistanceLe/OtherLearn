/*编译不安全代码

必须切换命令行编译器到指定的 /unsafe 命令行才能进行不安全代码的编译。
例如，编译一个包含不安全代码的名为 prog1.cs 的程序，需要在命令行中输入如下命令：
csc /unsafe prog1.cs

在 Visual Studio IDE 环境中编译不安全代码，需要在项目属性中启用相关设置。
步骤如下：
    双击资源管理器中的属性节点，打开项目属性。
    点击 Build 标签页。
    选择选项 "Allow unsafe code"。
*/

/*
using System;
namespace UnsafeCodeApplication
{
	class Program
	{
		public static void Main1()
		{
			unsafe
			{
				int var = 20;
				int* p = &var;
				Console.WriteLine("Data is: {0} " , var);
				Console.WriteLine("Data is: {0} " , p->ToString());
				Console.WriteLine("Address is: {0} " , (int)p);
			}


		}
	}

	class TestPointer
	{
		public unsafe static void Main2()
		{
			int[]  list = {10, 100, 200};
			fixed(int *ptr = list)

			//let us have array address in pointer 
			for ( int i = 0; i < 3; i++)
			{
				Console.WriteLine("Address of list[{0}]={1}",i,(int)(ptr + i));
				Console.WriteLine("Value of list[{0}]={1}", i, *(ptr + i));
			}

			Console.ReadKey();
		}
	}

	class TestPointer2
	{
		public unsafe void swap(int* p, int *q)
		{
			int temp = *p;
			*p = *q;
			*q = temp;
		}

		public unsafe static void Main3()
		{
			TestPointer p = new TestPointer();
			int var1 = 10;
			int var2 = 20;
			int* x = &var1;
			int* y = &var2;

			Console.WriteLine("Before Swap: var1:{0}, var2: {1}", var1, var2);
			p.swap(x, y);

			Console.WriteLine("After Swap: var1:{0}, var2: {1}", var1, var2);
			Console.ReadKey();
		}
	}
}

*/