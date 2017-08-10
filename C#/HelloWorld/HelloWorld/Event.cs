using System;
using System.IO;

namespace EventTest
{
	public class EventTest
	{
		private int value;
		public delegate void NumManipulationHandler();
		public event NumManipulationHandler ChangeNum;

		protected virtual void OnNumChange(){
			if(ChangeNum != null){
				ChangeNum();
			}else{
				Console.WriteLine("Event fired!");
			}
		}

		public void SetValue(int n){
			if(value != n){
				value = n;
				OnNumChange();
			}
		}

		public EventTest(int n){
			SetValue(n);
		}
	}

	public class MainClass{
		public static void Main5(){
			EventTest e = new EventTest(5);
			e.SetValue(7);
			e.SetValue(11);

		}
	}
}



//===================================================================================
//===================================================================================
//===================================================================================
namespace BoilerEventApp1{

	class Boiler{
		private int temp;
		private int pressure;
		public Boiler(int t, int p){
			temp = t;
			pressure = p;
		}

		public int getTemp(){
			return temp;
		}

		public int getPressure(){
			return pressure;
		}
	}

	//事件发布器
	class DelegateBoilerEvent{
		public delegate void BoilerLogHandler(string status);

		//基于上述委托定义事件
		public event BoilerLogHandler BoilerEventLog;

		public void LogProcess(){
			string remarks = "O. K";
			Boiler b = new Boiler(100, 12);
			int t = b.getTemp();
			int p = b.getPressure();
			if(t>150 || t<80 || p<12 || p>15){
				remarks = "Need Maintenance";
			}
			OnBoilerEventLog("logging info:..\n");
			OnBoilerEventLog("temparaure" + t + "\npressure:"+ p);
			OnBoilerEventLog("\n Message:.."+remarks);
		}

		protected void OnBoilerEventLog(string message){
			if(BoilerEventLog != null){
				BoilerEventLog(message);
			}
		}
	}

	//该类保留写入日志文件的条款
	class BoilerInfoLogger{
		FileStream fs;
		StreamWriter sw;
		public BoilerInfoLogger(string fileName){
			fs = new FileStream(fileName, FileMode.Append, FileAccess.Write);
			sw = new StreamWriter(fs);
		}

		public void Logger(string info){
			sw.WriteLine(info);
		}

		public void Close(){
			sw.Close();
			fs.Close();
		}
	}

	//事件订阅器
	public class RecordBoilerInfo{
		static void Logger(string info){
			Console.WriteLine(info);
		}

		static void Main6(string[] args){
			BoilerInfoLogger filelog = new BoilerInfoLogger("boiler.txt");
			DelegateBoilerEvent boilerEvent = new DelegateBoilerEvent();
			boilerEvent.BoilerEventLog += new DelegateBoilerEvent.BoilerLogHandler(Logger);
			boilerEvent.BoilerEventLog += new DelegateBoilerEvent.BoilerLogHandler(filelog.Logger);
			boilerEvent.LogProcess();
			filelog.Close();
		}
	}
}