Feature: OrdersPageGrandAmountTests

A short summary of the feature

#OP146_15a
@CustomerLoggedIn
Scenario: OP146_15a_Grand total for the order is correctly calculated
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
	Then Grand total for the order number '1' is correctly calculated

#OP146_15b
@CustomerLoggedIn
Scenario: OP146_15b_Grand total for the order is correctly calculated
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
	Then Grand total for the order number '1' is correctly calculated

#OP146_15c
@CustomerLoggedIn
Scenario: OP146_15c_Grand total for the order is correctly calculated
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
	Then Grand total for the order number '1' is correctly calculated

#OP146_15d
@CustomerLoggedIn
Scenario: OP146_15d_Grand total for the order is correctly calculated
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
	Then Grand total for the order number '1' is correctly calculated

#OP146_15e
@CustomerLoggedIn
Scenario: OP146_15e_Grand total for the order is correctly calculated
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
	Then Grand total for the order number '1' is correctly calculated