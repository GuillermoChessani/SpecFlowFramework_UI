using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace SpecFlowFramework_UI.PageObjects
{
    public class LoginPage
    {
        public readonly IWebDriver _webDriver;
        public readonly By txtUsername = By.Id("txtUsername");
        public readonly By txtPassword = By.Id("txtPassword");
        public readonly By btnLogin = By.Id("btnLogin");
        public readonly By btnLogin = By.Id("btnLogin");
        public readonly By welcomeMessage = By.Id("welcome");
        public readonly By errorMessage = By.XPath("//span[@id='spanMessage']");

        public LoginPage(IWebDriver _webDriver) {
            this._webDriver = _webDriver;
        }

       
        public void SetUsername(String username) {
            _webDriver.FindElement(txtUsername).SendKeys(username);
        }

        public void SetPassword(String password)
        {
            _webDriver.FindElement(txtPassword).SendKeys(password);
        }

        public void ClickLoginButton()
        {
            _webDriver.FindElement(btnLogin).Click();
        }

        public Boolean IsWelcomeMessageDisplayed() {
            return _webDriver.FindElement(welcomeMessage).Displayed;
        }

        public Boolean IsErrorMessageDisplayed()
        {
            return _webDriver.FindElement(errorMessage).Displayed;
        }

    }
}
