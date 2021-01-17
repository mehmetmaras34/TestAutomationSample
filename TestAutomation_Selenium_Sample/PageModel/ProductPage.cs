using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation_Selenium_Sample.PageModel
{
    public class ProductPage : BasePage
    {
        private IWebDriver webDriver;
        public ProductPage(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
        }

        [FindsBy(How = How.XPath, Using = "//img[contains(@class,'p-card-img')]")]
        public IList<IWebElement> productImageList;

        [FindsBy(How = How.XPath, Using = "//span[contains(@class,'name')]")]
        public IList<IWebElement> txtProductName;

        [FindsBy(How = How.XPath, Using = "//button[(@class='pr-in-btn add-to-bs')]")]
        public IWebElement btnAddToBasket;
        public void CheckProductImage()
        {
            Wait(10);         
            for (int i = 0; i < productImageList.Count; i++)
            {
                Wait(10);
                if (productImageList[i].Enabled)
                {
                    Wait(10);
                    Console.WriteLine(txtProductName[i].Text + " ürününün resmi mevcut değil!");
                }
            }
        }
        public void ClickRandomProduct()
        {
            Wait(10);
            Random rnd = new Random();
            int rndProduct = rnd.Next(1, productImageList.Count - 1);
            ClickableElement(productImageList[rndProduct]);
            ClickElement(productImageList[rndProduct]);
        }
        public void ClickAddToBasket()
        {
            Wait(10);
            ClickableElement(btnAddToBasket);
            ClickElement(btnAddToBasket);
        }
    }
}