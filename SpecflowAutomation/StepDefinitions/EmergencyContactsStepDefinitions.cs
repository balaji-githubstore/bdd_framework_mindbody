using OpenQA.Selenium;
using SpecflowAutomation.Hooks;
using System;
using TechTalk.SpecFlow;

namespace SpecflowAutomation.StepDefinitions
{
    [Binding]
    
    public class EmergencyContactsStepDefinitions
    {
        private static Table tbl;
        private AutomationHooks hooks;

        public EmergencyContactsStepDefinitions(AutomationHooks hooks)
        {
            this.hooks = hooks;
        }

        [When(@"I click on My Info")]
        public void WhenIClickOnMyInfo()
        {
            hooks.driver.FindElement(By.XPath("//span[text()='My Info']")).Click();
        }

        [When(@"I click on Emergency Contacts")]
        public void WhenIClickOnEmergencyContacts()
        {
            hooks.driver.FindElement(By.XPath("//a[text()='Emergency Contacts']")).Click();
        }

        [When(@"I click on add Assigned Emergency Contacts")]
        public void WhenIClickOnAddAssignedEmergencyContacts()
        {
            hooks.driver.FindElement(By.XPath("//h6[contains(@class,'orange')]/following::button")).Click();
            
        }

        [When(@"I fill the emergency contact details")]
        public void WhenIFillTheEmergencyContactDetails(Table table)
        {
            tbl = table;
            string name = table.Rows[0]["name"];
            string relationship= table.Rows[0]["relationship"];
            string homeTelephone = table.Rows[0]["home_telephone"];
            string workTelephone = table.Rows[0]["work_telephone"];
            string mobile = table.Rows[0]["mobile"];

            hooks.driver.FindElement(By.XPath("//label[contains(text(),'Name')]/following::input")).SendKeys(name);
            hooks.driver.FindElement(By.XPath("//label[contains(text(),'Relationship')]/following::input")).SendKeys(relationship);
            hooks.driver.FindElement(By.XPath("//label[contains(text(),'Home Tele')]/following::input")).SendKeys(homeTelephone);
            hooks.driver.FindElement(By.XPath("//label[contains(text(),'Mobile')]/following::input")).SendKeys(workTelephone);
            hooks.driver.FindElement(By.XPath("//label[contains(text(),'Work')]/following::input")).SendKeys(mobile);
        }


        [When(@"I click on save emergency contact")]
        public void WhenIClickOnSaveEmergencyContact()
        {  
            hooks.driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        [Then(@"I should see the added records in the table")]
        public void ThenIShouldSeeTheAddedRecordsInTheTable()
        {
            Thread.Sleep(5000);
            string actualData=hooks.driver.FindElement(By.XPath("//div[@class='oxd-table']")).Text;

            string expectedName = tbl.Rows[0]["name"];
            Assert.Contains(expectedName, actualData);
            Assert.Contains(tbl.Rows[0]["relationship"], actualData);
        }
    }
}
