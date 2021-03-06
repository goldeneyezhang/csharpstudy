﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace WebApiStudy.Controllers
{
	public class WebApiExceptionFilterAttribute:ExceptionFilterAttribute
	{
		//重写基类的异常处理方法
		public override void OnException(HttpActionExecutedContext actionExecutedContext)
		{
			//1.异常日志记录（正式项目里一般是log4net记录异常日志
			//base.OnException(actionExecutedContext);
			Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "---" + actionExecutedContext.Exception.GetType().ToString() + ": " + actionExecutedContext.Exception.Message + "-堆栈信息" + actionExecutedContext.Exception.StackTrace);
			//2.返回调用具体的异常信息
			if(actionExecutedContext.Exception is NotImplementedException)
			{
				var oResponse = new HttpResponseMessage(HttpStatusCode.NotImplemented);
				oResponse.Content = new StringContent("方法不被支持");
				oResponse.ReasonPhrase = "This Func is Not Supported";
				actionExecutedContext.Response = oResponse;
				//actionExecutedContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.NotImplemented);
			}
			else if(actionExecutedContext.Exception is TimeoutException)
			{
				actionExecutedContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.RequestTimeout);
			}
			//......这里可以根据项目需要返回到客户端特定的状态码。如果找不到相应的异常，统一返回服务端错误500
			else
			{
				actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
			}
		}
	}
}