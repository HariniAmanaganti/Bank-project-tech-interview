Feature: WithdrawAmount

	As a user I want to wihtdraw amount from  bank account and in response I should see the updated balance

	Background: 
		Given the user wants to withdraw amount from bank account

@WithdrawAmount_PositiveScenario
Scenario: user withdraws amount from bank account
	Given user withdraws amount with below details
	| AccountNumber | Amount |
	| 233746        |   790  |
	Then amount is successfully withdrawn

@WithdrawAmount_NegativeScenario
Scenario: user withdraws amount from bank account which does not exist
	Given user withdraws amount with below details
	| AccountNumber | Amount |
	| 000001        |   790  |
	Then amount is not withdrawn due to invaild account


@WithdrawAmount_NegativeScenario
Scenario: user withdraws amount from bank account when amount >90%
	Given user withdraws amount with below details
	| AccountNumber | Amount |
	| 000001        |   10000  |
	Then amount is not withdrawn as the amount is more


@WithdrawAmount_NegativeScenario
Scenario: user withdraws amount from bank account when Account number is invalid
	Given user withdraws amount with below details
	| AccountNumber | Amount |
	| saaksjdha     |   10000  |
	Then amount is not withdrawn as Account number is invalid

@WithdrawAmount_NegativeScenario
Scenario: user withdraws amount from bank account when amount is null
	Given user withdraws amount with below details
	| AccountNumber | Amount |
	| saaksjdha     |   10000  |
	Then amount is not withdrawn as the amount is null
