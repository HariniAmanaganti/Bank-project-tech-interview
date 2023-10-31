Feature: DeleteAccount

	As a user I want to delete my account in the bank
		
		Background: 
		Given the user wants to delete account from bank 

@DeleteAccount_postiveScenario
Scenario: The user delete the account from bank
	When the accountnumber as '123345' accountname 'John' accounttype 'savings'
	Then the account is deleted sucessfully

@DeleteAccount_negativeScenario
Scenario: The user delete the account from bank which does not exist
	When the accountnumber as '090909' accountname 'John' accounttype 'savings'
	Then the account is not deleted due to invalid account details


@DeleteAccount_negativeScenario
Scenario: The user delete the account from bank when headers are null
	When the accountnumber as '' accountname '' accounttype ''
	Then the account is not deleted due to invalid account details

@DeleteAccount_negativeScenario
Scenario: The user delete the account from bank when accountnumber is invalid
	When the accountnumber as 'iuyftt7' accountname 'John' accounttype 'savings'
	Then the account is not deleted due to invalid account details

@DeleteAccount_negativeScenario
Scenario: The user delete the account from bank when account type is invalid
	When the accountnumber as 'iuyftt7' accountname 'John' accounttype 'social'
	Then the account is not deleted due to invalid account details

@DeleteAccount_negativeScenario
Scenario: The user delete the account from bank when balance is non zero
	When the accountnumber as '090909' accountname 'John' accounttype 'savings'
	Then the account is not deleted the balance exist

