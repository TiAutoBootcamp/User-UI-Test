Feature: OrdersPageDetailedOrderInfoTests

A short summary of the feature

#OP146_13a
@CustomerLoggedIn
Scenario: OP146_13a_The detailed order information match the products added when ordering
	Given Customer has active status
	And Customer has enough money '1000000'
	When Create orders with following items
	| N of order | name  | manufactor  | quantity | price |
	| 1          | Name1 | Manufactor1 | 1        | 1     |
	And Customer moves cursor to Welcome message
	And Customer clicks on the Orders submenu button
	And Orders page is opened
	And Customer clicks on the order number '1'
	And Detailed information for the order number '1' is expanded
	Then Detailed information match the information added when ordering

#OP146_13b
@CustomerLoggedIn
Scenario: OP146_13b_The detailed order information match the products added when ordering
	Given Customer has active status
	And Customer has enough money '1000000'
	When Create orders with following items
	| N of order | name  | manufactor  | quantity | price |
	| 1          | Name1 | Manufactor1 | 3        | 1.1   |
	And Customer moves cursor to Welcome message
	And Customer clicks on the Orders submenu button
	And Orders page is opened
	And Customer clicks on the order number '1'
	And Detailed information for the order number '1' is expanded
	Then Detailed information match the information added when ordering

#OP146_13c
@CustomerLoggedIn
Scenario: OP146_13c_The detailed order information match the products added when ordering
	Given Customer has active status
	And Customer has enough money '1000000'
	When Create orders with following items
	| N of order | name  | manufactor  | quantity | price |
	| 1          | Name1 | Manufactor1 | 1        | 1     |
	| 1          | Name2 | Manufactor2 | 1        | 2     |
	And Customer moves cursor to Welcome message
	And Customer clicks on the Orders submenu button
	And Orders page is opened
	And Customer clicks on the order number '1'
	And Detailed information for the order number '1' is expanded
	Then Detailed information match the information added when ordering

#OP146_13d
@CustomerLoggedIn
Scenario: OP146_13d_The detailed order information match the products added when ordering
	Given Customer has active status
	And Customer has enough money '1000000'
	When Create orders with following items
	| N of order | name  | manufactor  | quantity | price |
	| 1          | Name1 | Manufactor1 | 1        | 1.11  |
	| 1          | Name2 | Manufactor2 | 4        | 2.02  |
	And Customer moves cursor to Welcome message
	And Customer clicks on the Orders submenu button
	And Orders page is opened
	And Customer clicks on the order number '1'
	And Detailed information for the order number '1' is expanded
	Then Detailed information match the information added when ordering

#OP146_13e
@CustomerLoggedIn
Scenario: OP146_13e_The detailed order information match the products added when ordering
	Given Customer has active status
	And Customer has enough money '1000000'
	When Create orders with following items
	| N of order | name  | manufactor  | quantity | price |
	| 1          | Name1 | Manufactor1 | 3        | 12.25 |
	| 1          | Name2 | Manufactor2 | 4        | 5.99  |
	And Customer moves cursor to Welcome message
	And Customer clicks on the Orders submenu button
	And Orders page is opened
	And Customer clicks on the order number '1'
	And Detailed information for the order number '1' is expanded
	Then Detailed information match the information added when ordering