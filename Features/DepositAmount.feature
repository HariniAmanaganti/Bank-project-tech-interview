Feature: DepositAmount

	As a user I want to deposit amount into bank account and in response I should see the updated balance

	Background: 
		Given the user wants to deposit amount from bank account

@DepositAmount_PositiveScenario
Scenario: user deposits amount into bank account
	Given user deposits amount into the bank account
	| AccountNumber | Amount |
	| 233746        |   790  |
	Then amount is deposited successfully

#
#@DepositAmount_NegativeScenario
#Scenario: user withdraws amount from bank account which does not exist
#	Given user withdraws amount with below details
#	| AccountNumber | Amount |
#	| 000001        |   790  |
#	Then amount is not deposited due to invaild account
#
#
#@WithdrawAmount_NegativeScenario
#Scenario: user withdraws amount from bank account when amount >90%
#	Given user withdraws amount with below details
#	| AccountNumber | Amount |
#	| 000001        |   10000  |
#	Then amount is not withdrawn as the amount is more
#
#
#@WithdrawAmount_NegativeScenario
#Scenario: user withdraws amount from bank account when Account number is invalid
#	Given user withdraws amount with below details
#	| AccountNumber | Amount |
#	| saaksjdha     |   10000  |
#	Then amount is not withdrawn as Account number is invalid
#
#@WithdrawAmount_NegativeScenario
#Scenario: user withdraws amount from bank account when amount is null
#	Given user withdraws amount with below details
#	| AccountNumber | Amount |
#	| saaksjdha     |   10000  |
#	Then amount is not withdrawn as the amount is null

