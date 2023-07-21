Feature: Users

Background: 
	Given open users page

#Scenario: Open page
#	Given the users page and opened
#	And the name I search a user 'Jhon' with last name 'Smith'
#	#When I click to the details button

Scenario: UMS08_DetailsModal_CreateAUserAndOpenTheDetails_AModalIsOpened
	Given a user created
	When I write a name on the filter
	And click on the search button
	And click on the details button
	Then a modal with details is opened
	
Scenario: UMS09_DetailsModal_CreateAUserOpenTheDetailsModal_TheFieldAreCorrectAndInOrder
	Given a user created
	When I write a name on the filter
	And click on the search button
	And click on the details button
	Then the fields are correct and ordered 
# Add to the testing
Scenario: UMS31_DetailsModal_CreateAUserOpenTheDetailsModal_TheInformationMatchWithTheUser
	Given a user created
	When I write a name on the filter
	And click on the search button
	And click on the details button
	And get all the information from the modal
	Then the information on the modal match with the complete user name, <expectedStatus> and <expectedBirthDate>
	Examples: 
		| expectedStatus | expectedBirthDate |
		| false          | empty             |

Scenario: UMS10_DetailsModal_CreateAUserOpenTheDetailsModal_TheInformationMatchWithTheUser
	Given a user created wih birth date <expectedBirthDate>
	When I write a name on the filter
	And click on the search button
	And click on the details button
	And get all the information from the modal
	Then the information on the modal match with the complete user name, <expectedStatus> and <expectedBirthDate>
	Examples: 
		| expectedStatus | expectedBirthDate |
		| false          | 12.07.2023        |
		| false          | 07/01/2023        |

Scenario Outline: UMS11_DetailsModal_CreateUserAndChangeStatusToActiveOpenTheDetailsModal_TheInformationMatchWithTheUser
	Given a user created wih birth date <expectedBirthDate>
	And change the user status to <status>
	When I write a name on the filter
	And click on the search button
	And click on the details button
	And get all the information from the modal
	Then the information on the modal match with the complete user name, <expectedStatus> and <expectedBirthDate>
	Examples: 
		| status | expectedStatus | expectedBirthDate |
		| true   | true           | 12.07.2023        |

Scenario Outline: UMS12_DetailsModal_CreateUserAndChangeStatusTwiceToActiveOpenTheDetailsModal_TheInformationMatchWithTheUser
	Given a user created wih birth date <expectedBirthDate>
	And change the user status to <FirstStatus>
	And change second time the user status to <SecondStatus>
	When I write a name on the filter
	And click on the search button
	And click on the details button
	And get all the information from the modal
	Then the information on the modal match with the complete user name, <expectedStatus> and <expectedBirthDate>
	Examples: 
		| FirstStatus | SecondStatus | expectedStatus | expectedBirthDate |
		| true        | false        | false          | 12.07.2023        |

Scenario Outline: UMS13_DetailsModal_CreateUserAndChangeStatusThriceToActiveOpenTheDetailsModal_TheInformationMatchWithTheUser
	Given a user created wih birth date like <expectedBirthDate>
	And change the user status to <FirstStatus>
	And change second time the user status to <SecondStatus>
	And change third time the user status to <ThirdStatus>
	When I write a name on the filter
	And click on the search button
	And click on the details button
	And get all the information from the modal
	Then the information on the modal match with the complete user name, <expectedStatus> and <expectedBirthDate>
	Examples: 
		| FirstStatus | SecondStatus | ThirdStatus | expectedStatus | expectedBirthDate |
		| true        | false        | true        | true           | 12.07.2023        |

Scenario: UMS14_DetailsModal_CreateAUserAndOpenTheDetailsAndCloseWithX_TheModalClose
	Given a user created
	When I write a name on the filter
	And click on the search button
	And click on the details button
	And click on the primary close button
	Then the modal is closed

Scenario:UMS15_DetailsModal_CreateAUserAndOpenTheDetailsAndClickTheCloseButton_TheModalClose
	Given a user created
	When I write a name on the filter
	And click on the search button
	And click on the details button
	And click on the secondary close button
	Then the modal is closed
	#28-23
Scenario Outline:UMS23_DetailsModal_CreateAFirstNameAndLastNameWithSpecificCharactersAndOpenTheDetailModal_TheInformationMatchWithTheUser
	Given a user first name created with <length> characters and GUID last name with birth date <expectedBirthDate>
	When I write a name on the filter
	And click on the search button
	And click on the details button
	And get all the information from the modal
	Then the information on the modal match with the complete user name, <expectedStatus> and <expectedBirthDate>
	Examples: 
		 | length | expectedStatus | expectedBirthDate |
		 | 200    | false          | 12.07.2023        |
		 | 1      | false          | 12.07.2023        |

	#24-27
Scenario Outline:UMS23_DetailsModal_CreateAFirstNameWithSpecificCharactersAndOpenTheDetailModal_TheInformationMatchWithTheUser
	Given a user first name and last name created with <length> characters with birth date <expectedBirthDate>
	When I write a name on the filter
	And click on the search button
	And click on the details button
	And get all the information from the modal
	Then the information on the modal match with the complete user name, <expectedStatus> and <expectedBirthDate>
	Examples: 
		 | length | expectedStatus | expectedBirthDate |
		 | 200    | false          | 12.07.2023        |
		 | 1      | false          | 12.07.2023        |
		 #25-26
Scenario Outline:UMS25-26_DetailsModal_CreateALastNameWithSpecificCharactersAndOpenTheDetailModal_TheInformationMatchWithTheUser
	Given a user with GUID first name and last name <length> characters and birth date <expectedBirthDate>
	When I write a name on the filter
	And click on the search button
	And click on the details button
	And get all the information from the modal
	Then the information on the modal match with the complete user name, <expectedStatus> and <expectedBirthDate>
	Examples: 
		 | length | expectedStatus | expectedBirthDate |
		 | 200    | false          | 12.07.2023        |
		 | 1      | false          | 12.07.2023        |

Scenario:UMS29_DetailsModal_CreateAUserAndOpenTheDetailsAndPressEscKey_TheModalClose
	Given a user created
	When I write a name on the filter
	And click on the search button
	And click on the details button
	And press the Esc key
	Then the modal is closed

Scenario:UMS30_DetailsModal_CreateAUserAndOpenClickOutsideTheModal_TheModalClose
	Given a user created
	When I write a name on the filter
	And click on the search button
	And click on the details button
	And click out side the modal
	Then the modal is closed