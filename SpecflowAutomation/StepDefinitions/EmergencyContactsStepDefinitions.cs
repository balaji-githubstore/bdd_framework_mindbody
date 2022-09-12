using System;
using TechTalk.SpecFlow;

namespace SpecflowAutomation.StepDefinitions
{
    [Binding]
    public class EmergencyContactsStepDefinitions
    {
        [When(@"I click on My Info")]
        public void WhenIClickOnMyInfo()
        {
        
        }

        [When(@"I click on Emergency Contacts")]
        public void WhenIClickOnEmergencyContacts()
        {
            
        }

        [When(@"I click on add Assigned Emergency Contacts")]
        public void WhenIClickOnAddAssignedEmergencyContacts()
        {
          
        }

        [When(@"I fill the emergency contact details")]
        public void WhenIFillTheEmergencyContactDetails(Table table)
        {
        }

        [When(@"I click on save emergency contact")]
        public void WhenIClickOnSaveEmergencyContact()
        {
           
        }

        [Then(@"I should see the added records in the table")]
        public void ThenIShouldSeeTheAddedRecordsInTheTable()
        {
        }
    }
}
