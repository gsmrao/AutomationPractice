Feature: AutomationPractice
	Simple calculator for adding two numbers

@mytag
Scenario: Order TShirt and Validate Order Summary
	Given I launch below application using "http://automationpractice.com/index.php" and "Chrome" browser
	Then I click on T-SHIRTS tab
	And I select and click on T-Shirts AddCart
	Then I validae Order Summary
	| productName                 | unitPrice | qty | total  |
	| Faded Short Sleeve T-shirts | $16.51    | 1   | $16.51 |

@mytag
Scenario: Update Personal Information 
	Given I launch below application using "http://automationpractice.com/index.php" and "Chrome" browser
	Then I click on Sigin button
	And Enter login details "gsmrao@gmail.com" and "July@2006"
	And Update Personal Information "SubbuAB" and "July@2006"