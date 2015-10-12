Feature: ContactUsPage
	 As an end user
	I want a contact us page
	So that I can find out more about QAWorks exciting services


@RegressionTest
@Browser:Chrome
Scenario: Valid Submission
	Given I am on the QAWorks Staging Site
	Then I should be able to contact QA Works with the following information
	| Name      | Email                | Message                                   |
	| j. Bloggs | j.Bloggs@qaworks.com | please contact me I want to find out more |

@RegressionTest
@Browser:Chrome
Scenario: Invalid Email submission
	Given I am on the Contact Page of QAWorks Staging Site
	When I complete the form with an invalid email address
	| InvalidEmail | Name  |
	| djhfgs@com.. | James |
	Then an error message should display below the email field
	| ErrorMsg               |
	| Invalid Email Address |

@RegressionTest
@Browser:Chrome
Scenario Outline: Incomplete Message Submission
	Given I am on the Contact Page of QAWorks Staging Site
	When I complete the form with incomplete information <Name>, <Email>, <Message>
	Then the correct error message <errorMsgText> should be displayed correctly <errorMsg>
	Examples: 
	| Name | Email                  | Message                                   | errorMsgText                 | errorMsg                          |
	| ""   | j.bloggs@qaworks.com   | please contact me I want to find out more | Your name is required        | span#ctl00_MainContent_rfvName    |
	| Fred | ""                     | please contact me I want to find out more | An Email address is required | span#ctl00_MainContent_rfvName    |
	| Jim  | k.j.bloggs@qaworks.com | ""                                        | Please type your message     | span#ctl00_MainContent_rfvMessage |
