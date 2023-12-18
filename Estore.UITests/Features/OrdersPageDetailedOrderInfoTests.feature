Feature: OrdersPageDetailedOrderInfoTests

As a Customer
I would like to make sure that the order detailed order information
is diplayed correctly on the Orders page

#OP146_13a
#OP146_13b
@CustomerLoggedIn
Scenario Outline: OP146_13a_13b_The detailed order information matches to detailed information in created order
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
	Then Detailed info for the order number '1' matches to detailed info in created order
	Examples: 
	| quantity | price |
	#OP146_13a
	| 1        | 1     |
	#OP146_13b
	| 3        | 1.1   |

#OP146_13c
#OP146_13d
#OP146_13e
@CustomerLoggedIn
Scenario Outline: OP146_13c_13d_13e_The detailed order information matches to detailed information in created order
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
	Then Detailed info for the order number '1' matches to detailed info in created order
	Examples: 
	| quantity1 | price1 | quantity2 | price2 |
	#OP146_13c
	| 1         | 1      | 1         | 2      |
	#OP146_13d
	| 1         | 1.11   | 4         | 2.02   |
	#OP146_13e
	| 3         | 12.25  | 4         | 5.99   |