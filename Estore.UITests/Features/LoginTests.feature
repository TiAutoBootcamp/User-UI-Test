Feature: LoginTests

As a User
I would like to login via UI
In order to access to the functionality of the site depending on the user’s role in the system

Scenario: US_48_5_User login with valid credentials as a customer
	Given open main page
	Given Is Main page open
	Given User clicks on the Login button in the top right corner
	Given Is Login page open
	Given User fills email and password fields with valid customer credentials
	When User clicks Login button
	Then Main page should be open
	Then All elements are displayed correctly for the customer role
	

Scenario: US_48_6_User login with valid credentials as a admin
	Given open main page
	Given Is Main page open
	Given User clicks on the Login button in the top right corner
	Given Is Login page open
	Given User fills email and password fields with valid admin credentials
	When User clicks Login button
	Then Main page should be open
	Then All elements are displayed correctly for the admin role

Scenario: US_48_7_Check the unauthorized view  without login
	Then All elements are displayed correctly for the unauthorized view

Scenario: US_48_8_Authorized user signs out
	Given User logs in
	When User moves to Welcom message in the top right corner
	When User clicks Sign out button in the drop down list
	Then All elements are displayed correctly for the unauthorized view

Scenario: US_48_19_Login page closes after sending existing credentials
	Given Open login page
	Given User fills email and password fields with valid admin credentials
	When User clicks Login button
	Then Login page is closed

Scenario: US_48_20_Input fields are empty
	Given Open login page
	When Email and password fields are empty
	Then Login button is not clickable

Scenario: US_48_21_User types email in invalid format
	Given Open login page
	When User types email in invalid format
	
Scenario: US_48_22_User logins with registered email and wrong password
	Given Open login page

