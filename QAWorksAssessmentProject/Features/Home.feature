Feature: Home
	 As an end user
	I want a homepage
	So that I can access QAWorks website



@RegressionTests
@Browser:Chrome
Scenario:Go to Contact Page
	Given I am on the QAWorks homepage
	When I click on Contact
	Then I should navigate to ContactUs page




@ignore
Scenario:Check Job Opportunities
	Given I am on the QAWorks homepage
	When I click apply for a position today
	Then It should launch the careers page


@ignore
Scenario Outline: Verify social sites links
	Given I am on the QAWorks homepage
	When I click on a social site <icon>
	Then I should be directed to the QAWorks page on the social site
	Examples: 
	| icon     |
	| facebook |
	| youtube  |
	| linkedIn |
	| twitter  |


