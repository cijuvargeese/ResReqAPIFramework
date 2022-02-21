using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReqResAutomationFrameWork.Helpers;
using ReqResAutomationFrameWork.Models.Configuration;
using ReqResAutomationFrameWork.Models.Response;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using TechTalk.SpecFlow;

namespace ReqResAutomationFrameWork.StepDefinitions
{

	public class BaseSteps
	{
		public JsonConfig configData;
		public string currentWorkingDirectory = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);
		protected RestSharpMethods apiMethods = new RestSharpMethods();
		protected string Base_URL;
		protected IRestResponse restResponse;
		protected IRestClient restClient;
		protected RestRequest request;
		protected ListUserResponseDTO listAllUsersresponseDTO;
		protected ListSingleUserResponseDTO singleUserResponseDTO;
		protected CreateUserResponseDTO createUserResponseDTO;
		protected RegisterResponseDTO registerResponseDTO;
		protected IDictionary<string, string> headers = new Dictionary<string, string>();

		public BaseSteps()
		{
			configData = ConvertJsontoObj.ConvertJsontoObjFromFile<JsonConfig>(currentWorkingDirectory, "AppSettings");



		}


		public int GetAPIStatusCode(IRestResponse restResponse)
		{
			HttpStatusCode statusCode = restResponse.StatusCode;
			return (int)statusCode;

		}


		public IRestResponse CallRestApi(String methodType, String Sub_URL, String payload, IDictionary<string, string> headers)
		{
			restClient = apiMethods.setURL(Base_URL, Sub_URL);
			request = apiMethods.setRestRequestBasedOnMethodType(methodType, payload, headers);
			return apiMethods.getResponse(restClient, request);
		}

		[Given(@"a User navigates to ReqRes site")]
		public void GivenAUserNavigatesToReqResSiteforUsers()
		{
			Base_URL = configData.ReqResApplication.Base_URL;


		}

		[Then(@"the API Status code should be (.*)")]
		public void ThenTheAPIStatusCodeShouldBe(int responseCode)
		{
			int expectedResponseCode = GetAPIStatusCode(restResponse);
			Assert.AreEqual(responseCode, expectedResponseCode);
		}

		public void ValidateUserData(Data listElement, int ID, string email, string first_name, string last_name, string avatar)
		{


			Assert.AreEqual(ID, listElement.id);
			Assert.AreEqual(email, listElement.email);
			Assert.AreEqual(first_name, listElement.first_name);
			Assert.AreEqual(last_name, listElement.last_name);
			Assert.AreEqual(avatar, listElement.avatar);

		}
		public void ValidateUserData(SingleDataUser listElement, int ID, string email, string first_name, string last_name, string avatar)
		{


			Assert.AreEqual(ID, listElement.id);
			Assert.AreEqual(email, listElement.email);
			Assert.AreEqual(first_name, listElement.first_name);
			Assert.AreEqual(last_name, listElement.last_name);
			Assert.AreEqual(avatar, listElement.avatar);

		}


	}
}
