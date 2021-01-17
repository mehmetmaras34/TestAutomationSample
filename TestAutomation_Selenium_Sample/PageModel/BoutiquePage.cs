using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace TestAutomation_Selenium_Sample.PageModel
{
    public class BoutiquePage : BasePage
    {
        private IWebDriver webDriver;
        public BoutiquePage(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='navigation-wrapper']/nav/ul/li")]
        public IList<IWebElement> categoriesTabList;

        [FindsBy(How = How.XPath, Using = "//article[@class='component-item']/a/summary/span[@class='name']")]
        public IList<IWebElement> boutiqueName;

        [FindsBy(How = How.XPath, Using = "//a/span[@class='image-container']/img")]
        public IList<IWebElement> boutiqueImage;


        public void ClickCategoriesTab()
        {
            for (int i = 0; i < categoriesTabList.Count; i++)
            {
                Wait(5);
                if (categoriesTabList[i].Enabled)
                {
                    Console.WriteLine(categoriesTabList[i].Text + " Kategori tabı mevcut değil!");
                }
                ClickableElement(categoriesTabList[i]);
                ClickElement(categoriesTabList[i]);
                if (!GetCurrentUrl().Contains("trendyol.com/butik/liste/" + categoriesTabList[i].Text.ToLower()))
                {
                    Console.WriteLine(categoriesTabList[i].Text + " Kategori tabına ait sayfa yüklenemedi!");
                }
                CheckBoutique();
            }
        }

        public void CheckBoutique()
        {
            for (int i = 0; i < boutiqueName.Count; i++)
            {
                Wait(10);
                if (boutiqueImage[i].Enabled)
                {
                    Wait(10);
                    Console.WriteLine(boutiqueName[i] + " butiğe ait resimler mevcut değil!");
                }
            }
        }
        public void ClickToRandomTab()
        {
            Wait(10);
            Random rnd = new Random();
            int rndBoutique = rnd.Next(1, categoriesTabList.Count - 1);
            ClickableElement(categoriesTabList[rndBoutique]);
            ClickElement(categoriesTabList[rndBoutique]);
        }
        public void ClickRandomToBoutique()
        {
            Wait(10);
            Random rnd = new Random();
            int rndBoutiqueCategori = rnd.Next(1, boutiqueImage.Count - 1);
            ClickableElement(boutiqueImage[rndBoutiqueCategori]);
            ClickElement(boutiqueImage[rndBoutiqueCategori]);
        }
    }
}
