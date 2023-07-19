Feature: Users


#Scenario: Open page
#	Given the users page and opened
#	And the name I search a user 'Jhon' with last name 'Smith'
#	#When I click to the details button


Scenario: UMS8_DetailsModal_CreateAUserAndOpenTheDetails_AModalIsOpened
	Given a user created
	When I write a Guid name to first name field
	And click on the search button
	And click on the details button
	Then a modal with details is opened
	
Scenario: UMS9_DetailsModal_CreateAUserOpenTheDetailsModal_TheFieldAreCorrectAndInOrder
	Given a user created
	When I write a Guid name to first name field
	And click on the search button
	And click on the details button
#	Then the fields are correct and ordered 

Scenario: UMS10_DetailsModal_CreateAUserOpenTheDetailsModal_TheInformationMatchWithTheUser
	Given a user created
	When I write a Guid name to first name field
	And click on the search button
	And click on the details button
	Then the information on the modal match with the user

Scenario: UMS11_DetailsModal_CreateUserAndChangeStatusToActiveOpenTheDetailsModal_TheInformationMatchWithTheUser
	Given a user created
	And change the user status to active
	When I write a Guid name to first name field
	And click on the search button
	And click on the details button
	Then the information on the modal match with the user 

Scenario Outline: UMS12_DetailsModal_CreateUserAndChangeStatusTwiceToActiveOpenTheDetailsModal_TheInformationMatchWithTheUser
	Given a user created
	And change the user status to <FirstStatus>
	And change second time the user status to <SecodStatus>
	When I write a Guid name to first name field
	And click on the search button
	And click on the details button
	Then the information on the modal match with the user 
	Examples: 
		| FirstStatus | SecondStatus |
		| True        | False        |

Scenario Outline: UMS13_DetailsModal_CreateUserAndChangeStatusThriceToActiveOpenTheDetailsModal_TheInformationMatchWithTheUser
	Given a user created
	And change the user status to <FirstStatus>
	And change second time the user status to <SecodStatus>
	And change third time the user status to <ThirdStatus>
	When I write a Guid name to first name field
	And click on the search button
	And click on the details button
	Then the information on the modal match with the user 
	Examples: 
		| FirstStatus | SecondStatus | ThirdStatus |
		| True        | False        | True        |

Scenario: UMS14_DetailsModal_CreateAUserAndOpenTheDetailsAndCloseWithX_TheModalClose
	Given a user created
	When I write a Guid name to first name field
	And click on the search button
	And click on the details button
	And click on the primary close button
	Then the modal is closed

Scenario:UMS15_DetailsModal_CreateAUserAndOpenTheDetailsAndClickTheCloseButton_TheModalClose
	Given a user created
	When I write a Guid name to first name field
	And click on the search button
	And click on the details button
	And click on the secondary close button
	Then the modal is closed
