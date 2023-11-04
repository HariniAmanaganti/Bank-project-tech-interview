Feature: WithdrawAmount

	As a user I want to wihtdraw amount from  bank account and in response I should see the updated balance

	Background: 
		Given the user wants to withdraw amount from bank account

@WithdrawAmount_PositiveScenario
Scenario: user withdraws amount from bank account
	Given user withdraws amount with below details
	| AccountNumber | Amount |
	| 233746        |   790  |
	When the user makes patch call
	Then amount is successfully withdrawn
	Then verify the API status code should be '200'

@WithdrawAmount_NegativeScenario
Scenario: user withdraws amount from bank account which does not exist
	Given user withdraws amount with below details
	| AccountNumber | Amount |
	| 000001        |   790  |
	When the user makes patch call
	Then amount is not withdrawn due to invaild account
	Then verify the API status code should be '417'


@WithdrawAmount_NegativeScenario
Scenario: user withdraws amount from bank account when amount >90%
	Given user withdraws amount with below details
	| AccountNumber | Amount |
	| 000001        |   10000  |
	When the user makes patch call
	Then amount is not withdrawn as the amount is more
	Then verify the API status code should be '417'


@WithdrawAmount_NegativeScenario
Scenario: user withdraws amount from bank account when Account number is invalid
	Given user withdraws amount with below details
	| AccountNumber | Amount |
	| saaksjdha     |   10000  |
	When the user makes patch call
	Then amount is not withdrawn as Account number is invalid
	Then verify the API status code should be '400'

@WithdrawAmount_NegativeScenario
Scenario: user withdraws amount from bank account when amount is null
	Given user withdraws amount with below details
	| AccountNumber | Amount |
	|      |     |
	When the user makes patch call
	Then amount is not withdrawn as the amount is null
	Then verify the API status code should be '400'
