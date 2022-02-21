Feature: Resources API Validation
	Verifies differents scenrios of Resources API

@smokeTest
Scenario: Verify List All Resources API
	Given a User navigates to ReqRes site
	When the List Resources API is submitted
	Then the API Status code should be 200
	And Resource Response should contain data as <id>,<expectedname>,<expectedyear>,<expectedcolor>,<expectedpantone_value>

	Examples:
		| id | expectedname | expectedyear | expectedcolor | expectedpantone_value |
		| 1  | cerulean     | 2000         | #98B2D1       | 15-4020               |

@smokeTest
Scenario: Verify List Single Resource API
	Given a User navigates to ReqRes site
	When the List Resources API is submitted for <id>
	Then the API Status code should be <responsecode>
	And Single Resource Response should contain data as <id>,<expectedname>,<expectedyear>,<expectedcolor>,<expectedpantone_value>

	Examples:
		| id | expectedname | expectedyear | expectedcolor | expectedpantone_value | responsecode |
		| 1  | cerulean     | 2000         | #98B2D1       | 15-4020               | 200          |

@smokeTest
Scenario: Verify Resource API behaviour when ID is not present in system
	Given a User navigates to ReqRes site
	When the List Resources API is submitted for <id>
	Then the API Status code should be 404

	Examples:
		| id |
		| 23 |