using OpenQA.Selenium;
using SpecflowAutomation.Hooks;
using System;
using TechTalk.SpecFlow;

namespace SpecflowAutomation.StepDefinitions
{
    [Binding]
    public class EmployeeStepDefinitions
    {
        private string fName;

        private AutomationHooks hooks;

        public EmployeeStepDefinitions(AutomationHooks hooks)
        {
            this.hooks = hooks;
        }


        [When(@"I click on PIM")]
        public void WhenIClickOnPIM()
        {
            hooks.driver.FindElement(By.XPath("//span[text()='PIM']")).Click();
        }

        [When(@"I click on Add Employee")]
        public void WhenIClickOnAddEmployee()
        {
            hooks.driver.FindElement(By.XPath("//a[text()='Add Employee']")).Click();
        }
         
        [When(@"I fill the add employee section")]
        public void WhenIFillTheAddEmployeeSection(Table table)
        {
             fName = table.Rows[0]["firstname"];
            string mName = table.Rows[0]["middlename"];
            string lName = table.Rows[0]["lastname"];
            string empId = table.Rows[0]["employee_id"];
            string toggleLoginDetail = table.Rows[0]["toggle_login_detail"];
            string UserName = table.Rows[0]["username"];
            string password = table.Rows[0]["password"];
            string confirmPassword = table.Rows[0]["confirm_password"];
            string status= table.Rows[0]["status"];


            hooks.driver.FindElement(By.Name("firstName")).SendKeys(fName);
            hooks.driver.FindElement(By.Name("middleName")).SendKeys(mName);
            hooks.driver.FindElement(By.Name("lastName")).SendKeys(lName);
            //hooks.driver.FindElement(By.XPath("")).Clear();
            //hooks.driver.FindElement(By.XPath("")).SendKeys("788");

            if(toggleLoginDetail.Equals("on"))
            {
                hooks.driver.FindElement(By.XPath("//span[contains(@class,'oxd-switch-input')]")).Click();

                hooks.driver.FindElement(By.XPath("//label[contains(text(),'Username')]/following::input")).SendKeys(UserName);
                hooks.driver.FindElement(By.XPath("//label[contains(text(),'Password')]/following::input")).SendKeys(password);
                hooks.driver.FindElement(By.XPath("//label[contains(text(),'Confirm Password')]/following::input")).SendKeys(confirmPassword);
                //select status

                if(status.ToLower().Equals("disabled"))
                {
                    hooks.driver.FindElement(By.XPath("//label[text()='Disabled']")).Click();
                }
                else
                {
                    hooks.driver.FindElement(By.XPath("//label[text()='Enabled']")).Click();

                }
            }
        }

        [When(@"I click on save employee")]
        public void WhenIClickOnSaveEmployee()
        {
            hooks.driver.FindElement(By.XPath("//button[@type='submit']")).Click();    
        }

        [Then(@"I should be navigated to personal details section with added employee records")]
        public void ThenIShouldBeNavigatedToPersonalDetailsSectionWithAddedEmployeeRecords()
        {
            string actualFirstName=hooks.driver.FindElement(By.Name("firstName")).GetAttribute("value");
            Assert.Equal(fName, actualFirstName);
        }
    }
}
