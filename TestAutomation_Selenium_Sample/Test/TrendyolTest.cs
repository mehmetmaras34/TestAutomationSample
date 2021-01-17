using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;
using TestAutomation_Selenium_Sample.PageModel;
using TestAutomation_Selenium_Sample.Utillities;

namespace TestAutomation_Selenium_Sample.Test
{
    [Binding,Scope(Feature="TrendyolTest")]
   public class TrendyolTest
    {
        public static IWebDriver WebDriver { get; set; }           
        public BasePage basePage;
        public LoginUserPage loginUserPage;
        public BoutiquePage boutiquePage;
        public ProductPage productPage;
        public BrowserUtility browserUtility;
        string driverPath= String.Empty;
        
        public TrendyolTest(){
            driverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            browserUtility=new BrowserUtility();
        }
        [AfterScenario]
        public void AfterSecenario()
        {
            browserUtility.TearDown();
        }

        [StepDefinition("'(.*)' browser açılır")]
        public void OpenBrowser(string driver){
            switch (driver){
                case "Chrome":
                    WebDriver = browserUtility.SetupChromeDriver(driverPath);
                    break;
                case "Firefox":
                    WebDriver = browserUtility.SetupFirefoxDriver(driverPath);
                    break;
                case "InternetExplorer":
                    WebDriver = browserUtility.SetupInternetExplorerDriver(driverPath);
                    break;
            }
            basePage=new BasePage(WebDriver);
            loginUserPage=new LoginUserPage(WebDriver);
            boutiquePage = new BoutiquePage(WebDriver);
            productPage=new ProductPage(WebDriver); 
        }
        [StepDefinition("'(.*)' sitesine gidilir")]
        public void OpenWebPage(string webPageUrl){
            WebDriver.Navigate().GoToUrl(webPageUrl);
        }
        [StepDefinition("Popup kapatılır")]
        public void CloseWebPagePopup(){
            loginUserPage.CloseThePopup();
            if (!basePage.GetCurrentUrl().Contains("trendyol.com")){
                Console.WriteLine("Anasayfa yüklenemedi!");
            }            
        }
        [StepDefinition("Giriş Yap butonuna tıklanır")]
        public void ClickToLogin(){
            loginUserPage.ClickToLogin();
            if (!basePage.GetCurrentUrl().Contains("trendyol.com/giris")){
                Console.WriteLine("Giriş sayfası yüklenemedi!");
            }
        }
        [StepDefinition("E-posta adresi '(.*)' olarak girilir")]
        public void SetEmail(string email){
            loginUserPage.SetEmail(email);
        }
        [StepDefinition("Şifre '(.*)' olarak girilir")]
        public void SetPassword(string password){
            loginUserPage.SetPassword(password);
        }

        [StepDefinition("Giriş yap butonuna tıklanır")]
        public void ClickToSubmitLogin(){
            loginUserPage.ClickSubmitLogin();
        }
        [StepDefinition("Login Popup kapatılır")]
        public void CloseLoginPopup()
        {
            loginUserPage.CloseLoginPopup();
            if (!basePage.GetCurrentUrl().Contains("trendyol.com/butik/liste/")){
                Console.WriteLine("Anasayfa yüklenemedi!");
            }
        }
        [StepDefinition("Kategori tablarına tıklanarak butiklerin yüklendikleri kontrol edilir")]
        public void CheckBoutique(){
            boutiquePage.ClickCategoriesTab();
        }
        [StepDefinition("Rastgele bir taba tıklanır")]
        public void ClickToRandomTab()
        {
            boutiquePage.ClickToRandomTab();
        }

        [StepDefinition("Rastgele butiğe tıklanır")]
        public void ClickToRandomBoutique()
        {
            boutiquePage.ClickRandomToBoutique();
        }
        [StepDefinition("Ürün görselleri kontrol edilir")]
        public void CheckProductImage()
        {
            productPage.CheckProductImage();
        }
        [StepDefinition("Rastgele ürüne tıklanır")]
        public void ClickToRandomProduct()
        {
            productPage.ClickRandomProduct();
        }
        [StepDefinition("Ürün sepete eklenir")]
        public void ClickToAddBasket()
        {
            productPage.ClickAddToBasket();
        }
    }
}
