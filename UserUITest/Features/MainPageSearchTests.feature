Feature: MainPageSearchTests

As a Manager
I would like to search product via UI
In order to find correct products based on that.

Background: 
	Given open main page
@tag1
Scenario: MP001_1_Searching for a product using an existing article_
	Given Valid product is created 
	When [action]
	Then [outcome]
