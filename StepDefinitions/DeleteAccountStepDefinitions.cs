using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using UserTests.Helpers;
using UserTests.Models;

namespace UserTests.StepDefinitions
{
    [Binding]
    public class DeleteAccountStepDefinitions
    {
        private ApiResponse response;
        private string url;
        private RestApiFunctions functions;
        private CreateAccountModel outputModel;
        private List<CreateAccountModel> inputModel;
        private Dictionary<string, string> responsebody;
        private string AccountnumberinDB;
        private string AccountNumber { set; get; }
        private string AccountType { set; get; }

        private string AccountName { set; get; }


        public DeleteAccountStepDefinitions(ScenarioContext scenarioContext)
        {
            response = new ApiResponse();
            functions = new RestApiFunctions();
        }

        [Given(@"the user wants to delete account from bank")]
        public void GivenTheUserWantsToDeleteAccountFromBank()
        {
            url = "http://localhost:5550/api/deleteaccount";

        }

        [When(@"the accountnumber as '([^']*)' accountname '([^']*)' accounttype '([^']*)'")]
        public void WhenTheAccountnumberAsAccountnameAccounttype(string accountNumber, string accountname, string accounttype)
        {
            AccountNumber = accountNumber;
            AccountType = accounttype;
            AccountName = accountname;
            responsebody = functions.DeleteAccount(accountNumber,  accountname,  accounttype, url).Result;
        }

        [Then(@"the account is deleted sucessfully")]
        public void ThenTheAccountIsDeletedSucessfully()
        {
            Assert.AreEqual("OK", responsebody.First().Value);
            Assert.True(responsebody.Last().Value.IndexOf("Your account is deleted successfully.", StringComparison.Ordinal) > 0);

        }

        [Then(@"the account is not deleted due to invalid account details")]
        public void ThenTheAccountIsNotDeletedDueToInvalidAccountDetails()
        {
            if(AccountNumber == null || (AccountNumber.Length != 6) || !Regex.IsMatch((AccountNumber), @"^\d{6}$") 
                || AccountNumber==outputModel.AccountNumber || AccountType !="Savings" || AccountType != "Current")
                Assert.True(responsebody.Last().Value.IndexOf("Your account is deleted successfully.", StringComparison.Ordinal) > 0);

        }

        [Then(@"the account is not deleted the balance exist")]
        public void ThenTheAccountIsNotDeletedTheBalanceExist()
        {
            if (outputModel.CurrentBalance >0)
                Assert.True(responsebody.Last().Value.IndexOf("Your account balance is > 0. ", StringComparison.Ordinal) > 0);

        }
    }
}
