using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UserTests.Helpers;
using UserTests.Models;

namespace UserTests.StepDefinitions
{
    [Binding]
    public class CreateAccountAPIStepDefinitions
    {

        private ApiResponse response;
        private string url;
        private RestApiFunctions functions;
        private CreateAccountModel outputModel;
        private List<CreateAccountModel> inputModel;
        private Dictionary<string, string> responsebody;
        public CreateAccountAPIStepDefinitions(ScenarioContext scenarioContext)
        {
            response = new ApiResponse();
            functions = new RestApiFunctions();
        }

        [Given(@"the user wants to create and account in bank")]
        public void GivenTheUserWantsToCreateAndAccountInBank()
        {
            url =  "http://localhost:5550/api/createaccount";
        }

        [When(@"user provides the below details to create")]
        public void WhenUserProvidesTheBelowDetailsToCreate(Table table)
        {

            inputModel = table.CreateSet<CreateAccountModel>() as List<CreateAccountModel>;
            foreach (CreateAccountModel details in inputModel)
            {
                 responsebody = functions.PostCreateAccount(url,details ).Result;
                Assert.AreEqual("OK", responsebody.First().Value);
            }
        }

        [Then(@"account should be created successfully")]
        public void ThenAccountShouldBeCreatedSuccessfully()
        {
            Assert.AreEqual(outputModel.IsAccountCreated,true);           
        }

        [Then(@"user gets the account number and details in response")]
        public void ThenUserGetsTheAccountNumberAndDetailsInResponse()
        {
            outputModel = JsonConvert.DeserializeObject<CreateAccountModel>(responsebody.Last().Value);
            Assert.IsNotNull(outputModel);
            Assert.Greater(outputModel.InitialDeposit, 100);

        }

        [Then(@"account is not created")]
        public void ThenAccountIsNotCreated()
        {
            Assert.True(responsebody.Last().Value.IndexOf("Your account is not created.", StringComparison.Ordinal) > 0);
        }

        [Then(@"error message is displayed Account type is required")]
        public void ThenErrorMessageIsDisplayedAccountTypeIsRequired()
        {
            Assert.True(responsebody.Last().Value.IndexOf("Account type is required.", StringComparison.Ordinal) > 0);
        }

        [Then(@"error message is displayed deposit is less")]
        public void ThenErrorMessageIsDisplayedDepositIsLess()
        {
            Assert.Less(outputModel.InitialDeposit, 100);
            Assert.True(responsebody.Last().Value.IndexOf("Deposit amount should be greater than $100.", StringComparison.Ordinal) > 0);
        }

        [Then(@"error message is displayed to provide details")]
        public void ThenErrorMessageIsDisplayedToProvideDetails()
        {
            Assert.True(responsebody.Last().Value.IndexOf("Please provide user inputs.", StringComparison.Ordinal) > 0);
        }

        [Then(@"verify the API status code should be '([^']*)'")]
        public void ThenVerifyTheAPIStatusCodeShouldBe(int statuscode)
        {
            if (statuscode == 200) {
                Assert.AreEqual("OK", responsebody.First().Value);

            }
            else if(statuscode == 400)
            {
                Assert.AreEqual("BadRequest", responsebody.First().Value);
            }
            else if (statuscode == 417)
            {
                Assert.AreEqual("ExpectationFailed", responsebody.First().Value);
            }
        }

    }
}
