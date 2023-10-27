Feature: LoginTests

As a User
I would like to login via UI
In order to access to the functionality of the site depending on the user’s role in the system

#US48_5
Scenario: US48_5_User login with valid credentials as a customer
	Given Open main page
	And Main page is opened
	And User clicks on the Login link
	When Login page is opened
	And User fills email and password fields with 'Customer' credentials
	And User clicks Login button
	Then Main page is opened
	And Welcome message is correct
	And Navigation bar has next items called
	| itemNames |
	| Main      |	
		
#US48_6
Scenario: US48_6_User login with valid credentials as a admin
	Given Open main page
	And Main page is opened
	And User clicks on the Login link
	When Login page is opened
	And User fills email and password fields with 'Admin' credentials
	And User clicks Login button
	Then Main page is opened
	And Welcome message is correct
	And Navigation bar has next items called 
	| itemNames |
	| Main      |
	| Catalog   |
	| Users     |
	| Home      |	
	
#US48_7
Scenario: US48_7_Check the unauthorized view  without login
	Given Open main page
	When Main page is opened
	Then Login button is displayed
	And Navigation bar has next items called
	| itemNames |
	| Main      |
	
#US48_8
Scenario: US48_8_Authorized user signs out
	Given Open login page
	And Login page is opened
	And User fills email and password fields with 'Admin' credentials
	And User clicks Login button
	And Main page is opened
	When User moves to Welcome message
	And User clicks Sign out button
	Then Login button is displayed
	And Navigation bar has next items called
	| itemNames |
	| Main      |
	
#US48_19
Scenario: US48_19_Login page closes after sending existing credentials
	Given Open login page
	And Login page is opened
	When User fills email and password fields with 'Admin' credentials
	And User clicks Login button
	Then Login page is closed

#US48_20
Scenario: US48_20_Input fields are empty
	Given Open login page
	And Login page is opened
	When User fills email and password fields with 'Empty' credentials
	Then Login button is disabled
	And A help message 'Required' for 'email' field is presented
	And A help message 'Password is required' for 'password' field is presented

#US48_21
Scenario Outline: US48_21_User types email in invalid format
	Given Open login page
	And Login page is opened
	When User fills email field with <invalidFormat>
	Then A help message 'Invalid email format.' for 'email' field is presented
	Examples:
	| invalidFormat      |
	| @example.com       |
	| admin@.com         |
	| admin@com          |
	| admin@example.c    |
	| admin@example..co  |
	| admin@.example.com |
	| admin@example      |
	| admin.com          |

#US48_22
Scenario Outline: US48_22_User logins with unregistered email or(and) wrong password
	Given Open login page
	And Login page is opened
	When User fills <email> and <password> fields
	And User clicks Login button
	Then Login page is opened
	And Info message 'Wrong credentials' is presented
	Examples:
	| email        | password |
	| registered   | wrong    |
	| unregistered | wrong    |
	| wrong        | exist    |