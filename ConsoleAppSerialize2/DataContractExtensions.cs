using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
namespace ConsoleAppSerialize
{
	/// <summary>
	/// DataContract序列化
	/// </summary>
   public static class DataContractExtensions
    {
		/// <summary>
		/// 将对象转化为Json字符串
		/// </summary>
		/// <typeparam name="T">对象类型</typeparam>
		/// <param name="instance">对象本身</param>
		/// <returns></returns>
		public static string ToJsonString<T>(this T instance)
		{
			try
			{
				DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(T));
				using (MemoryStream ms = new MemoryStream())
				{
					js.WriteObject(ms, instance);
					ms.Flush();
					ms.Seek(0, SeekOrigin.Begin);
					StreamReader sr = new StreamReader(ms);
					return sr.ReadToEnd();
				}
			}
			catch
			{
				return string.Empty;
			}
		}
		public static T ToJsonObject<T>(this string s)
		{
			try
			{
				DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(T));
				using (MemoryStream ms = new MemoryStream())
				{
					StreamWriter sw = new StreamWriter(ms);
					sw.Write(s);
					sw.Flush();
					ms.Seek(0, SeekOrigin.Begin);
					return (T)js.ReadObject(ms);

				}
			}
			catch
			{
				return default(T);
			}
		}
    }
}
