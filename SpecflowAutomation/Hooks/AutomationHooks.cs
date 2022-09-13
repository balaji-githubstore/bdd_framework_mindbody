using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
//final
[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SpecflowAutomation.Hooks
{
    
    [Binding]
    public class AutomationHooks
    {
        public static IWebDriver driver;

        [BeforeTestRun]
        public static void Init()
        {
            //run only once at the beginnning 
        }

        [AfterTestRun]
        public static void End()
        {
            //run only once at the end
        }

        [BeforeFeature]
        public static void StartFeature()
        {

        }


        [AfterFeature]
        public static void EndFeature()
        {

        }

        [BeforeScenario]
        public void StartScenario()
        {

        }

        //runs after each scenario wether scenario passed or fail.  
        [AfterScenario]
        public void EndScenario()
        {
            if(driver!=null)
            {
                driver.Quit();
            }
        }

        [BeforeStep]
        public void BeforeStep()
        {

        }

        [AfterStep]
        public void AfterStep()
        {

        }

       
    }
}
