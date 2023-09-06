﻿Feature: TransactionsTabUserModalWindowTests

As a Manager
I would like to check user transactions via UI
In order to create sales report based on that.

Background: 
	Given open users page

Scenario: UMS41_01_TransactionsTabUserDetailsModal_UserWithTransactions_TabIsClickableAndTableIsDisplayed
	Given a user with transactions is created
	When I write a name on the filter
	And click on the search button
	And click on the details button
	And click on transactions tab
	Then transactions tab is clickable
	And transactions table displays transactions

Scenario: UMS41_02_TransactionsTabUserDetailsModal_ActiveUserWithNoTransactions_TabIsClickableAndNoTransactionsMessageIsDisplayed
	Given a user created and active
	When I write a name on the filter
	And click on the search button
	And click on the details button
	And click on transactions tab
	Then transactions tab is clickable
	And no transactions message is displayed

	Scenario: UMS41_03_TransactionsTabUserDetailsModal_NotActiveUserWithNoTransactions_TabIsClickableAndNoTransactionsMessageIsDisplayed
	Given a user created
	When I write a name on the filter
	And click on the search button
	And click on the details button
	And click on transactions tab
	Then transactions tab is clickable
	And no transactions message is displayed

Scenario Outline: UMS42_TransactionsTabUserDetailsModal_UserWithMultipleTransactions_TransactionsDisplayedInDescOrderByCreationTime
	Given a user created and active
	And made multipleTransactions <amountValues>
	When I write a name on the filter
	And click on the search button
	And click on the details button
	And click on transactions tab	
	And request to get the creation time for user transactions
	Then transactions are displayed in descendant order by creation time
	Examples: 
		|amountValues	|
		|10,20,30	    |

Scenario Outline: UMS43_TransactionsTabUserDetailsModal_UserWithTransactionsAddNewTransaction_CreatedTransactionIsDisplayedFirst
	Given a user created and active
	And made multipleTransactions <amountValues>
	And  user is charged with <amount>
	When I write a name on the filter
	And click on the search button
	And click on the details button
	And click on transactions tab
	And get the information of the first transaction
	Then the information displayed has the expected information for the transaction
	Examples: 
		|amountValues	| amount	|
		|5,20,30	    | 10	    |

Scenario Outline: UMS45_TransactionsTabUserDetailsModal_UserWithRevertedTransactions_TransactionStatusIsRevertedAndAmountIsNegative
	Given a user created and active
	And made multipleTransactions <amountValues>
	And  user has reverted the last transaction
	When I write a name on the filter
	And click on the search button
	And click on the details button
	And click on transactions tab
	And get the information of the first transaction
	And get the information of the second transaction
	Then second transaction has the <state> and expected information  
	And the first transaction has the revert amount

	Examples: 
		|amountValues	| state 	  |
		|5,20,30	    | Reverted    |

Scenario Outline: UMS46_TransactionsTabUserDetailsModal_UserWithFiveTransactions_AllIformtationTransactionsIsCorrect
	Given a user created and active
	And made multipleTransactions <amountValues>
	When I write a name on the filter
	And click on the search button
	And click on the details button
	And click on transactions tab	
	And request to get all the information for all the transactions
	Then transactions displayed are correct with the expected information
	Examples: 
		|amountValues			|
		|10,20,30,15,5,50	    |

Scenario Outline: UMS47_TransactionsTabUserDetailsModal_UserWithMultipleTransactions_CountOfTransactionsIsCorrect
	Given a user created and active
	And made multipleTransactions <amountValues>
	When I write a name on the filter
	And click on the search button
	And click on the details button
	And click on transactions tab	
	And request to get the creation time for user transactions
	Then count of transactions are correct
	Examples: 
		|amountValues|
		|10,20,30    |