Feature: SpartaGlobalForm
	In order to register
	As a user
	I want see the completion page


Scenario: Enter Details Happy Path
	Given I am on the registration page
	And I have entered the valid details in all the fields  
	When I press sign in
	Then I should be on the appropriate page

Scenario Outline: Enter Details Missing One Required Element
	Given I am on the registration page
	And I have entered <an> invalid detail
	And I have entered all other details correctly
	When I press sign in
	Then I should see the appropriate <error>

	Examples: 
	| an | error                         |
	| 1  | Please enter your first name. |
	| 2  | Please enter your last name.  |
	| 3  | Please enter your age.        |
	| 4  | Please enter an address.      |
	| 5  | Please enter a postcode.      |
	| 6  | Please enter an email.        |
	| 7  | Please enter a phone number.  |
	
