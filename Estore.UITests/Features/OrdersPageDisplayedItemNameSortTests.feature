Feature: OrdersPageDisplayedItemNameSortTests

A short summary of the feature

#OP146_16a
@CustomerLoggedIn
Scenario: OP146_16a_Products in the order are sorted by displayed name
	Given Customer has active status
	And Customer has enough money '1000000'
	When Create orders with following items
	| N of order | name  | manufactor  | quantity | price |
	| 1          | Name1 | Manufactor1 | 1        | 1     |
	| 1          | Name2 | Manufactor2 | 1        | 1     |
	| 1          | Name3 | Manufactor3 | 1        | 1     |
	And Customer moves cursor to Welcome message
	And Customer clicks on the Orders submenu button
	And Orders page is opened
	And Customer clicks on the order number '1'
	And Detailed information for the order number '1' is expanded
	Then Items for order number '1' are sorted by displayed name

#OP146_16b
@CustomerLoggedIn
Scenario: OP146_16b_Products in the order are sorted by displayed name
	Given Customer has active status
	And Customer has enough money '1000000'
	When Create orders with following items
	| N of order | name  | manufactor  | quantity | price |
	| 1          | Name3 | Manufactor3 | 1        | 1     |
	| 1          | Name2 | Manufactor2 | 1        | 1     |
	| 1          | Name1 | Manufactor1 | 1        | 1     |
	And Customer moves cursor to Welcome message
	And Customer clicks on the Orders submenu button
	And Orders page is opened
	And Customer clicks on the order number '1'
	And Detailed information for the order number '1' is expanded
	Then Items for order number '1' are sorted by displayed name

#OP146_16c
@CustomerLoggedIn
Scenario: OP146_16c_Products in the order are sorted by displayed name
	Given Customer has active status
	And Customer has enough money '1000000'
	When Create orders with following items
	| N of order | name  | manufactor  | quantity | price |
	| 1          | Name2 | Manufactor3 | 1        | 1     |
	| 1          | Name3 | Manufactor1 | 1        | 1     |
	| 1          | Name1 | Manufactor2 | 1        | 1     |
	And Customer moves cursor to Welcome message
	And Customer clicks on the Orders submenu button
	And Orders page is opened
	And Customer clicks on the order number '1'
	And Detailed information for the order number '1' is expanded
	Then Items for order number '1' are sorted by displayed name

#OP146_16d
@CustomerLoggedIn
Scenario: OP146_16d_Products in the order are sorted by displayed name
	Given Customer has active status
	And Customer has enough money '1000000'
	When Create orders with following items
	| N of order | name  | manufactor  | quantity | price |
	| 1          | Name3 | Manufactor1 | 1        | 1     |
	| 1          | Name2 | Manufactor1 | 1        | 1     |
	| 1          | Name1 | Manufactor1 | 1        | 1     |
	And Customer moves cursor to Welcome message
	And Customer clicks on the Orders submenu button
	And Orders page is opened
	And Customer clicks on the order number '1'
	And Detailed information for the order number '1' is expanded
	Then Items for order number '1' are sorted by displayed name

#OP146_16e
@CustomerLoggedIn
Scenario: OP146_16e_Products in the order are sorted by displayed name
	Given Customer has active status
	And Customer has enough money '1000000'
	When Create orders with following items
	| N of order | name  | manufactor  | quantity | price |
	| 1          | Name1 | Manufactor2 | 1        | 1     |
	| 1          | Name1 | Manufactor1 | 1        | 1     |
	| 1          | Name1 | Manufactor3 | 1        | 1     |
	And Customer moves cursor to Welcome message
	And Customer clicks on the Orders submenu button
	And Orders page is opened
	And Customer clicks on the order number '1'
	And Detailed information for the order number '1' is expanded
	Then Items for order number '1' are sorted by displayed name
