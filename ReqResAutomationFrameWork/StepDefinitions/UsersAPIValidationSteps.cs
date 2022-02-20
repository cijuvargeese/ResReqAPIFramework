using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReqResAutomationFrameWork.Helpers;
using ReqResAutomationFrameWork.Models.Response;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace ReqResAutomationFrameWork.StepDefinitions
{
	[Binding]
	public class UsersAPIValidationSteps : BaseSteps
	{

		private string Sub_URL;
		//private RestSharpMethods apiMethods = new RestSharpMethods();
		//private IRestClient restClient;
		//private RestRequest request;


		[Given(@"a User navigates to ReqRes site for Users")]
		public void GivenAUserNavigatesToReqResSiteforUsers()
		{
			Base_URL = configData.ReqResApplication.Base_URL;


		}

		[When(@"the List Users API is submitted for page ""(.*)""")]
		public void WhenTheListUsersAPIIsSubmittedForPage(String pageNo)
		{
			Sub_URL = configData.ReqResApplication.User_URL + "?page=" + pageNo;
			//restClient = apiMethods.setURL(Base_URL, Sub_URL);
			//request = apiMethods.callGetApi();
			//restResponse = apiMethods.getResponse(restClient, request);
			restResponse = CallGetApi(Sub_URL);
			listAllUsersresponseDTO = ConvertJsontoObj.ConvertJsontoObjFromResponse<ListUserResponseDTO>(restResponse);
		}


		[When(@"the List Single User API is submitted for (.*)")]
		public void WhenTheListSingleUserAPIIsSubmittedFor(string Id)
		{
			Sub_URL = configData.ReqResApplication.User_URL +"/"+ Id;
			//restClient = apiMethods.setURL(Base_URL, Sub_URL);
			//request = apiMethods.callGetApi();
			//restResponse = apiMethods.getResponse(restClient, request);
			restResponse = CallGetApi(Sub_URL);
			singleUserResponseDTO = ConvertJsontoObj.ConvertJsontoObjFromResponse<ListSingleUserResponseDTO>(restResponse);

		}


		[Then(@"the User API Statuscode should be (.*)")]
		public void ThenTheStatuscodeShouldBe(int responseCode)
		{
			int expectedRespnseCode = GetAPIStatusCode(restResponse);
			Assert.AreEqual(responseCode, expectedRespnseCode);

		}


		[Then(@"User Response should contain data as (.*),(.*),(.*),(.*),(.*)")]
		public void ThenUserResponseShouldContaindataAs(int ID, string email, string first_name, string last_name, string avatar)
		{

			var ListElement = listAllUsersresponseDTO.data.Find(x => x.id == ID);
			ValidateUserData(ListElement, ID, email, first_name, last_name, avatar);

		}

		[Then(@"Single User Response should contain data as (.*),(.*),(.*),(.*),(.*)")]
		public void ThenSingleUserResponseShouldContaindataAs(int ID, string email, string first_name, string last_name, string avatar)
		{

			var ListElement = singleUserResponseDTO.data;
			ValidateUserData(ListElement, ID, email, first_name, last_name, avatar);

		}

	}
}
