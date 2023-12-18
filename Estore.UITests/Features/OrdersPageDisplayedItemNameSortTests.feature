Feature: OrdersPageDisplayedItemNameSortTests

As a Customer
I want to make sure that the items in the order are sorted 
by name in ascending order

#OP146_16a
#OP146_16b
#OP146_16c
#OP146_16d
#OP146_16e
@CustomerLoggedIn
Scenario Outline: OP146_16ABCDE_Products in the order are sorted by displayed name
	Given Customer has active status
	And Customer has enough money '1000000'
	When Create orders with following items
	| N of order | name    | manufactor    | quantity | price |
	| 1          | <name1> | <manufactor1> | 1        | 1     |
	| 1          | <name2> | <manufactor2> | 1        | 1     |
	| 1          | <name3> | <manufactor3> | 1        | 1     |
	And Customer moves cursor to Welcome message
	And Customer clicks on the Orders submenu button
	And Orders page is opened
	And Customer clicks on the order number '1'
	And Detailed information for the order number '1' is expanded
	Then Items for order number '1' are sorted by displayed name
	Examples: 
	| name1 | manufactor1 | name2 | manufactor2 | name3 | manufactor3 |
	#OP146_16a
	| Name1 | Manufactor1 | Name2 | Manufactor2 | Name3 | Manufactor3 |
	#OP146_16b
	| Name3 | Manufactor3 | Name2 | Manufactor2 | Name1 | Manufactor1 |
	#OP146_16c
	| Name2 | Manufactor3 | Name3 | Manufactor1 | Name1 | Manufactor2 |
	#OP146_16d
	| Name3 | Manufactor1 | Name2 | Manufactor1 | Name1 | Manufactor1 |
	#OP146_16e
	| Name1 | Manufactor2 | Name1 | Manufactor1 | Name1 | Manufactor3 |