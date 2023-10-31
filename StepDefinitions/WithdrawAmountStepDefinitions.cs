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
    public class WithdrawAmountStepDefinitions
    {
        private ApiResponse response;
        private string url;
        private RestApiFunctions functions;
        private CreateAccountModel outputModel;
        private List<CreateAccountModel> inputModel;
        private Dictionary<string, string> responsebody;
        private string AccountnumberinDB;
        public WithdrawAmountStepDefinitions(ScenarioContext scenarioContext)
        {
            response = new ApiResponse();
            functions = new RestApiFunctions();
        }

        [Given(@"the user wants to withdraw amount from bank account")]
        public void GivenTheUserWantsToWithdrawAmountFromBankAccount()
        {
            url = "http://localhost:5550/api/createaccount";
        }

        [Given(@"user withdraws amount with below details")]
        public void GivenUserWithdrawsAmountWithBelowDetails(Table table)
        {
            inputModel = table.CreateSet<CreateAccountModel>() as List<CreateAccountModel>;
            foreach (CreateAccountModel details in inputModel)
            {
                responsebody = functions.PostCreateAccount(url, details).Result;
            }
        }

        [Then(@"amount is successfully withdrawn")]
        public void ThenAmountIsSuccessfullyWithdrawn()
        {
            Assert.AreEqual("OK", responsebody.First().Value);
            outputModel = JsonConvert.DeserializeObject<CreateAccountModel>(responsebody.Last().Value);
            Assert.IsNotNull(outputModel);
            Assert.Greater(outputModel.CurrentBalance, 100);
        }

        [Then(@"amount is not withdrawn due to invaild account")]
        public void ThenAmountIsNotWithdrawnDueToInvaildAccount()
        {
           foreach (CreateAccountModel details in inputModel)
                {
                if (details.AccountNumber != AccountnumberinDB)
                    {
                    Assert.True(responsebody.Last().Value.IndexOf("Account number does not exist.", StringComparison.Ordinal) > 0);
                }
            }
        }

        [Then(@"amount is not withdrawn as the amount is more")]
        public void ThenAmountIsNotWithdrawnAsTheAmountIsMore()
        {
            foreach (CreateAccountModel details in inputModel)
            {
                if ((details.Amount >(details.CurrentBalance*0.9)))
                {
                    Assert.True(responsebody.Last().Value.IndexOf("You are not allowed to withdraw >90% .", StringComparison.Ordinal) > 0);

                }
            }
        }

        [Then(@"amount is not withdrawn as Account number is invalid")]
        public void ThenAmountIsNotWithdrawnAsAccountNumberIsInvalid()
        {
            foreach (CreateAccountModel details in inputModel)
            {
                if ((details.AccountNumber == null) || (details.AccountNumber.Length != 6) || !Regex.IsMatch((details.AccountNumber), @"^\d{6}$"))
                {
                    Assert.True(responsebody.Last().Value.IndexOf("Account number is invalid.", StringComparison.Ordinal) > 0);

                }
            }
        }

        [Then(@"amount is not withdrawn as the amount is null")]
        public void ThenAmountIsNotWithdrawnAsTheAmountIsNull()
        {
            foreach (CreateAccountModel details in inputModel)
            {
                if (details.Amount==null )
                {
                    Assert.True(responsebody.Last().Value.IndexOf("Amount cannot be null.", StringComparison.Ordinal) > 0);

                }
            }
        }
    }
}
