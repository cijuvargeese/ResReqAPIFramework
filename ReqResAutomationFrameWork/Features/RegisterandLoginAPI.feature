Feature: Register and Login API Validations
	Register API feature validations 

@smokeTest
Scenario: Verify Register User API
	Given a User navigates to ReqRes site
	And set email as <email>
	And set password
	When Register User API is submitted with payload
	Then the API Status code should be 200
	And Response should contain expected email as <expectedEmail>

	Examples:
		| email               | expectedEmail       |
		| emma.wong@reqres.in | emma.wong@reqres.in |

Scenario: Verify Unsuccessful Register User Process
	Given a User navigates to ReqRes site
	And set email as <email>
	And set password
	When Register User API is submitted with payload
	Then the API Status code should be 400
	And Response should contain error message <errorMessage>

	Examples:
		| email                 | errorMessage                                  |
		| emma.wong@reqres.inq1 | Note: Only defined users succeed registration |
		|                       | Missing email or username                     |

@smokeTest
Scenario: Verify Login User API
	Given a User navigates to ReqRes site
	And set email as <email>
	And set password
	When Login User API is submitted with payload
	Then the API Status code should be 200
	And Response should contain token

	Examples:
		| email               |
		| emma.wong@reqres.in |

Scenario: Verify Unsuccessful Login User Process
	Given a User navigates to ReqRes site
	And set email as <email>
	And set password
	When Login User API is submitted with payload
	Then the API Status code should be 400
	And Response should contain error message <errorMessage>

	Examples:
		| email                 | errorMessage              |
		| emma.wong@reqres.inq1 | user not found            |
		|                       | Missing email or username |

Scenario: Verify Unsuccessful Register User Process without password
	Given a User navigates to ReqRes site
	And set email as <email>
	And set password as null
	When Register User API is submitted with payload
	Then the API Status code should be 400
	And Response should contain error message <errorMessage>

	Examples:
		| email                | errorMessage     |
		| emma.wong@reqres.inq | Missing password |

Scenario: Verify Unsuccessful Login User Process with password
	Given a User navigates to ReqRes site
	And set email as <email>
	And set password as null
	When Login User API is submitted with payload
	Then the API Status code should be 400
	And Response should contain error message <errorMessage>

	Examples:
		| email                | errorMessage     |
		| emma.wong@reqres.inq | Missing password |