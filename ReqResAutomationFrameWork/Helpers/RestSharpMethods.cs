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


		public RestRequest setRestRequestBasedOnMethodType(string httpMethod, String payload, IDictionary<string, string> headers)
		{
			Method method;
			if (!Enum.TryParse(httpMethod, out method))
			{
				throw new ArgumentException("Invalid HTTP method.", nameof(httpMethod));
			}
			else
			{

				switch (method)
				{
					case Method.GET:
						request = new RestRequest(Method.GET);
						break;
					case Method.DELETE:
						request = new RestRequest(Method.DELETE);
						break;
					case Method.POST:
						request = new RestRequest(Method.POST);
						request = setOtherParametersforPOSTApi(payload, headers);
						break;
					case Method.PUT:
						request = new RestRequest(Method.PUT);
						request = setOtherParametersforPOSTApi(payload, headers);
						break;
					case Method.PATCH:
						request = new RestRequest(Method.PATCH);
						request = setOtherParametersforPOSTApi(payload, headers);
						break;

				}
				return request;
			}



		}


		public RestRequest setOtherParametersforPOSTApi(string payload, IDictionary<string, string> headers)
		{
			foreach (KeyValuePair<string, string> entry in headers)
			{
				request.AddHeader(entry.Key, entry.Value);
			}
			request.Parameters.Clear();
			request.AddParameter("application/json", payload, ParameterType.RequestBody);
			return request;

		}

		public IRestResponse getResponse(IRestClient restClient, RestRequest request)
		{
			response = restClient.Execute(request);
			return response;
		}

	}
}
