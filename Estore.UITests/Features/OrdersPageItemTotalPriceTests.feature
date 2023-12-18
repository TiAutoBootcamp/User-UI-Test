Feature: OrdersPageItemTotalPriceTests

As a Customer
I would like to make sure that the Total amount for each item
is calculated correctly on the page

#OP146_14a
#OP146_14b
#OP146_14c
#OP146_14d
@CustomerLoggedIn
Scenario Outline: OP146_14_ABCD_Items total in the order is correctly calculated
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
	Then Item total for order number '1' is correctly calculated
	Examples: 
	| quantity | price  |
	#OP146_14a
	| 1        | 10     |
	#OP146_14b
	| 1        | 100.96 |
	#OP146_14c
	| 5        | 500    |
	#OP146_14d
	| 4        | 35.84  |