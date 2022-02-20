using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using RestSharp;

namespace ReqResAutomationFrameWork.Helpers
{
	public class RestSharpMethods
	{

		public RestClient restClient;
		public IRestResponse response;
		public RestRequest request;
		public String reqURL;

		public RestClient setURL(String Base_URL, String Sub_URL)
		{
			return restClient = new RestClient(Base_URL + Sub_URL);

		}
		public RestRequest callGetApi()
		{
			request = new RestRequest(Method.GET);
			return request;

		}

		public RestRequest callPostApi(String payload, IDictionary<string, string> headers)
		{
			request = new RestRequest(Method.POST);
			foreach (KeyValuePair<string, string> entry in headers)
			{
				request.AddHeader(entry.Key, entry.Value);
			}

			request.AddParameter(payload, ParameterType.RequestBody);
			return request;
		}

		public IRestResponse getResponse(IRestClient restClient, RestRequest request)
		{
			response = restClient.Execute(request);
			return response;
		}

	}
}
