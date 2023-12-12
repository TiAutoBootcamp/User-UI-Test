Feature: OrdersPageTests

As a user
I want to ensure the functionality 
of the Orders page based on my role

#OP146_01
Scenario: OP146_01_Orders button is available for the user as a customer
	Given Open login page
	And Login page is opened
	And User fills email and password fields with 'Customer' credentials
	And User clicks Login button
	And Main page is opened
	When User moves to Welcome message
	Then The following buttons are available in the dropdown list
	| buttonNames          |
	| Account settings |
	| Orders           |
	| Transactions     |
	| Sign Out         |

#OP146_02
Scenario: OP146_02_Orders button is missing for the user as a admin
	Given Open login page
	And Login page is opened
	And User fills email and password fields with 'Admin' credentials
	And User clicks Login button
	And Main page is opened
	When User moves to Welcome message
	Then The following buttons are available in the dropdown list
	| buttonNames |
	| Sign Out    |

#OP146_03
Scenario: OP146_03_Orders history page is opened after clicking Orders button
	Given Open login page
	And Login page is opened
	And User fills email and password fields with 'Customer' credentials
	And User clicks Login button
	And Main page is opened
	When User moves to Welcome message
	And Customer clicks on the Orders button
	Then Orders page is opened

#OP146_05
@CustomerLoggedIn
Scenario: OP146_05_Order page for a customer who has no orders
	Given User moves to Welcome message
	And Customer clicks on the Orders button
	When Orders page is opened
	Then Message 'No orders yet' is presented

#OP146_06
@CustomerLoggedIn
Scenario: OP146_06_Order page for a customer who has no orders
	Given Customer has active status
	And Customer has enough money '1000000'
	When Customer creates '2' orders with following items
	| N of order | name  | manufactor  | quantity | price |
	| 1          | Name1 | Manufactor1 | 1        | 1     |
	| 1          | Name2 | Manufactor2 | 2        | 2     |
	| 2          | Name3 | Manufactor3 | 3        | 3     |
	And User moves to Welcome message
	And Customer clicks on the Orders button
	And Orders page is opened
	Then '2' orders are diesplayed on the page


#OP146_07
#OP146_08
@CustomerLoggedIn
Scenario: OP146_07_order IDs, date of their creation, grand total values match to orders created by the customer
	Given Customer has active status
	And Customer has enough money '1000000'
	When Customer creates '3' orders with following items
	| N of order | name  | manufactor  | quantity | price |
	| 1          | Name1 | Manufactor1 | 1        | 1.1   |
	| 2          | Name2 | Manufactor2 | 2        | 2.2   |
	| 3          | Name3 | Manufactor3 | 3        | 3.33  |
	And User moves to Welcome message
	And Customer clicks on the Orders button
	And Orders page is opened
	Then Main orders information match to orders created by the customer	

#OP146_10
@CustomerLoggedIn
Scenario: OP146_10_Order details expand after clicking on the order line
	Given Customer has active status
	And Customer has enough money '1000000'
	When Customer creates '2' orders with following items
	| N of order | name  | manufactor  | quantity | price |
	| 1          | Name1 | Manufactor1 | 1        | 1     |
	And User moves to Welcome message
	And Customer clicks on the Orders button
	And Orders page is opened
	And Customer clicks on the order number '1'
	Then Detailed information for the order number '1' expands

#OP146_11
@CustomerLoggedIn
Scenario: OP146_11_Order details collapsed after clicking on the order line
	Given Customer has active status
	And Customer has enough money '1000000'
	When Customer creates '2' orders with following items
	| N of order | name  | manufactor  | quantity | price |
	| 1          | Name1 | Manufactor1 | 1        | 1     |
	And User moves to Welcome message
	And Customer clicks on the Orders button
	And Orders page is opened
	And Customer clicks on the order number '1'
	And Detailed information for the order number '1' expands
	And Customer clicks on the order number '1'
	Then Detailed information for the order number '1' collapsed

#OP146_12
@CustomerLoggedIn
Scenario: OP146_12_Order details expand for several orders
	Given Customer has active status
	And Customer has enough money '1000000'
	When Customer creates '2' orders with following items
	| N of order | name  | manufactor  | quantity | price |
	| 1          | Name1 | Manufactor1 | 1        | 1     |
	| 2          | Name2 | Manufactor2 | 1        | 1     |
	| 3          | Name3 | Manufactor3 | 1        | 1     |
	And User moves to Welcome message
	And Customer clicks on the Orders button
	And Orders page is opened
	And Customer clicks on the order number '1'
	And Customer clicks on the order number '3'
	Then Detailed information for the order number '1' expands
	And Detailed information for the order number '3' expands
	And Detailed information for the order number '2' collapsed
	