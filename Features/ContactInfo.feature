Feature: ContactInfo

Scenario: Fill Contact Info with valid data 
	Given I add product to cart
	When I fill out "FName", "LName", "test@mail.com", "TestCompany", "04313456", "Test address 45, str.", "Bulgaria", "", "Test City", "zip123", "BG160026043", "" billing information
	Then All fields are properly inserted
	And I can continue to review order