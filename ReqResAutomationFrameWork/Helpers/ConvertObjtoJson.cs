using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqResAutomationFrameWork.Helpers
{
	public class ConvertObjtoJson
	{

		public static String ConvertObjecttoJson(Object jsonObject)
		{

			String mySerializedClass = JsonConvert.SerializeObject(jsonObject);
			return mySerializedClass;
		}
	}
}
