Feature: Purchase

Scenario: Add item to cart
	Given I am on the home page and click on Pricing Menu
	When I click to buy product bundle
	Then Product is added in cart
