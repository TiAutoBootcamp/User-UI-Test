Feature: AddUserModalWindowTest

As a Manager
I would like to check user transactions via UI
In order to create sales report based on that.

Background: 
	Given open users page

Scenario: UMS49_AddUserModal_CreateUserWithDateBirthEmpty_UserCreatedCorrectly
	Given a user open the create user modal
	When I write a name on the fields
	And click on the save button
	And I write a name on the filter
	And click on the search button
	And click on the details button
	And get all the information from the modal
	Then the basic information on the modal match with the set data
	


	
Scenario: UMS50_AddUserModal_CreateUserWithDateBirth_UserCreatedCorrectly
	Given a user open the create user modal 
	When I write a name on the fields
	And select the birthdate <expectedBirthDate>
	And click on the save button
	When I write a name on the filter
	And click on the search button
	And click on the details button
	Then the information on the modal match with the set data
	Examples: 
		| expectedStatus | expectedBirthDate |
		| false          | 12.07.2023        |
		| false          | 07/01/2023        |

Scenario: UMS51_AddUserModal_CreateUserWithDateBirth_APIInformationMatch
	Given a user open the create user modal 
	When I write a name on the fields
	And select the birthdate <expectedBirthDate>
	And click on the save button
	And I write a name on the filter
	And click on the search button
	And click on the details button
	Then the information on the modal match with the set data
	Examples: 
		| expectedStatus | expectedBirthDate |
		| false          | 12.07.2023        |
		| false          | 07/01/2023        |

Scenario: UMS52_AddUserModal_CreateUserSelectDateBirthAndThenChange_UserCreatedCorrectly
	Given a user open the create user modal 
	When I write a name on the fields
	And select the birthdate <firstBirthDate>
	And change the birthdate <expectedBirthDate>
	And click on the save button
	And I write a name on the filter
	And click on the search button
	And click on the details button
	Then the information on the modal match with the set data
	Examples: 
		| expectedStatus | expectedBirthDate | firstBirthDate |
		| false          | 12.07.2023        |  07/01/2023 	  |
	

Scenario: UMS53_AddUserModal_FillTheModalDataCloseTheModalAndOpenAgain_TheFieldsAreEmpty
	Given a user open the create user modal 
	When I write a name on the fields
	And select the birthdate <firstBirthDate>
	And click on the close button
	And click on the add user button
	Then the fields are empty
	Examples: 
		| expectedBirthDate |
		| 12.07.2023        |
		| 07/01/2023        |

Scenario: UMS54_AddUserModal_FillTheModalAndWriteInvalidBirthDate_TheFieldsAreEmpty
	Given a user open the create user modal 
	When I write a name on the fields
	And write the birthdate <firstBirthDate>
	And click on the close button
	And click on the add user button
	Then the fields are empty
	Examples: 
		| expectedBirthDate |
		| 21.10.2023        |
	

Scenario: UMS55_AddUserModal_FillTheModalDataCloseTheModalAndOpenAgain_TheFieldsAreEmpty
	Given a user open the create user modal 
	When I write a name on the fields
	And select the birthdate <firstBirthDate>
	And click on the close button
	And click on the add user button
	Then the fields are empty