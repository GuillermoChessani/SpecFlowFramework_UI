Feature: Login Tests

Tests to validate the Login Page

@Regression @Smoke
Scenario: Valid Login 
	Given I am inside of login page
	When I provide valid credentials and click Login button
	Then Should let me pass to and show a welcome message

@Regression
Scenario Outline: Invalid Login 
	Given I am inside of login page
	When I provide invalid <Username> and <Password> and click Login button
	Then Should not let me pass and show an error message

Examples: 
| Username        | Password   | Scenario               |
| "Administrator" | "admin123" | Wrong_Username			  |
| "Admin"         | "Admin123" | Wrong_Password		      |
| ""              | "admin123" | No_User                  |
| "Admin"         | ""         | No_Password              |
| ""              | ""         | No_User_No_Password	  |

