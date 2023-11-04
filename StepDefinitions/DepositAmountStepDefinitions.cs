using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UserTests.Helpers;
using UserTests.Models;

namespace UserTests.StepDefinitions
{
    [Binding]
    public class DepositAmountStepDefinitions
    {

        private ApiResponse response;
        private string url;
        private RestApiFunctions functions;
        private CreateAccountModel outputModel;
        private List<CreateAccountModel> inputModel;
        private Dictionary<string, string> responsebody;
       // private string AccountnumberinDB;
        public DepositAmountStepDefinitions(ScenarioContext scenarioContext)
        {
            response = new ApiResponse();
            functions = new RestApiFunctions();
        }

        [Given(@"the user wants to deposit amount to bank account")]
        public void GivenTheUserWantsToDepositAmountToBankAccount()
        {
            url = "http://localhost:5550/api/deposit";
        }


        [Then(@"amount is deposited successfully")]
        public void ThenAmountIsDepositedSuccessfully()
        {
            Assert.AreEqual("OK", responsebody.First().Value);
            outputModel = JsonConvert.DeserializeObject<CreateAccountModel>(responsebody.Last().Value);
            Assert.IsNotNull(outputModel);
            Assert.Greater(outputModel.CurrentBalance, 100);
        }

        [Given(@"user deposits amount with below details")]
        public void GivenUserDepositsAmountWithBelowDetails(Table table)
        {
            inputModel = table.CreateSet<CreateAccountModel>() as List<CreateAccountModel>;

        }

        [When(@"the user makes patch call")]
        public void WhenTheUserMakesPatchCall()
        {
            foreach (CreateAccountModel details in inputModel)
            {
                responsebody = functions.PatchWithdrawAndDepositAmount(url, details).Result;
            }
        }


        [Then(@"amount is not deposited due to invaild account")]
        public void ThenAmountIsNotDepositedDueToInvaildAccount()
        {
            foreach (CreateAccountModel details in inputModel)
            {
                    Assert.True(responsebody.Last().Value.IndexOf("Account number does not exist.", StringComparison.Ordinal) > 0);
            }
        }

        [Then(@"amount is not deposited as the amount is more")]
        public void ThenAmountIsNotDepositedAsTheAmountIsMore()
        {
            foreach (CreateAccountModel details in inputModel)
            {
                if (details.Amount > 10000)
                {
                    Assert.True(responsebody.Last().Value.IndexOf("You are not allowed to deposit >$10000 .", StringComparison.Ordinal) > 0);

                }
            }
        }

        [Then(@"amount is not deposited due to invalid account")]
        public void ThenAmountIsNotDepositedDueToInvalidAccount()
        {
            foreach (CreateAccountModel details in inputModel)
            {
                if ((details.AccountNumber == null) || (details.AccountNumber.Length != 6) || !Regex.IsMatch((details.AccountNumber), @"^\d{6}$"))
                {
                    Assert.True(responsebody.Last().Value.IndexOf("Account number is invalid.", StringComparison.Ordinal) > 0);

                }
            }
        }


        [Then(@"amount is not withdrawn as the amount and account number is null")]
        public void ThenAmountIsNotWithdrawnAsTheAmountAndAccountNumberIsNull()
        {
            foreach (CreateAccountModel details in inputModel)
            {
                if (details.Amount == null)
                {
                    Assert.True(responsebody.Last().Value.IndexOf("Amount cannot be null.", StringComparison.Ordinal) > 0);

                }
            }
        }
    }
}
