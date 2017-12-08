using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppExtension
{
	public static class MyExtension
	{
		public static string GetNotNullStr(this string strRes)
		{
			if (strRes == null)
				return string.Empty;
			else
				return strRes;
		}
		/// <summary>
		/// Person的扩展方法，依据年龄偏按段是否是成年人
		/// </summary>
		/// <param name="oPerson"></param>
		/// <returns></returns>
		public static bool GetBIsChild(this Person oPerson)
		{
			if (oPerson.Age >= 18)
				return false;
			else
				return true;
		}
	}
}
