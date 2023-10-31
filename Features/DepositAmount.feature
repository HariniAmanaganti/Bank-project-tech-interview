Feature: DepositAmount

	As a user I want to deposit amount into bank account and in response I should see the updated balance

	Background: 
		Given the user wants to deposit amount from bank account

@DepositAmount_PositiveScenario
Scenario: user deposits amount into bank account
	Given user deposits amount with below details
	| AccountNumber | Amount |
	| 233746        |   790  |
	Then amount is deposited successfully


@DepositAmount_NegativeScenario
Scenario: user deposits amount into bank account which does not exist
	Given user deposits amount with below details
	| AccountNumber | Amount |
	| 000001        |   790  |
	Then amount is not deposited due to invaild account


@WithdrawAmount_NegativeScenario
Scenario: user deposits amount into bank account when amount >$10000
	Given user deposits amount with below details
	| AccountNumber | Amount |
	| 000001        |   12000  |
	Then amount is not deposited as the amount is more


@WithdrawAmount_NegativeScenario
Scenario: user deposited amount into bank account when Account number is invalid
	Given user deposited amount with below details
	| AccountNumber | Amount |
	| saaksjdha     |   10000  |
	Then amount is not deposited as Account number is invalid

@WithdrawAmount_NegativeScenario
Scenario: user deposited amount from bank account when amount is null
	Given user deposited amount with below details
	| AccountNumber | Amount |
	|      |     |
	Then amount is not withdrawn as the amount and account number is null

