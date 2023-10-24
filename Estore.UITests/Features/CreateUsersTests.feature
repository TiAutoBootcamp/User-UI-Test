Feature: CreateUsersTests

As a Admin
I would like to create new customer via UI

#US_49_25a
@AdminLoggedIn
Scenario: US_49_25a_Admin abserve the layout and elements on the Create user modal window
	Given Admin click on the Users button
	And User page is open
	When Admin click on the Add User button
	Then Create user modal window should be open
	And Create user modal window contains fields: 'First name, Last name, Email, Password, Password'
	And Register button should be disabled
	And Help message under 'Password' field should be 'Choose a strong password'
	And Help message under 'Repeat Password' field should be 'Repeat the password'

#US_49_25b
@AdminLoggedIn
Scenario: US_49_25b_Admin closes Create user modal window
	Given Admin click on the Users button
	And User page is open
	And Admin click on the Add User button
	When Create user modal window is open
	And Admin click on the Cancel button
	Then Create user modal window should be close

#US_49_26
@AdminLoggedIn
Scenario: Empty first name
	Given Admin click on the Users button
	And User page is open
	And Admin click on the Add User button
	When Create user modal window is open
	And Admin fills modal window and registers new customer
	Then Create user modal should be close
	And New Customer appeared in the user list
	And Info message 'User was added' is presented

#US_49_27
@AdminLoggedIn
Scenario: US_49_27_Admin leaves First name field empty
	Given Admin click on the Users button
	And User page is open
	And Admin click on the Add User button
	When Create user modal window is open
	And Admin fills 'First name' input field: ''  
	Then Warning message in 'First name' is 'First name is required!'

#US_49_28
@AdminLoggedIn
Scenario: US_49_28_Admin leaves Last name field empty
	Given Admin click on the Users button
	And User page is open
	And Admin click on the Add User button
	When Create user modal window is open
	And Admin fills 'Last name' input field: '' 
	Then Warning message in 'Last name' is 'Last name is required!'

#US_49_29
@AdminLoggedIn
Scenario: US_49_28_Admin leaves Email field empty
	Given Admin click on the Users button
	And User page is open
	And Admin click on the Add User button
	When Create user modal window is open
	And Admin fills 'Email' input field: '' 
	Then Warning message in 'Email' is 'Email is required!'

#US_49_30
@AdminLoggedIn
Scenario: US_49_30_Admin leaves Password field empty
	Given Admin click on the Users button
	And User page is open
	And Admin click on the Add User button
	When Create user modal window is open
	And Admin fills 'Password' input field: '' 
	Then Warning message in 'Password' is 'Password is required!'

#US_49_31
@AdminLoggedIn
Scenario: US_49_31_Admin leaves Repeat password field empty
	Given Admin click on the Users button
	And User page is open
	And Admin click on the Add User button
	When Create user modal window is open
	And Admin fills 'Repeat password' input field: '' 
	Then Warning message in 'Repeat password' is 'Repeat password is required!'

#US_49_31b
@AdminLoggedIn
Scenario: US_49_31b_Admin fills Password and Repeat password fields different values
	Given Admin click on the Users button
	And User page is open
	And Admin click on the Add User button
	When Create user modal window is open
	And Admin fills 'Password' input field: 'qweR1'
	And Admin fills 'Repeat password' input field: 'QWEr1' 
	Then Warning message in 'Repeat password' is 'Passwords don't match'

#US_49_32
@AdminLoggedIn
Scenario: US_49_32_Admin fills Password field with invalid value
	Given Admin click on the Users button
	And User page is open
	And Admin click on the Add User button
	When Create user modal window is open
	And Admin fills 'Password' input field: <'password'> 
	Then Warning message in 'Password' is <'message'>
	Examples: 
	| password               | message                                           |
	| short                  | Password must be at least of length 4             |
	| long                   | Password must beno more than 32 characters        |
	| withotLowerCaseLetters | Password must contain at least one capital letter |
	| withotUpperCaseLetters | Password must contain at least one capital letter |
	| withotDigits           | Password must contain at least one digit          |

#US_49_33
@AdminLoggedIn
Scenario: US_49_33_Admin leaves Email field empty
	Given Admin click on the Users button
	And User page is open
	And Admin click on the Add User button
	When Create user modal window is open
	And Admin fills 'Email' input field: <''> 
	Then Warning message in 'Email' is 'The email address is invalid'
	Examples: 
	| emai              |
	| @example.com      |
	| user@.com         |
	| user@com          |
	| user@example.c    |
	| user@example..co  |
	| user@.example.com |
	| user@example      |
	| user.com          |

