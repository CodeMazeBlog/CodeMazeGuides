Feature: Helpers
	Provide numbers related helper methods

@Numbers
Scenario: Sum Two Numbers
	Given the first number is 35
	When the second number is 25
	Then the result should be 60

Scenario: Subtract Two Numbers
	Given the first number is 35
	When the second number is 25
	Then the subtract result should be 10

Scenario: Average of three numbers
	Given the first number is 35
	And the second number is 25
	And the third number is 33
	Then the average is 31