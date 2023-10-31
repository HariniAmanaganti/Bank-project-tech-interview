Feature: CreateAccountAPI

	As a user I want to create an bank account and provide my details 
	and I should see an account number created 

@CreateAccountAPI_PositiveScenario
Scenario: user creates an account in bank
	Given the user wants to create and account in bank 
	When user provides the below details to create 
	| AccountName | AccountType | Initial Deposit | SSN        |
	| Colin       | Savings     | 5000            | 1178909083 |
	| Colin       | Current     | 1200            | 1897687657 |
	Then account should be created successfully
	And user gets the account number and details in response

@CreateAccountAPI_NegativeScenario
Scenario: user creates an account in bank without mentioning account type
	Given the user wants to create and account in bank 
	When user provides the below details to create 
	| AccountName | AccountType | Initial Deposit | SSN        |
	| Colin       |				| 5000            | 1178909083 |
	Then account is not created 
	And error message is displayed Account type is required

@CreateAccountAPI_NegativeScenario
Scenario: user creates an account in bank with initial deposit less than $100
	Given the user wants to create and account in bank 
	When user provides the below details to create 
	| AccountName | AccountType | Initial Deposit | SSN        |
	| Colin       | Savings     | 500             | 1178909083 |
	Then account is not created 
	And error message is displayed deposit is less

@CreateAccountAPI_NegativeScenario
Scenario: user creates an account in bank with no details
	Given the user wants to create and account in bank 
	When user provides the below details to create 
	| AccountName | AccountType | Initial Deposit | SSN        |
	|			  |			    |		          |			   |
	Then account is not created 
	And error message is displayed to provide details








