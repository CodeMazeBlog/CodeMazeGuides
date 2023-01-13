Feature: Extensions
	Provide string extension methods

@StringExtensions
Scenario: Get Word Count
	When the phrase is <phrase>
	Then the word count is <count>

Examples:
	| phrase                         | count |
	| Behavior Driven Development    | 3     |
	| Code-Maze articles are amazing | 4     |
	| And I will subscribe for more  | 6     |

Scenario: Get Charachter Count
	When the phrase is <phrase>
	Then the char count is <count>

Examples:
	| phrase                         | count |
	| Behavior Driven Development    | 25    |
	| Code-Maze articles are amazing | 27    |
	| And I will subscribe for more  | 24    |


