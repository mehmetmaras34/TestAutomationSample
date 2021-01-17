using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation_Selenium_Sample.PageModel
{
    public class LoginUserPage:BasePage    {
        private IWebDriver webDriver;
        public LoginUserPage(IWebDriver webDriver) : base(webDriver) {
            this.webDriver = webDriver;
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='account-navigation-container']/div/div[1]/div[1]/p")]
        public IWebElement btnLogin;

        [FindsBy(How = How.XPath, Using = "//a[@title='Close']")]
        public IWebElement btnClosePopup;

        [FindsBy(How = How.XPath, Using = "//*[@id='login-email']")]
        public IWebElement txtEmail;

        [FindsBy(How = How.XPath, Using = "//*[@id='login-password-input']")]
        public IWebElement txtPassword;

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'submit')]")]
        public IWebElement btnSubmit;

        [FindsBy(How = How.XPath, Using = "//*[@id='modal-root']/div/div/div[1]")]
        public IWebElement btnCloseLoginPopup;

        public void CloseThePopup()
        {
            ClickElement(btnClosePopup);
        }
        public void ClickToLogin(){
            ClickElement(btnLogin);
        }        
        public void SetEmail(string email){
            SetText(txtEmail, email);
        }
        public void SetPassword(string password){
            SetText(txtPassword, password);
        }
        public void ClickSubmitLogin(){
            ClickElement(btnSubmit);
        }
        public void CloseLoginPopup(){
            ClickElement(btnCloseLoginPopup);
        }
    }
}
