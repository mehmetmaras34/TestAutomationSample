using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation_Selenium_Sample.PageModel
{
    public class BasePage{

        private IWebDriver webDriver;
        private WebDriverWait webDriverWait;
        private IWebElement webElement;

          public BasePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(this.webDriver, this);
        }

        /// <summary>
        /// Dynamics wait
        /// </summary>
        /// <param name="wait"></param>
        public void Wait(int wait)
        {
            webDriverWait = new WebDriverWait(this.webDriver,TimeSpan.FromSeconds(wait));
        }
        /// <summary>
        /// ClickableElement
        /// </summary>
        /// <param name="element"></param>
        public void ClickableElement(IWebElement element){
            Wait(15);
            webElement= webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }
        /// <summary>
        /// Click Element
        /// </summary>
        /// <param name="element"></param>
        public void ClickElement(IWebElement element){
            ClickableElement(element);
            element.Click();
        }
        /// <summary>
        /// Click Element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>
        public void SetText(IWebElement element, string text){
            ClickableElement(element);
            element.SendKeys(text);
        }
        /// <summary>
        /// Get Current Url
        /// </summary>
        public string GetCurrentUrl(){
            return this.webDriver.Url;
        }
           
    }
}
