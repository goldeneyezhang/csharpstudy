using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Script.Serialization;
namespace ConsoleAppSerialize
{
	/// <summary>
	/// Javascriptserializer方式序列化
	/// </summary>
    public static class JavascriptExtentions
    {
		public static string ToScriptJsonString<T>(this T instance)
		{
			try
			{
				JavaScriptSerializer js = new JavaScriptSerializer();
				return js.Serialize(instance);
			}
			catch
			{
				return String.Empty;
			}
		}
		public static T ToScriptJsonObject<T>(this string s)
		{
			try
			{
				JavaScriptSerializer js = new JavaScriptSerializer();
				return js.Deserialize<T>(s);
			}
			catch
			{
				return default(T);
			}
		}
    }
}
