﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReqResAutomationFrameWork.Helpers;
using ReqResAutomationFrameWork.Models.Request;
using ReqResAutomationFrameWork.Models.Response;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace ReqResAutomationFrameWork.StepDefinitions
{
	[Binding]
	[Scope(Feature = "Users API Validation")]
	public class UsersAPIValidationSteps : BaseSteps
	{

		private string Sub_URL;
		CreateUserRequestDTO createUserRequestDTO;
		public UsersAPIValidationSteps()
		{
			headers.Clear();
			headers.Add("Content-Type", "application/json");
		}




		[Given(@"set Create User name as (.*)")]
		public void GivenSetCreateUserNameAs(string name)
		{
			createUserRequestDTO = ConvertJsontoObj.ConvertJsontoObjFromFile<CreateUserRequestDTO>(currentWorkingDirectory, "RequestData/CreateUser");
			createUserRequestDTO.name = name;
		}

		[Given(@"set Create User job as (.*)")]
		public void GivenSetCreateUserJobAs(string job)
		{
			createUserRequestDTO.job = job;
		}

		[When(@"the List Users API is submitted for page ""(.*)""")]
		public void WhenTheListUsersAPIIsSubmittedForPage(String pageNo)
		{
			Sub_URL = configData.ReqResApplication.User_URL + "?page=" + pageNo;
			restResponse = CallGetApi(Sub_URL);
			listAllUsersresponseDTO = ConvertJsontoObj.ConvertJsontoObjFromResponse<ListUserResponseDTO>(restResponse);
		}


		[When(@"the List Single User API is submitted for (.*)")]
		public void WhenTheListSingleUserAPIIsSubmittedFor(string Id)
		{

			Sub_URL = configData.ReqResApplication.User_URL + "/" + Id;
			Assert.IsNotNull(configData.ReqResApplication.User_URL, "Sub URL is null");
			restResponse = CallGetApi(Sub_URL);
			singleUserResponseDTO = ConvertJsontoObj.ConvertJsontoObjFromResponse<ListSingleUserResponseDTO>(restResponse);

		}



		[When(@"Create User API is submitted with payload")]
		public void WhenCreateUserAPIIsSubmittedWithPayload()
		{
			string payload = ConvertObjtoJson.ConvertObjecttoJson(createUserRequestDTO);
			Sub_URL = configData.ReqResApplication.User_URL;
			restResponse = CallPostApi(Sub_URL, payload, headers);
			createUserResponseDTO = ConvertJsontoObj.ConvertJsontoObjFromResponse<CreateUserResponseDTO>(restResponse);
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



		[Then(@"Response should contain (.*) and (.*)")]
		public void ThenResponseShouldContain(string expectedName, string expectedJob)
		{
			Assert.AreEqual(expectedName, createUserResponseDTO.name);
			Assert.AreEqual(expectedJob, createUserResponseDTO.job);

		}

		[Then(@"Response should contain an valid ID")]
		public void ThenResponseShouldContainValidID()
		{
			Assert.IsNotNull(createUserResponseDTO.id);


		}


	}
}
