Feature: YourOrder

Scenario: License count is automatically updated
	Given I add products to cart
	When I select "3" license quantities
	Then Unit price is correctly updated

Scenario: Maintenance count is automatically updated
	Given I add products to cart
	When I select "+1 year" maintenance years
	Then Term price is correctly updated
