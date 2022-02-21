using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReqResAutomationFrameWork.Helpers;
using ReqResAutomationFrameWork.Models.Request;
using ReqResAutomationFrameWork.Models.Response;
using System;
using TechTalk.SpecFlow;

namespace ReqResAutomationFrameWork.StepDefinitions
{
    [Binding]
    [Scope(Feature = "Register and Login API Validations")]
    public class RegisterAPISteps : BaseSteps
    {
        RegisterRequestDTO registerRequestDTO = new RegisterRequestDTO();
        private string Sub_URL;
        public RegisterAPISteps()
        {
            headers.Clear();
            headers.Add("Content-Type", "application/json");

        }

        [Given(@"set email as (.*)")]
        public void GivenSetEmailAs(string email)
        {
            registerRequestDTO = ConvertJsontoObj.ConvertJsontoObjFromFile<RegisterRequestDTO>(currentWorkingDirectory, "RequestData/Register");
            registerRequestDTO.email = email;


        }
        
        [Given(@"set password as (.*)")]
        public void GivenSetPasswordAs(string password)
        {
            registerRequestDTO.password = password;
        }
        
        [When(@"Register User API is submitted with payload")]
        public void WhenRegisterUserAPIIsSubmittedWithPayload()
        {
            string payload = ConvertObjtoJson.ConvertObjecttoJson(registerRequestDTO);
            Sub_URL = configData.ReqResApplication.Register_URL;
            restResponse = CallRestApi("POST", Sub_URL, payload, headers);
            registerResponseDTO = ConvertJsontoObj.ConvertJsontoObjFromResponse<RegisterResponseDTO>(restResponse);
        }

        [When(@"Login User API is submitted with payload")]
        public void WhenLoginUserAPIIsSubmittedWithPayload()
        {
            string payload = ConvertObjtoJson.ConvertObjecttoJson(registerRequestDTO);
            Sub_URL = configData.ReqResApplication.Login_URL;
            restResponse = CallRestApi("POST", Sub_URL, payload, headers);
            registerResponseDTO = ConvertJsontoObj.ConvertJsontoObjFromResponse<RegisterResponseDTO>(restResponse);
        }



        [Then(@"Response should contain expected email as (.*)")]
        public void ThenResponseShouldContain(string expectedEmail)
        {
            string id = registerResponseDTO.id;
            Sub_URL = configData.ReqResApplication.User_URL + "/" + id;
            Assert.IsNotNull(configData.ReqResApplication.User_URL, "Sub URL is null");
            restResponse = CallRestApi("GET", Sub_URL, null, null);
            singleUserResponseDTO = ConvertJsontoObj.ConvertJsontoObjFromResponse<ListSingleUserResponseDTO>(restResponse);
            Assert.AreEqual(expectedEmail, singleUserResponseDTO.data.email);
        }

        [Then(@"Response should contain error message (.*)")]
        public void ResponseShouldHaveMessage(string message)
        {
            Assert.AreEqual(message, registerResponseDTO.error);
        }

        [Then(@"Response should contain token")]
        public void ThenResponseShouldContainToken()
        {
            Assert.IsNotNull(registerResponseDTO.token);
        }

    }
}
