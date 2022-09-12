Feature: EmergencyContacts
In order to reach the employee relation on emergency
As an admin
I should have access to add, edit, delete employee emergency contacts 

@high
Scenario Outline: Add Emergency Contact
	Given I have browser with orangehrm page
	When I enter username as '<username>'
	And I enter password as '<password>'
	And I click on login
	And I click on My Info
	And I click on Emergency Contacts
	And I click on add Assigned Emergency Contacts
	And I fill the emergency contact details
		| name   | relationship   | home_telephone | mobile   | work_telephone |
		| <name> | <relationship> | <home_phone>   | <mobile> | <work_phone>   |
	And I click on save emergency contact
	Then I should see the added records in the table
Examples:
	| username | password | name | relationship | home_phone | mobile | work_phone |
	| Admin    | admin123 | Jack | brother      | 788        | 88     | 778        |
	| Admin    | admin123 | Kim  | Sister       | 7883       | 883    | 7783       |

