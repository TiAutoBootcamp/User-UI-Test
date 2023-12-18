Feature: OrdersPageGrandAmountTests

As a Customer
I want to make sure that the Grand Total amoubt
is calculated correctly on the page

#OP146_15a
#OP146_15b
@CustomerLoggedIn
Scenario Outline: OP146_15a_15b_Grand total for the order is correctly calculated
	Given Customer has active status
	And Customer has enough money '1000000'
	When Create orders with following items
	| N of order | name  | manufactor  | quantity   | price   |
	| 1          | Name1 | Manufactor1 | <quantity> | <price> |
	And Customer moves cursor to Welcome message
	And Customer clicks on the Orders submenu button
	And Orders page is opened
	And Customer clicks on the order number '1'
	And Detailed information for the order number '1' is expanded
	Then Grand total for the order number '1' is correctly calculated
	Examples: 
	| quantity | price |
	#OP146_15a
	| 1        | 1     |
	#OP146_15b
	| 3        | 1.1   |

#OP146_15c
#OP146_15d
#OP146_15e
@CustomerLoggedIn
Scenario Outline: OP146_15c_15d_15e_Grand total for the order is correctly calculated
	Given Customer has active status
	And Customer has enough money '1000000'
	When Create orders with following items
	| N of order | name  | manufactor  | quantity    | price    |
	| 1          | Name1 | Manufactor1 | <quantity1> | <price1> |
	| 1          | Name2 | Manufactor2 | <quantity2> | <price2> |
	And Customer moves cursor to Welcome message
	And Customer clicks on the Orders submenu button
	And Orders page is opened
	And Customer clicks on the order number '1'
	And Detailed information for the order number '1' is expanded
	Then Grand total for the order number '1' is correctly calculated
	Examples: 
	| quantity1 | price1 | quantity2 | price2 |
	#OP146_15c
	| 1         | 1      | 1         | 2      |
	#OP146_15d
	| 1         | 1.11   | 4         | 2.02   |
	#OP146_15e
	| 3         | 12.25  | 4         | 5.99   |