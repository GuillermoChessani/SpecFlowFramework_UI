using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using OpenQA.Selenium.Chrome;

namespace SpecFlowFramework_UI.StepDefinitions
{
    [Binding]
    public class LoginTestsSteps
    {
        static IWebDriver driver;

        [Given(@"I am inside of login page")]
        public void GivenIAmInsideOfLoginPage()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            driver = new ChromeDriver();

            driver.Url = "https://opensource-demo.orangehrmlive.com/";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            Assert.True(driver.Title.Contains("OrangeHRM"));
            Console.WriteLine("Step Finished: User is on login page");
        }

        [When(@"I provide valid credentials and click Login button")]
        public void WhenIProvideValidCredentialsAndClickLoginButton()
        {
            driver.FindElement(By.Id("txtUsername")).SendKeys("Admin");
            driver.FindElement(By.Id("txtPassword")).SendKeys("admin123");
            driver.FindElement(By.Id("btnLogin")).Click();
            Console.WriteLine("Step Finished: User provided valid credentials and clicked Login Button");
        }

        [Then(@"Should let me pass to and show a welcome message")]
        public void ThenShouldLetMePassToAndShowAWelcomeMessage()
        {
            Assert.True(driver.FindElement(By.Id("welcome")).Displayed);
            Console.WriteLine("Step Finished: User is on dashboard page and saw welcome message");
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile("..\\..\\..\\TestEvidences\\Successful Login.png", ScreenshotImageFormat.Png);
            Console.WriteLine("Test Finished: Took Screenshot as Evidence and closed all sessions.");

            driver.Close();
            driver.Quit();
        }

        [When(@"I provide invalid ""([^""]*)"" and ""([^""]*)"" and click Login button")]
        public void WhenIProvideInvalidAndAndClickLoginButton(string Username, string Password)
        {
            driver.FindElement(By.Id("txtUsername")).SendKeys(Username);
            driver.FindElement(By.Id("txtPassword")).SendKeys(Password);
            driver.FindElement(By.Id("btnLogin")).Click();
            Console.WriteLine("Step Finished: User provided invalid credentials and clicked Login Button");
        }

        [Then(@"Should not let me pass and show an error message")]
        [Obsolete]
        public void ThenShouldNotLetMePassAndShowAnErrorMessage()
        {
            Assert.True(driver.FindElement(By.XPath("//span[@id='spanMessage']")).Displayed);
            Console.WriteLine("Step Finished: User is still on login page and saw error message");

            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            var screenShotFileName = "Unsuccessfull Login - " + ScenarioContext.Current.ScenarioInfo.Arguments["Scenario"] + ".png";
            ss.SaveAsFile("..\\..\\..\\TestEvidences\\" + screenShotFileName, ScreenshotImageFormat.Png);
            Console.WriteLine("Test Finished: Took Screenshot as Evidence and closed all sessions.");
            driver.Quit();
        }

    }
}
