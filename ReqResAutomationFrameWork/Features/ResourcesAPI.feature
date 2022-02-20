Feature: Resources API Validation
	Verifies differents scenrios of Resources API

@smokeTest
Scenario: Verify List All Resources API
	Given a User navigates to ReqRes site for Resources 
	When the List Resources API is submitted
	Then the API Status code should be 200
	And Resource Response should contain data as <id>,<name>,<year>,<color>,<pantone_value>

	Examples:
		| id | name         | year | color   | pantone_value |
		| 1  | cerulean     | 2000 | #98B2D1 | 15-4020       |
