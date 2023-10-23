Feature: LoginTests

As a User
I would like to login via UI
In order to access to the functionality of the site depending on the user’s role in the system

#US_48_5
Scenario: US_48_5_User login with valid credentials as a customer
	Given open main page
	And Main page is open
	And User opens login page clicking on the Login button
	When Login page is open
	And User fills email and password fields with 'Customer' credentials
	And User clicks Login button
	Then Main page should be open
	And Welcome message is correct
	And Navigation bar has next <item>
	Examples:
	| item |
	| Main |
	
#US_48_6
Scenario: US_48_6_User login with valid credentials as a admin
	Given open main page
	And Main page is open
	And User opens login page clicking on the Login button
	When Login page is open
	And User fills email and password fields with 'Admin' credentials
	And User clicks Login button
	Then Main page should be open
	And Welcome message is correct
	And Navigation bar has next <items>
	Examples:
	| items                         |
	| Main - Catalog - Users - Home |

#US_48_7
Scenario: US_48_7_Check the unauthorized view  without login
	Given open main page
	When Main page is open
	Then Login button is displayed
	And Navigation bar has next <item>
	Examples:
	| item |
	| Main  |
	
#US_48_8
Scenario: US_48_8_Authorized user signs out
	Given Open login page
	And Login page is open
	And User fills email and password fields with 'Admin' credentials
	And User clicks Login button
	And Main page is open
	When User moves to Welcome message
	And User clicks Sign out button
	Then Login button is displayed
	And Navigation bar has next <item>
	Examples:
	| item |
	| Main  |

#US_48_19
Scenario: US_48_19_Login page closes after sending existing credentials
	Given Open login page
	And Login page is open
	When User fills email and password fields with 'Admin' credentials
	And User clicks Login button
	Then Login page is closed

#US_48_20
Scenario: US_48_20_Input fields are empty
	Given Open login page
	And Login page is open
	When User fills email and password fields with 'Empty' credentials
	Then Login button is not clickable

#US_48_21
Scenario: US_48_21_User types email in invalid format
	Given Open login page
	When User fills email field in <invalidFormat>
	Then A prompt message 'Email should be contain...' is presented
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

#US_48_22
Scenario: US_48_22_User logins with unregistered email or(and) wrong password
	Given Open login page
	And Login page is open
	When User fills <email> and <password> field
	And User clicks Login button
	Then Login page should be open
	And Error message '' is presented
	Examples:
	| email        | password |
	| registered   | wrong    |
	| unregistered | wrong    |


