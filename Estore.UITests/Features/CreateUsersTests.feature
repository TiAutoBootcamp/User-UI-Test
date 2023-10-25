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
	And Help message under 'Repeat password' field should be 'Repeat the password'

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
Scenario: US_49_26_Admin adds a new customer
	Given Admin click on the Users button
	And User page is open
	And Admin click on the Add User button
	When Create user modal window is open
	And Admin fills modal window and registers new customer
	Then Create user modal window should be close
	Then New customer appeared in the users list
	And Info message 'User was added' is presented

#US_49_27
@AdminLoggedIn
Scenario: US_49_27_Admin leaves First name field empty
	Given Admin click on the Users button
	And User page is open
	And Admin click on the Add User button
	When Create user modal window is open
	And Admin fills 'First name' input field: '' 
	Then Help message under 'First name' field should be 'First name is required!'

#US_49_28
@AdminLoggedIn
Scenario: US_49_28_Admin leaves Last name field empty
	Given Admin click on the Users button
	And User page is open
	And Admin click on the Add User button
	When Create user modal window is open
	And Admin fills 'Last name' input field: '' 
	Then Help message under 'Last name' field should be 'Last name is required!'
	
#US_49_29
@AdminLoggedIn
Scenario: US_49_29_Admin leaves Email field empty
	Given Admin click on the Users button
	And User page is open
	And Admin click on the Add User button
	When Create user modal window is open
	And Admin fills 'Email' input field: '' 
	Then Help message under 'Email' field should be 'Email is required!'

#US_49_30
@AdminLoggedIn
Scenario: US_49_30_Admin leaves Password field empty
	Given Admin click on the Users button
	And User page is open
	And Admin click on the Add User button
	When Create user modal window is open
	And Admin fills 'Password' input field: '' 
	Then Help message under 'Password' field should be 'Password is required!'

#US_49_31a
@AdminLoggedIn
Scenario: US_49_31a_Admin leaves Repeat password field empty
	Given Admin click on the Users button
	And User page is open
	And Admin click on the Add User button
	When Create user modal window is open
	And Admin fills 'Repeat password' input field: '' 
	Then Help message under 'Repeat password' field should be 'Repeat password is required!'
	
#US_49_31b
@AdminLoggedIn
Scenario: US_49_31b_Admin fills Password and Repeat password fields different values
	Given Admin click on the Users button
	And User page is open
	And Admin click on the Add User button
	When Create user modal window is open
	And Admin fills 'Password' input field: 'randomValue'
	And Admin fills 'Repeat password' input field: 'randomValue' 
	Then Help message under 'Repeat password' field should be 'Passwords don"t match'
		
#US_49_32
@AdminLoggedIn
Scenario: US_49_32_Admin fills Password field with invalid value
	Given Admin click on the Users button
	And User page is open
	And Admin click on the Add User button
	When Create user modal window is open
	And Admin fills 'Password' input field: '<password>'
	Then Help message under 'Password' field should be '<message>'
	Examples: 
	| password                | message                                             |
	| short                   | Password must be at least of length 4               |
	| long                    | Password must beno more than 32 characters          |
	| withoutLowerCaseLetters | Password must contain at least one lowercase letter |
	| withoutUpperCaseLetters | Password must contain at least one capital letter   |
	| withoutDigits           | Password must contain at least one digit            |

#US_49_33
@AdminLoggedIn
Scenario: US_49_33_Admin fills Email field with invalid value
	Given Admin click on the Users button
	And User page is open
	And Admin click on the Add User button
	When Create user modal window is open
	And Admin fills 'Email' input field: '<email>' 
	Then Help message under 'Email' field should be 'The email address is invalid'
	Examples: 
	| email             |
	| @example.com      |
	| user@.com         |
	| user@com          |
	| user@example.c    |
	| user@example..co  |
	| user@.example.com |
	| user@example      |
	| user.com          |