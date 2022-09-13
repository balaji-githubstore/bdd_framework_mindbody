using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using SpecflowAutomation.Hooks;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecflowAutomation.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private AutomationHooks hooks;

        public LoginStepDefinitions(AutomationHooks hooks)
        {
            this.hooks = hooks;
        }

        [Given(@"I have '([^']*)' browser with orangehrm page")]
        public void GivenIHaveBrowserWithOrangehrmPage(string browser)
        {
            if(browser.Equals("edge"))
            {
                hooks.driver = new EdgeDriver();
            }
            else if (browser.Equals("ff"))
            {
                hooks.driver = new FirefoxDriver();
            }
            else
            {
                hooks.driver = new ChromeDriver();
            }

            hooks.driver.Manage().Window.Maximize();
            hooks.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            hooks.driver.Url = "https://opensource-demo.orangehrmlive.com/";
        }


        [Given(@"I have browser with orangehrm page")]
        public void GivenIHaveBrowserWithOrangehrmPage()
        {
            hooks.driver = new ChromeDriver();
            hooks.driver.Manage().Window.Maximize();
            hooks.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            hooks.driver.Url = "https://opensource-demo.orangehrmlive.com/";
        }

        [When(@"I enter username as '([^']*)'")]
        public void WhenIEnterUsernameAs(string username)
        {
            hooks.driver.FindElement(By.Name("username")).SendKeys(username);
        }

        [When(@"I enter password as '([^']*)'")]
        public void WhenIEnterPasswordAs(string password)
        {
            hooks.driver.FindElement(By.Name("password")).SendKeys(password);
        }

        [When(@"I click on login")]
        public void WhenIClickOnLogin()
        {
            hooks.driver.FindElement(By.CssSelector("button[type='submit']")).Click();
        }

        [Then(@"I should be navigate to '([^']*)' dashboard screen")]
        public void ThenIShouldBeNavigateToDashboardScreen(string expectedValue)
        {
            Console.WriteLine(expectedValue);
          
        }

        [Then(@"I should get error message as '([^']*)'")]
        public void ThenIShouldGetErrorMessageAs(string expectedError)
        {
           string actualError = hooks.driver.FindElement(By.CssSelector(".oxd-alert-content-text")).Text;
           Assert.Equal(expectedError, actualError);
    
        }

    }
}
