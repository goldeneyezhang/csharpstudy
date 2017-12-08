using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiStudy.Controllers
{
	//[RequestAuthorize]
	[WebApiExceptionFilter]
	public class ChargingController : ApiController
    {
		public string GetAll()
		{
			return "Success";
		}
		public string Get(int id)
		{
			return "ChargingData" + id;
		}
		public string GetData([FromUri]string key)
		{
			throw new NotImplementedException("方法不被支持");
		}
	}
}
