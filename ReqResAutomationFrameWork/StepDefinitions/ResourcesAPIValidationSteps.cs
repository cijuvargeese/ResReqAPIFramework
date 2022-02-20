using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReqResAutomationFrameWork.Helpers;
using ReqResAutomationFrameWork.Models.Response;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace ReqResAutomationFrameWork.StepDefinitions
{
	[Binding]
	public class ResourcesAPIValidationSteps : BaseSteps
	{
		private string Sub_URL;
		//private RestSharpMethods apiMethods = new RestSharpMethods();
		//private IRestClient restClient;
		//private RestRequest request;
		ListResourcesResponseDTO respnseDTO;


		[Given(@"a User navigates to ReqRes site for Resources")]
		public void GivenAUserNavigatesToReqResSiteforResources()
		{
			Base_URL = configData.ReqResApplication.Base_URL;


		}


		[When(@"the List Resources API is submitted for page ""(.*)""")]
		public void WhenTheListResourcesAPIIsSubmittedForPage(string pageNo)
		{
			Sub_URL = configData.ReqResApplication.User_URL + "?page=" + pageNo;
			//restClient = apiMethods.setURL(Base_URL, Sub_URL);
			//request = apiMethods.callGetApi();
			//restResponse = apiMethods.getResponse(restClient, request);
			restResponse = CallGetApi(Sub_URL);
			respnseDTO = ConvertJsontoObj.ConvertJsontoObjFromResponse<ListResourcesResponseDTO>(restResponse);

		}


		[Then(@"the resource API Status code should be (.*)")]
		public void ThenTheResourceAPIStatusCodeShouldBe(int responseCode)
		{
			int expectedResponseCode = GetAPIStatusCode(restResponse);
			Assert.AreEqual(responseCode, expectedResponseCode);
		}



		[Then(@"Resource Response should contain data as (.*),(.*),(.*),(.*),(.*)")]
		public void ThenResponseShouldContaindataAs(int ID, string name, string year, string color, string pantone_value)
		{

			var ListElement = respnseDTO.data.Find(x => x.id == ID);
			Assert.AreEqual(ID, ListElement.id);
			Assert.AreEqual(name, ListElement.name);
			Assert.AreEqual(year, ListElement.year);
			Assert.AreEqual(color, ListElement.color);
			Assert.AreEqual(pantone_value, ListElement.pantone_value);
		}

	}
}
