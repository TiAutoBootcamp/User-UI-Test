Feature: TransactionsTabUserModalWindowTests

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

Scenario: UMS41_02_TransactionsTabUserDetailsModal_UserWithNoTransactions_TabIsClickableAndNoTransactionsMessageIsDisplayed
	Given a user created
	When I write a name on the filter
	And click on the search button
	And click on the details button
	And click on transactions tab
	Then transactions tab is clickable
	And no transactions message is displayed

Scenario: UMS42_TransactionsTabUserDetailsModal_UserWithMultipleTransactions_TransactionsDisplayedInDescOrderByCreationTime
	Given a user with multipleTransactions is created
	When I write a name on the filter
	And click on the search button
	And click on the details button
	And click on transactions tab	
	Then transactions are displayed in descendant order by creation time

Scenario: UMS43_TransactionsTabUserDetailsModal_UserWithTransactionsAddNewTransaction_CreatedTransactionIsDisplayedFirst
	Given a user with multipleTransactions is created
	And  user is charged with <amount>
	When I write a name on the filter
	And click on the search button
	And click on the details button
	And click on transactions tab
	Then first transaction displayed is <expectedAmount> and <TransactionId>

Scenario: UMS45_TransactionsTabUserDetailsModal_UserWithRevertedTransactions_TransactionStatusIsRevertedAndAmountIsNegative
	Given a user with multipleTransactions is created
	And  user has reverted transactions
	When I write a name on the filter
	And click on the search button
	And click on the details button
	And click on transactions tab
	Then first transaction displayed is <expectedAmount> and <TransactionId>	