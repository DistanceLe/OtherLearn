using System;


using System.Threading;



namespace ThreadDemoApp1
{
	class MainThreadProgram{
		static void Main1(string[] args){
			Thread th = Thread.CurrentThread;
			th.Name = "Main~~";
			Console.WriteLine("this is {0}", th.Name);
		}
	}

	class ThreadCreatProgram{
		public static void CallToChildThread(){

			try{
				Console.WriteLine("child thread start;");
				// 令线程暂停 5000 毫秒
				int sleepfor = 5000; 

				Console.WriteLine("Child Thread Paused for {0} seconds", sleepfor / 1000);
				Thread.Sleep(sleepfor);
				Console.WriteLine("Child thread resumes");
			}catch(ThreadAbortException e){
				Console.WriteLine("thread abort exception");
			}finally{
				Console.WriteLine("couldn't catch the thread exception");
			}
		}

		static void Main(string[] args)
		{
			ThreadStart childref = new ThreadStart(CallToChildThread);
			Console.WriteLine("In Main: Creating the Child thread");
			Thread childThread = new Thread(childref);
			childThread.Start();

			//主线程停止一段时间
			Thread.Sleep(2000);

			//终止子线程
			Console.WriteLine("in main: abort the child thread");
			childThread.Abort();


		}
	}

}
