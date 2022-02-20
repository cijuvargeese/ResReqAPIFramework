Feature: Users API Validation
	Verifies differents scenrios of Users API

@smokeTest
Scenario: Verify List All Users API
	Given a User navigates to ReqRes site
	When the List Users API is submitted for page "2"
	Then the API Status code should be 200
	And User Response should contain data as <id>,<email>,<first_name>,<last_name>,<avatar>

	Examples:
		| id | email                      | first_name | last_name | avatar                                  |
		| 7  | michael.lawson@reqres.in   | Michael    | Lawson    | https://reqres.in/img/faces/7-image.jpg |
		| 8  | lindsay.ferguson@reqres.in | Lindsay    | Ferguson  | https://reqres.in/img/faces/8-image.jpg |

@smokeTest
Scenario: Verify List Single User API
	Given a User navigates to ReqRes site
	When the List Single User API is submitted for <id>
	Then the API Status code should be 200
	And Single User Response should contain data as <id>,<email>,<first_name>,<last_name>,<avatar>

	Examples:
		| id | email                      | first_name | last_name | avatar                                  |
		| 2  | janet.weaver@reqres.in     | Janet      | Weaver    | https://reqres.in/img/faces/2-image.jpg |
		| 8  | lindsay.ferguson@reqres.in | Lindsay    | Ferguson  | https://reqres.in/img/faces/8-image.jpg |

@smokeTest
Scenario: Verify Unknown User API
	Given a User navigates to ReqRes site
	When the List Single User API is submitted for <id>
	Then the API Status code should be 404

Scenario: Verify Create User API
	Given a User navigates to ReqRes site
	And set Create User name as <name>
	And set Create User job as <job>
	When Create User API is submitted with payload
	Then the API Status code should be 201
	And Response should contain an valid ID

	Examples:
		| name     | job    | expectedname | expectedjob |
		| morpheus | leader | morpheus     | leader      |