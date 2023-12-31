﻿Feature: CreateUsersTests

As a Admin
I would like to create new customer via UI

#US49_25a
@AdminLoggedIn
Scenario: US49_25a_Admin abserve the layout and elements on the Create user modal window
	Given Admin click on the Users button
	And Users page is opened
	When Admin click on the Add User button
	Then Create user modal window is opened
	And Create user modal window contains fields: 
	| fieldNames |
	| First name |
	| Last name  |
	| Email      |
	| Password   |
	| Password   |
	And Register button should be disabled
	And Help message under 'Password' field should be 'Choose a strong password'
	And Help message under 'Repeat password' field should be 'Repeat the password'

#US49_25b
@AdminLoggedIn
Scenario: US49_25b_Admin closes Create user modal window
	Given Admin click on the Users button
	And Users page is opened
	And Admin click on the Add User button
	When Create user modal window is opened
	And Admin click on the Cancel button
	Then Create user modal window is closed

#US49_26
@AdminLoggedIn
Scenario: US49_26_Admin adds a new customer
	Given Admin click on the Users button
	And Users page is opened
	And Admin click on the Add User button
	When Create user modal window is opened
	And Admin fills create user modal window valid data
	And Admin clicks on the Register button
	Then Create user modal window is closed
	Then New customer appeared in the users list
	And Info message 'User succesfully created' is presented

#US49_27
#US49_28
#US49_29
#US49_30
#US49_31a
@AdminLoggedIn
Scenario Outline: US49_27_28_29_30_31a_Admin leaves one of the input field empty
	Given Admin click on the Users button
	And Users page is opened
	And Admin click on the Add User button
	When Create user modal window is opened
	And Admin fills '<fieldName>' input field '' and move focus 
	Then Help message under '<fieldName>' field should be '<message>'
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
	And Users page is opened
	And Admin click on the Add User button
	When Create user modal window is opened
	And Admin fills 'Password' input field 'randomValue'
	And Admin fills 'Repeat password' input field 'randomValue' and move focus  
	Then Help message under 'Repeat password' field should be 'Passwords don't match'

#US49_32
@AdminLoggedIn
Scenario Outline: US49_32_Admin fills Password field with invalid value
	Given Admin click on the Users button
	And Users page is opened
	And Admin click on the Add User button
	When Create user modal window is opened
	And Admin fills 'Password' input field '<password>' and move focus
	Then Help message under 'Password' field should be '<message>'
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
	And Users page is opened
	And Admin click on the Add User button
	When Create user modal window is opened
	And Admin fills 'Email' input field '<email>' and move focus 
	Then Help message under 'Email' field should be 'Invalid email format'
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

#US49_33a
@AdminLoggedIn
Scenario: US49_33a_Admin create customer with existing email
	Given Admin click on the Users button
	And Users page is opened
	And Admin click on the Add User button
	When Create user modal window is opened
	And Admin fills create user modal window with existing email 
	And Admin clicks on the Register button
	Then Create user modal window is opened
	And Info message 'Error: Ambiguous match found.' is presented

#US147_2
@AdminLoggedIn
Scenario: US147_2_Admin fills in fields of valid data, clear one of the input fields and moves focus
	Given Admin click on the Users button
	And Users page is opened
	And Admin click on the Add User button
	When Create user modal window is opened
	And Admin fills create user modal window valid data
	And Admin clears '<fieldName>' field and move focus
	Then Help message under '<fieldName>' field should be '<message>'
	And Register button should be disabled
	Examples: 
	| fieldName       | message                 |
	| First name      | First name is required! |
	| Last name       | Last name is required!  |
	| Email           | Email is required!      |
	| Password        | Password is required!   |
	| Repeat password | Passwords don't match   |

#US147_3
@AdminLoggedIn
Scenario: US147_3_Admin fills in fields of valid data, clear one of the field and clicks Register button
	Given Admin click on the Users button
	And Users page is opened
	And Admin click on the Add User button
	When Create user modal window is opened
	And Admin fills create user modal window valid data
	And Admin clears '<fieldName>' field
	And Admin clicks on the Register button
	Then Create user modal window is opened
	And Help message under '<fieldName>' field should be '<message>'
	And Register button should be disabled
	Examples: 
	| fieldName       | message                 |
	| First name      | First name is required! |
	| Last name       | Last name is required!  |
	| Email           | Email is required!      |
	| Password        | Password is required!   |
	| Repeat password | Passwords don't match   |

#US147_4
@AdminLoggedIn
Scenario: US147_4_Admin fills in fields of valid data, changes password to a new valid password and clicks Register button
	Given Admin click on the Users button
	And Users page is opened
	And Admin click on the Add User button
	When Create user modal window is opened
	And Admin fills create user modal window valid data
	And Admin clears 'Password' field
	And Admin fills 'Password' input field 'randomValue'
	And Admin clicks on the Register button
	Then Create user modal window is opened
	And Help message under 'Repeat password' field should be 'Passwords don't match'
	And Register button should be disabled
	
#US147_5
@AdminLoggedIn
Scenario: US147_5_Admin fills in fields of valid data, changes password to an invalid password and clicks Register button
	Given Admin click on the Users button
	And Users page is opened
	And Admin click on the Add User button
	When Create user modal window is opened
	And Admin fills create user modal window valid data
	And Admin clears 'Password' field
	And Admin fills 'Password' input field 'w' and move focus 
	And Admin clicks on the Register button
	Then Create user modal window is opened
	And Help message under 'Password' field should be 'Password must be at least of length 4'
	And Help message under 'Repeat password' field should be 'Passwords don't match'
	And Register button should be disabled
	
#US147_6
@AdminLoggedIn
Scenario: US147_6_Admin fills in fields of valid data, changes email to an invalid email format and clicks Register button
	Given Admin click on the Users button
	And Users page is opened
	And Admin click on the Add User button
	When Create user modal window is opened
	And Admin fills create user modal window valid data
	And Admin clears 'Email' field
	And Admin fills 'Email' input field '@example.cv' and move focus 
	And Admin clicks on the Register button
	Then Create user modal window is opened
	And Help message under 'Email' field should be 'Invalid email format'
	And Register button should be disabled