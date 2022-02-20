using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReqResAutomationFrameWork.Helpers;
using ReqResAutomationFrameWork.Models.Response;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace ReqResAutomationFrameWork.StepDefinitions
{
	[Binding]
	[Scope(Feature = "Resources API Validation")]
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


		[When(@"the List Resources API is submitted")]
		public void WhenTheListResourcesAPIIsSubmittedForPage()
		{
			Sub_URL = configData.ReqResApplication.Resource_URL;
			restResponse = CallGetApi(Sub_URL);
			respnseDTO = ConvertJsontoObj.ConvertJsontoObjFromResponse<ListResourcesResponseDTO>(restResponse);

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
