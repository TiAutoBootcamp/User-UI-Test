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
	
Scenario: MP001_3_Searching for some products using an existing names
	Given Valid products are created
		| manufactor           | name         |
		| PRODUCT_MANUFACTOR_1 | PRODUCT_NAME |
		| PRODUCT_MANUFACTOR_2 | PRODUCT_NAME |
	When User search product by 'Name'
	Then The product with a certain data is displayed on the page
		| manufactor           | name         |
		| PRODUCT_MANUFACTOR_1 | PRODUCT_NAME |
		| PRODUCT_MANUFACTOR_2 | PRODUCT_NAME |

Scenario: MP001_4_Searching for product using an existing manufactor
	Given Valid product is created
	When User search product by 'Manufactor'
	Then The product with a certain data is displayed on the page
		| manufactor         | name         |
		| PRODUCT_MANUFACTOR | PRODUCT_NAME |

Scenario: MP001_5_Searching for some products using an existing manufactor
	Given Valid products are created
		| manufactor         | name           |
		| PRODUCT_MANUFACTOR | PRODUCT_NAME_1 |
		| PRODUCT_MANUFACTOR | PRODUCT_NAME_2 |
	When User search product by 'Manufactor'
	Then The product with a certain data is displayed on the page
		| manufactor         | name           |
		| PRODUCT_MANUFACTOR | PRODUCT_NAME_1 |
		| PRODUCT_MANUFACTOR | PRODUCT_NAME_2 |
	
Scenario: MP001_6_Searching for a product with an empty query field
	When User search product by ''
	Then Search button is disabled

Scenario: MP001_7_Searching for a product using a query that doesn't exist in the database
	When User search product by 'NON_EXISTED_PRODUCT_INFO'
	Then Error message 'No such products' is presented

Scenario Outline: MP001_8_Searching for a product using a partial string
	Given Valid products are created
		| manufactor             | name             |
		| PRODUCT_MANUFACTOR_1_1 | PRODUCT_NAME_1_1 |
		| PRODUCT_MANUFACTOR_2_1 | PRODUCT_NAME_2   |
		| PRODUCT_MANUFACTOR_3   | PRODUCT_NAME_3_1 |
	When User search product by '<partialString>'
	Then The product with a certain data is displayed on the page
		| manufactor           | name           |
		| <expectedManufactor> | <expectedName> |
Examples:
	| partialString        | expectedManufactor     | expectedName     |
	| PRODUCT_MANUFACTOR_1 | PRODUCT_MANUFACTOR_1_1 | PRODUCT_NAME_1_1 |
	| NAME_3_1             | PRODUCT_MANUFACTOR_3   | PRODUCT_NAME_3_1 |
	| MANUFACTOR_2_1       | PRODUCT_MANUFACTOR_2_1 | PRODUCT_NAME_2   |

Scenario Outline: MP001_9_Searching for some products using a partial string
	Given Valid products are created
		| manufactor               | name             |
		| PRODUCT_MANUFACTOR_1_1   | PRODUCT_NAME_1_1 |
		| PRODUCT_MANUFACTOR_1_1_2 | PRODUCT_NAME_2   |
		| PRODUCT_MANUFACTOR_2     | PRODUCT_NAME_1_1_2 |
	When User search product by '<partialString>'
	Then The product with a certain data is displayed on the page
		| manufactor            | name            |
		| <expectedManufactor1> | <expectedName1> |
		| <expectedManufactor2> | <expectedName2> |
Examples:
	| partialString  | expectedManufactor1    | expectedName1    | expectedManufactor2      | expectedName2      |
	| MANUFACTOR_1_1 | PRODUCT_MANUFACTOR_1_1 | PRODUCT_NAME_1_1 | PRODUCT_MANUFACTOR_1_1_2 | PRODUCT_NAME_2     |
	| NAME_1_1       | PRODUCT_MANUFACTOR_1_1 | PRODUCT_NAME_1_1 | PRODUCT_MANUFACTOR_2     | PRODUCT_NAME_1_1_2 |

Scenario: MP001_11_Searching for a product using a camelCase string
	Given Valid product is created
	When User search product by 'PrODuCT_mANUfACTOr'
	Then The product with a certain data is displayed on the page
		| manufactor         | name         |
		| PRODUCT_MANUFACTOR | PRODUCT_NAME |

Scenario: MP001_12_Searching for a product using leading and trailing spaces in the search query
	Given Valid product is created
	When User search product by '   PRODUCT_NAME '
	Then The product with a certain data is displayed on the page
		| manufactor         | name         |
		| PRODUCT_MANUFACTOR | PRODUCT_NAME |

Scenario: MP001_13_Testing the order of products after searching
	Given Products with diffrent status are created
		| manufactor           | name           | ProductStatus |
		| PRODUCT_MANUFACTOR_1 | PRODUCT_NAME_1 | Active        |
		| PRODUCT_MANUFACTOR_2 | PRODUCT_NAME_2 | NotActive     |
		| PRODUCT_MANUFACTOR_3 | PRODUCT_NAME_3 | NotActive     |
		| PRODUCT_MANUFACTOR_4 | PRODUCT_NAME_4 | Active        |
		| PRODUCT_MANUFACTOR_5 | PRODUCT_NAME_5 | NotActive     |
	When User search product by 'PRODUCT_NAME_'
	Then The order of products on the main page are correct

Scenario: MP001_14_Research a product after a successful search
	Given Valid products are created
		| manufactor           | name           |
		| PRODUCT_MANUFACTOR_1 | PRODUCT_NAME_1 |
		| PRODUCT_MANUFACTOR_2 | PRODUCT_NAME_2 |
	And User search product by 'PRODUCT_MANUFACTOR'
	And The product with a certain data is displayed on the page
		| manufactor           | name           |
		| PRODUCT_MANUFACTOR_1 | PRODUCT_NAME_1 |
		| PRODUCT_MANUFACTOR_2 | PRODUCT_NAME_2 |
	When User search product by 'DUCT_NAME_2'
	Then The product with a certain data is displayed on the page
		| manufactor           | name           |
		| PRODUCT_MANUFACTOR_2 | PRODUCT_NAME_2 |