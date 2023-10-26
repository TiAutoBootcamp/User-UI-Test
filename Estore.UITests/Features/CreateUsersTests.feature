Feature: CreateUsersTests

As a Admin
I would like to create new customer via UI

#US49_25a
@AdminLoggedIn
Scenario: US49_25a_Admin abserve the layout and elements on the Create user modal window
	Given Admin click on the Users button
	And User page is open
	When Admin click on the Add User button
	Then Create user modal window should be open
	And Create user modal window contains fields: 
	| fieldNames |
	| First name |
	| Last name  |
	| Email      |
	| Password   |
	| Password   |
	And Register button should be disabled
	And Help message under "Password" field should be "Choose a strong password"
	And Help message under "Repeat password" field should be "Repeat the password"

#US49_25b
@AdminLoggedIn
Scenario: US49_25b_Admin closes Create user modal window
	Given Admin click on the Users button
	And User page is open
	And Admin click on the Add User button
	When Create user modal window is open
	And Admin click on the Cancel button
	Then Create user modal window should be close

#US49_26
@AdminLoggedIn
Scenario: US49_26_Admin adds a new customer
	Given Admin click on the Users button
	And User page is open
	And Admin click on the Add User button
	When Create user modal window is open
	And Admin fills modal window and registers new customer
	Then Create user modal window should be close
	Then New customer appeared in the users list
	And Info message 'User was added' is presented

#US49_27
#US49_28
#US49_29
#US49_30
#US49_31a
@AdminLoggedIn
Scenario Outline: US49_27_28_29_30_31a_Admin leaves one of the input field empty
	Given Admin click on the Users button
	And User page is open
	And Admin click on the Add User button
	When Create user modal window is open
	And Admin fills '<fieldName>' input field: '' 
	Then Help message under "<fieldName>" field should be "<message>"
	Examples: 
	| fieldName       | message                      |
	#US49_27
	| First name      | First name is required!      |
	#US49_28
	| Last name       | Last name is required!       |
	#US49_29
	| Email           | Email is required!           |
	#US49_30
	| Password        | Password is required!        |
	#US49_31a
	| Repeat password | Repeat password is required! |

#US49_31b
@AdminLoggedIn
Scenario: US49_31b_Admin fills Password and Repeat password fields different values
	Given Admin click on the Users button
	And User page is open
	And Admin click on the Add User button
	When Create user modal window is open
	And Admin fills 'Password' input field: 'randomValue'
	And Admin fills 'Repeat password' input field: 'randomValue' 
	Then Help message under "Repeat password" field should be "Passwords don't match"
		
#US49_32
@AdminLoggedIn
Scenario Outline: US49_32_Admin fills Password field with invalid value
	Given Admin click on the Users button
	And User page is open
	And Admin click on the Add User button
	When Create user modal window is open
	And Admin fills 'Password' input field: '<password>'
	Then Help message under "Password" field should be "<message>"
	Examples: 
	| password                | message                                             |
	| short                   | Password must be at least of length 4               |
	| long                    | Password must be no more than 32 characters         |
	| withoutLowerCaseLetters | Password must contain at least one lowercase letter |
	| withoutUpperCaseLetters | Password must contain at least one capital letter   |
	| withoutDigits           | Password must contain at least one digit            |

#US49_33
@AdminLoggedIn
Scenario Outline: US49_33_Admin fills Email field with invalid value
	Given Admin click on the Users button
	And User page is open
	And Admin click on the Add User button
	When Create user modal window is open
	And Admin fills 'Email' input field: '<email>' 
	Then Help message under "Email" field should be "The email address is invalid"
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