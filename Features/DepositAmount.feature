Feature: DepositAmount

	As a user I want to deposit amount into bank account and in response I should see the updated balance

	Background: 
		Given the user wants to deposit amount to bank account

@DepositAmount_PositiveScenario
Scenario: user deposits amount into bank account
	Given user deposits amount with below details
	| AccountNumber | Amount |
	| 233746        |   790  |
	When the user makes patch call
	Then amount is deposited successfully
	Then verify the API status code should be '200'


@DepositAmount_NegativeScenario
Scenario: user deposits amount into bank account which does not exist
	Given user deposits amount with below details
	| AccountNumber | Amount |
	| 000001        |   790  |
	When the user makes patch call
	Then amount is not deposited due to invaild account
	Then verify the API status code should be '400'


@WithdrawAmount_NegativeScenario
Scenario: user deposits amount into bank account when amount >$10000
	Given user deposits amount with below details
	| AccountNumber | Amount |
	| 000001        |   12000  |
	When the user makes patch call
	Then amount is not deposited as the amount is more
	Then verify the API status code should be '400'


@WithdrawAmount_NegativeScenario
Scenario: user deposited amount into bank account when Account number is invalid
	Given user deposits amount with below details
	| AccountNumber | Amount |
	| saaksjdha     |   10000  |
	When the user makes patch call
	Then amount is not deposited due to invalid account
	Then verify the API status code should be '400'

@WithdrawAmount_NegativeScenario
Scenario: user deposited amount from bank account when amount is null
	Given user deposits amount with below details
	| AccountNumber | Amount |
	|      |     |
	When the user makes patch call
	Then amount is not withdrawn as the amount and account number is null
	Then verify the API status code should be '417'

