@employee
Feature: Employee
In order to add,edit, delete employee records 
As an admin
I want to modify the employee details in dashboard

#add employee and verify
@low @smoke
Scenario Outline: Add Valid Employee
	Given I open browser with orangehrm page
	When I enter username as '<username>'
	And I enter password as '<password>'
	And I click on login
	And I click on PIM
	And I click on Add Employee
	And I fill the add employee section
		| firstname   | middlename   | lastname | employee_id | toggle_login_detail | username       | password           | confirm_password   | status   |
		| <firstname> | <middlename> | <lname>  | <empid>     | <toggle_login>      | <account_user> | <account_password> | <confirm_password> | <status> |
	And I click on save employee
	Then I should be navigated to personal details section with added employee records
Examples:
	| username | password | firstname | middlename | lname   | empid | toggle_login | account_user | account_password | confirm_password | status   |
	| Admin    | admin123 | Saul      | J          | Goodman | 1001  | on           | jimmy13      | Welcome@123      | Welcome@123      | disabled |
	| Admin    | admin123 | Peter     | J          | Goodman | 1004  | on           | peter13      | Welcome@123      | Welcome@123      | disabled |

