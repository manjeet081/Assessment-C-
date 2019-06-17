Feature: PassionTea
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

	Background: 
	Given I go to Passion Tea website

Scenario: Order Green Tea
	And I open Herbal tea collection
	When I select Green tea and place the order
	Then I see a confirmation page

Scenario: Order Oolong Tea with Mastercard
	And I open Herbal tea collection
	When I select Oolong tea and place the order with Mastercard
	Then I see a confirmation page
Scenario: Send feedback to the Passion Tea company
	And I go to Let's Talk Tea page
	When I fill feedback form
	Then I can submit the form and get a confirmation