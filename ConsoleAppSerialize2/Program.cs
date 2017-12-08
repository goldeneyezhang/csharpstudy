using ConsoleAppSerialize;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSerialize2
{
	class Program
	{
		static void Main(string[] args)
		{
			#region 强类型对象
			/*var lstRes = GetPersons();
			#region JavaScriptSerializer序列化方式
			var lstScriptSerializeObj = new List<string>();
			Stopwatch sp_script = new Stopwatch();
			sp_script.Start();
			foreach(var oPerson in lstRes)
			{
				lstScriptSerializeObj.Add(oPerson.ToScriptJsonString<Person>());
			}
			sp_script.Stop();
			Console.WriteLine("JavaScriptSerializer序列化方式序列化" + lstScriptSerializeObj.Count + "个对象耗时：" + sp_script.ElapsedMilliseconds + "毫秒");
			lstRes.Clear();
			Stopwatch sp_script1 = new Stopwatch();
			sp_script1.Start();
			foreach(var oFrameSerializeObj in lstScriptSerializeObj)
			{
				lstRes.Add(oFrameSerializeObj.ToScriptJsonObject<Person>());
			}
			sp_script1.Stop();
			Console.WriteLine("JavaScriptSerializer序列化方式反序列化" + lstScriptSerializeObj.Count + "个对象耗时：" + sp_script1.ElapsedMilliseconds + "毫秒");
			#endregion
			#region DataContact序列化方式
			var lstFrameSerializeObj = new List<string>();
			Stopwatch sp_contact = new Stopwatch();
			sp_contact.Start();
			foreach (var oPerson in lstRes)
			{
				lstFrameSerializeObj.Add(oPerson.ToScriptJsonString<Person>());
			}
			sp_contact.Stop();
			Console.WriteLine("DataContactSerializer序列化方式序列化" + lstFrameSerializeObj.Count + "个对象耗时：" + sp_contact.ElapsedMilliseconds + "毫秒");
			lstRes.Clear();
			Stopwatch sp_contact1 = new Stopwatch();
			sp_contact1.Start();
			foreach (var oFrameSerializeObj in lstScriptSerializeObj)
			{
				lstRes.Add(oFrameSerializeObj.ToScriptJsonObject<Person>());
			}
			sp_contact1.Stop();
			Console.WriteLine("DataContactSerializer序列化方式反序列化" + lstFrameSerializeObj.Count + "个对象耗时：" + sp_contact1.ElapsedMilliseconds + "毫秒");
			#endregion
			#region Newtonsoft
			var lstNewtonsoftSerialize = new List<string>();
			Stopwatch spNewton = new Stopwatch();
			spNewton.Start();
			foreach(var oPerson in lstRes)
			{
				lstNewtonsoftSerialize.Add(JsonConvert.SerializeObject(oPerson));
			}
			spNewton.Stop();
			Console.WriteLine("Newtonsoft.Json方式序列化" + lstNewtonsoftSerialize.Count + "个对象耗时：" + spNewton.ElapsedMilliseconds + "毫秒");
			lstRes.Clear();
			Stopwatch spNewton1 = new Stopwatch();
			spNewton1.Start();
			foreach (var oNewtonsoft in lstNewtonsoftSerialize)
			{
				lstRes.Add(JsonConvert.DeserializeObject<Person>(oNewtonsoft));
			}
			spNewton1.Stop();
			Console.WriteLine("Newtonsoft.Json方式反序列化" + lstNewtonsoftSerialize.Count + "个对象耗时：" + spNewton1.ElapsedMilliseconds + "毫秒");
			#endregion*/
			#endregion

			#region 弱类型DataTable
			var dt = GetDataTable();
			/*#region JavaScriptSerializer序列化方式
            Stopwatch sp_script = new Stopwatch();
            sp_script.Start();
            var strRes = dt.ToScriptJsonString<DataTable>();
            sp_script.Stop();
            Console.WriteLine("JavaScriptSerializer序列化方式序列化" + dt.Rows.Count + "个DataRow耗时：" + sp_script.ElapsedMilliseconds + "毫秒");

            dt.Clear();
            Stopwatch sp_script1 = new Stopwatch();
            sp_script1.Start();
            dt = strRes.ToScriptJsonObject<DataTable>();
            sp_script1.Stop();
            Console.WriteLine("JavaScriptSerializer序列化方式反序列化" + dt.Rows.Count + "个DataRow耗时：" + sp_script1.ElapsedMilliseconds + "毫秒");
            #endregion
*/
			#region DataContract序列化方式
			Stopwatch sp = new Stopwatch();
            sp.Start();
            var strRes = dt.ToJsonString<DataTable>();
            sp.Stop();
            Console.WriteLine("DataContract序列化方式序列化" + dt.Rows.Count + "个DataRow耗时：" + sp.ElapsedMilliseconds + "毫秒");

            dt.Clear();
            Stopwatch sp1 = new Stopwatch();
            sp1.Start();
            dt = strRes.ToJsonObject<DataTable>();
            sp1.Stop();
            Console.WriteLine("DataContract序列化方式反序列化" + dt.Rows.Count + "个DataRow耗时：" + sp1.ElapsedMilliseconds + "毫秒");
            #endregion

            #region Newtonsoft
            Stopwatch sp2 = new Stopwatch();
            sp2.Start();
            strRes = JsonConvert.SerializeObject(dt);
            sp2.Stop();
            Console.WriteLine("Newtonsoft.Json方式序列化" + dt.Rows.Count + "个DataRow耗时：" + sp2.ElapsedMilliseconds + "毫秒");

            dt.Clear();
            Stopwatch sp3 = new Stopwatch();
            sp3.Start();
            dt = JsonConvert.DeserializeObject<DataTable>(strRes);
            sp3.Stop();
            Console.WriteLine("Newtonsoft.Json方式反序列化" + dt.Rows.Count + "个DataRow耗时：" + sp3.ElapsedMilliseconds + "毫秒");
            #endregion
			#endregion

			Console.ReadLine();
		}
		public static List<Person> GetPersons()
		{
			var lstRes = new List<Person>();
			for (var i = 0; i < 50000; i++)
			{
				var oPerson = new Person();

				oPerson.Name = "大包" + i;
				oPerson.Age = 20;
				oPerson.IsChild = i % 5 == 0 ? true : false;
				oPerson.Test1 = "aaaaaa";
				oPerson.Test2 = i.ToString();
				oPerson.Test3 = i.ToString();
				oPerson.Test4 = i.ToString();
				oPerson.Test5 = i.ToString();
				oPerson.Test6 = i.ToString();
				oPerson.Test7 = i.ToString();
				oPerson.Test8 = i.ToString();
				oPerson.Test9 = i.ToString();
				oPerson.Test10 = i.ToString();
				lstRes.Add(oPerson);
			}

			return lstRes;
		}
		public static DataTable GetDataTable()
		{
			var dt = new DataTable("dt");
			dt.Columns.Add("Age", Type.GetType("System.Int32"));
			dt.Columns.Add("Name", Type.GetType("System.String"));
			dt.Columns.Add("Sex", Type.GetType("System.String"));
			dt.Columns.Add("IsChild", Type.GetType("System.Boolean"));
			for (var i = 0; i < 1000; i++)
			{
				DataRow dr = dt.NewRow();
				dr["Age"] = i + 1;
				dr["Name"] = "Name" + i;
				dr["Sex"] = i % 2 == 0 ? "男" : "女";
				dr["IsChild"] = i % 5 > 0 ? true : false;
				dt.Rows.Add(dr);
			}

			return dt;
		}
	}
}
