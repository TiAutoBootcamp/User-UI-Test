Feature: OrdersPageItemTotalPriceTests

As a Customer
I would like to make sure that the Total amount for each item
is calculated correctly on the page

#OP146_14a
@CustomerLoggedIn
Scenario: OP146_14a_Items total in the order is correctly calculated
	Given Customer has active status
	And Customer has enough money '1000000'
	When Create orders with following items
	| N of order | name  | manufactor  | quantity | price |
	| 1          | Name1 | Manufactor1 | 1        | 10     |
	And Customer moves cursor to Welcome message
	And Customer clicks on the Orders submenu button
	And Orders page is opened
	And Customer clicks on the order number '1'
	And Detailed information for the order number '1' is expanded
	Then Item total for order number '1' is correctly calculated

#OP146_14b
@CustomerLoggedIn
Scenario: OP146_14b_Items total in the order is correctly calculated
	Given Customer has active status
	And Customer has enough money '1000000'
	When Create orders with following items
	| N of order | name  | manufactor  | quantity | price |
	| 1          | Name1 | Manufactor1 | 1        | 100.96   |
	And Customer moves cursor to Welcome message
	And Customer clicks on the Orders submenu button
	And Orders page is opened
	And Customer clicks on the order number '1'
	And Detailed information for the order number '1' is expanded
	Then Item total for order number '1' is correctly calculated

#OP146_14c
@CustomerLoggedIn
Scenario: OP146_14c_Items total in the order is correctly calculated
	Given Customer has active status
	And Customer has enough money '1000000'
	When Create orders with following items
	| N of order | name  | manufactor  | quantity | price |
	| 1          | Name1 | Manufactor1 | 5        | 500   |
	And Customer moves cursor to Welcome message
	And Customer clicks on the Orders submenu button
	And Orders page is opened
	And Customer clicks on the order number '1'
	And Detailed information for the order number '1' is expanded
	Then Item total for order number '1' is correctly calculated

#OP146_14d
@CustomerLoggedIn
Scenario: OP146_14d_Items total in the order is correctly calculated
	Given Customer has active status
	And Customer has enough money '1000000'
	When Create orders with following items
	| N of order | name  | manufactor  | quantity | price |
	| 1          | Name1 | Manufactor1 | 4        | 35.84 |  
	And Customer moves cursor to Welcome message
	And Customer clicks on the Orders submenu button
	And Orders page is opened
	And Customer clicks on the order number '1'
	And Detailed information for the order number '1' is expanded
	Then Item total for order number '1' is correctly calculated