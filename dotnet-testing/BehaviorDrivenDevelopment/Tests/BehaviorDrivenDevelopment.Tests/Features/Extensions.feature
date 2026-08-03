Feature: Extensions
	Provide string extension methods

Background:
	Given the phrase prefix is Phrase: .

Scenario: Get Word Count
	When the phrase is <phrase>
	Then the word count is <count>

Examples:
	| phrase                         | count |
	| Behavior Driven Development    | 4     |
	| Code-Maze articles are amazing | 5     |
	| And I will subscribe for more  | 7     |

Scenario: Get Charachter Count
	When the phrase is <phrase>
	Then the char count is <count>

Examples:
	| phrase                         | count |
	| Behavior Driven Development    | 32    |
	| Code-Maze articles are amazing | 34    |
	| And I will subscribe for more  | 31    |