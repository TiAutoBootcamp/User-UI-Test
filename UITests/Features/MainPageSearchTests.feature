Feature: MainPageSearchTests

As a Manager
I would like to search product via UI
In order to find correct products based on that.

Background: 
	Given open main page

Scenario: MP001_1_Searching for a product using an existing article
	Given Valid product is created 
	When User search product by 'Article'
	Then The product with a certain data is displayed on the page
	| manufactor         | name         |
	| PRODUCT_MANUFACTOR | PRODUCT_NAME |
	
Scenario: MP001_2_Searching for a product using an existing name
	Given Valid product is created 
	When User search product by 'Name'
	Then The product with a certain data is displayed on the page
	| manufactor         | name         |
	| PRODUCT_MANUFACTOR | PRODUCT_NAME |
	
Scenario: MP001_3_Searching for some products using an existing name
	Given Valid products are created 
	When User search product by 'Name'
	Then The product with a certain data is displayed on the page
	| manufactor         | name         |
	| PRODUCT_MANUFACTOR | PRODUCT_NAME |

Scenario: MP001_4_Searching for product using an existing manufactor
	Given Valid product is created 
	When User search product by 'Manufactor'
	Then The product with a certain data is displayed on the page
	| manufactor         | name         |
	| PRODUCT_MANUFACTOR | PRODUCT_NAME |

Scenario: MP001_5_Searching for some products using an existing manufactor
	Given Valid products are created 
	When User search product by 'Manufactor'
	Then The product with a certain data is displayed on the page
	| manufactor         | name         |
	| PRODUCT_MANUFACTOR | PRODUCT_NAME |
	
Scenario: MP001_6_Searching for a product with an empty query field
	When User search product by ''
	Then Search button is disabled

Scenario: MP001_5_Searching for a product using a query that doesn't exist in the database
	When User search product by 'NON_EXISTED_PRODUCT_INFO'
	Then Error message is presented

Scenario Outline: MP001_6_Searching for a product using a partial string
	Given Valid product is created 
	When User enter the partial string <partialString> in the field search
	Then The product with a certain data is displayed on the page
	Examples: 
		| partialString |
		| A             |
		| PRODUCT       |
		| NAME          |
		| MANUFACTOR    |

Scenario: MP001_7_Searching for a product using a mixed fields
	When User search product by 'PRODUCT_NAME PRODUCT_MANUFACTOR'
	Then Error message is presented
