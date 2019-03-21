Feature: SpartaGlobalForm
	In order to register
	As a user
	I want see the completion page


Scenario: Enter Details Happy Path
	Given I am on the registration page
	And I have entered the valid details in all the fields  
	When I press sign in
	Then I should be on the appropriate page
