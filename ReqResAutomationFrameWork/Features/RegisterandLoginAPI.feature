Feature: Register and Login API Validations
	Register API feature validations 

@smokeTest
Scenario: Verify Register User API
	Given a User navigates to ReqRes site
	And set email as <email>
	And set password as <password>
	When Register User API is submitted with payload
	Then the API Status code should be 200
	And Response should contain expected email as <expectedEmail>

	Examples:
		| email               | password | expectedEmail       |
		| emma.wong@reqres.in | pistol   | emma.wong@reqres.in |

Scenario: Verify Unsuccessful Register User Process
	Given a User navigates to ReqRes site
	And set email as <email>
	And set password as <password>
	When Register User API is submitted with payload
	Then the API Status code should be 400
	And Response should contain error message <errorMessage>

	Examples:
		| email                 | password | errorMessage                                  |
		| emma.wong@reqres.inq1 | pistol   | Note: Only defined users succeed registration |
		| emma.wong@reqres.inq  |          | Missing password                              |
		|                       | pistol   | Missing email or username                     |

@smokeTest
Scenario: Verify Login User API
	Given a User navigates to ReqRes site
	And set email as <email>
	And set password as <password>
	When Login User API is submitted with payload
	Then the API Status code should be 200
	And Response should contain token

	Examples:
		| email               | password |
		| emma.wong@reqres.in | pistol   |

Scenario: Verify Unsuccessful Login User Process
	Given a User navigates to ReqRes site
	And set email as <email>
	And set password as <password>
	When Login User API is submitted with payload
	Then the API Status code should be 400
	And Response should contain error message <errorMessage>

	Examples:
		| email                 | password | errorMessage              |
		| emma.wong@reqres.inq1 | pistol   | user not found            |
		| emma.wong@reqres.inq  |          | Missing password          |
		|                       | pistol   | Missing email or username |