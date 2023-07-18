Feature: Users


#Scenario: Open page
#	Given the users page and opened
#	And the name I search a user 'Jhon' with last name 'Smith'
#	#When I click to the details button


Scenario: UMS8_DetailsModal_CreateAUserAndOpenTheDetails_AModalIsOpened
	Given a user created
	When I write a Guid name to first name field
#	And click on the search
#	And click on the details button
#	Then a modal is opened
#	
#Scenario: UMS9_DetailsModal_CreateAUserOpenTheDetailsModal_TheFieldAreCorrectAndInOrder
#	When I write a Guid name to first name field
#	And click on the search
#	And click on the details button
#	Then the fields are correct and ordered 
#
#Scenario: UMS10_DetailsModal__CreateAUserOpenTheDetailsModal_TheInformationMatchWithTheUser
#	When I write a Guid name to first name field
#	And click on the search
#	And click on the details button
#	Then the information on the modal match with the user