using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace ReqResAutomationFrameWork.Helpers
{
	class ConvertJsontoObj
	{

		public static T ConvertJsontoObjFromFile<T>(string currentWorkingDirectory, string filename)
		{
			var myJsonResponse = File.ReadAllText(currentWorkingDirectory+"\\"+filename + @".json");
			T myDeserializedClass = JsonConvert.DeserializeObject<T>(myJsonResponse);
			return myDeserializedClass;
		}

		public static T ConvertJsontoObjFromResponse<T>(IRestResponse response)
		{

			T myDeserializedClass = JsonConvert.DeserializeObject<T>(response.Content);
			return myDeserializedClass;
		}
	}
}
