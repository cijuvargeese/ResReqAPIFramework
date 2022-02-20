Feature: Users API Validation
	Verifies differents scenrios of Users API

@mytag
Scenario: Verify List All Users API
	Given a User navigates to ReqRes site for Users
	When the List Users API is submitted for page "2"
	Then the User API Statuscode should be 200
	And User Response should contain data as <id>,<email>,<first_name>,<last_name>,<avatar>

	Examples:
		| id | email                      | first_name | last_name | avatar                                  |
		| 7  | michael.lawson@reqres.in   | Michael    | Lawson    | https://reqres.in/img/faces/7-image.jpg |
		| 8  | lindsay.ferguson@reqres.in | Lindsay    | Ferguson  | https://reqres.in/img/faces/8-image.jpg |

Scenario: Verify List Single User API
	Given a User navigates to ReqRes site for Users
	When the List Single User API is submitted for <id>
	Then the User API Statuscode should be 200
	And Single User Response should contain data as <id>,<email>,<first_name>,<last_name>,<avatar>

	Examples:
		| id | email                      | first_name | last_name | avatar                                  |
		| 2  | janet.weaver@reqres.in     | Janet      | Weaver    | https://reqres.in/img/faces/2-image.jpg |
		| 8  | lindsay.ferguson@reqres.in | Lindsay    | Ferguson  | https://reqres.in/img/faces/8-image.jpg |


Scenario: Verify Unknown User API
	Given a User navigates to ReqRes site for Users
	When the List Single User API is submitted for <id>
	Then the User API Statuscode should be 404
