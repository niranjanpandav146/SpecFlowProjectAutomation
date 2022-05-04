Feature: ShoppingCart

Shopping Cart Feature

@regression
Scenario Outline: Consumer can add a book to shopping cart from wish list
	Given User navigate to saucedemo application
	| url                       | browserName |
	| https://www.saucedemo.com | chrome      |
	And User login to saucedemo application
	| userName   | password   |
	| <userName> | <password> |
	And User add product to shopping cart
	| productName   |
	| <productName> |
	And User open my shopping cart to check product price
	| productName   |
	| <productName> |
	And User enter checkout information
	| firstName   | lastName   | postalCode   |
	| <firstName> | <lastName> | <postalCode> |
	Then User check for product and price in checkout overview
	| productName   |
	| <productName> |

	Examples:
	| userName      | password     | firstName | lastName | postalCode | productName         |
	| standard_user | secret_sauce | Niranjan  | Pandav   | 411057     | Sauce Labs Backpack |
	
