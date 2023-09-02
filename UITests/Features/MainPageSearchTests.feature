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
	Then Error message 'Error is here' is presented

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
	| MANUFACTOR_2         | PRODUCT_MANUFACTOR_2_1 | PRODUCT_NAME_2   |

Scenario Outline: MP001_9_Searching for some products using a partial string
	Given Valid products are created
		| manufactor             | name             |
		| PRODUCT_MANUFACTOR_1   | PRODUCT_NAME_1   |
		| PRODUCT_MANUFACTOR_1_2 | PRODUCT_NAME_2   |
		| PRODUCT_MANUFACTOR_3   | PRODUCT_NAME_1_3 |
	When User search product by '<partialString>'
	Then The product with a certain data is displayed on the page
		| manufactor            | name            |
		| <expectedManufactor1> | <expectedName1> |
		| <expectedManufactor2> | <expectedName2> |
Examples:
	| partialString | expectedManufactor1  | expectedName1  | expectedManufactor2    | expectedName2    |
	| MANUFACTOR_1  | PRODUCT_MANUFACTOR_1 | PRODUCT_NAME_1 | PRODUCT_MANUFACTOR_1_2 | PRODUCT_NAME_2   |
	| NAME_1        | PRODUCT_MANUFACTOR_1 | PRODUCT_NAME_1 | PRODUCT_MANUFACTOR_3   | PRODUCT_NAME_1_3 |

Scenario: MP001_10_Searching for a product using a camelCase string
	Given Valid product is created
	When User search product by 'PrODuCT_mANUfACTOr'
	Then The product with a certain data is displayed on the page
		| manufactor         | name         |
		| PRODUCT_MANUFACTOR | PRODUCT_NAME |

Scenario: MP001_11_Searching for a product using leading and trailing spaces in the search query
	Given Valid product is created
	When User search product by '   PRODUCT_NAME '
	Then The product with a certain data is displayed on the page
		| manufactor         | name         |
		| PRODUCT_MANUFACTOR | PRODUCT_NAME |

Scenario: MP001_12_Testing the order of products after searching
	Given Valid products in quantities of '2' are created
	When User search product by 'Manufactor'
	Then 

Scenario: MP001_13_Research a product after a successful search
	Given Valid products are created
		| manufactor           | name           |
		| PRODUCT_MANUFACTOR_1 | PRODUCT_NAME_1 |
		| PRODUCT_MANUFACTOR_2 | PRODUCT_NAME_2 |
	And User search product by 'MANUFACTOR'
	And The product with a certain data is displayed on the page
		| manufactor           | name           |
		| PRODUCT_MANUFACTOR_1 | PRODUCT_NAME_1 |
		| PRODUCT_MANUFACTOR_2 | PRODUCT_NAME_2 |
	When User search product by 'DUCT_NAME_2'
	Then The product with a certain data is displayed on the page
		| manufactor           | name           |
		| PRODUCT_MANUFACTOR_2 | PRODUCT_NAME_2 |

