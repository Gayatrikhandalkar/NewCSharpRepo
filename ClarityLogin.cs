using SeleniumTestProject.Models;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumTestProject.Utilities;
using SeleniumTestProject.Utilities.DB.Base;

namespace SeleniumTestProject.PageObject
{
    public class ClarityLogin
	{
		readonly ActionDriver ad;
		public ExtentTest test;
        readonly IWebDriver driver;
        public By LogInClarityLoginuserNameText = By.Id("modal-modal-data-userName");
		public By OBJLoginPasswordText = By.Id("modal-modal-data-password");
		public By OBJloginCountryCombo = By.Id("modal-data-loginCountry");
		public By OBJloginButton = By.Id("modal-login-action");
		public By GetconnectionLink = By.XPath("/html/body/div[3]/div/div/div[2]/div[4]/div/div[1]/div/h3");
		public By modulesPopup = By.Id("modal-ok-action");
		public By settingsBtn = By.XPath("//*[@class='settings-btn']");
		public By logoutBtn = By.XPath("//*[@class='settings-nav-logout settings-nav']");
        public By GetConnected = By.XPath("//*[contains(@src,'Content/Images/Home/getConnected.svg')]");

        public ClarityLogin(IWebDriver driver, ExtentTest test)
		{
			ad = new ActionDriver(driver);
			this.test = test;
            this.driver = driver;
        }

		public void Login(ILoginModel clarityLoginModel)
		{
			var node = test.CreateNode("Clarity Login");
			ad.IsAlertPresent(node);
            ad.NavigateTo(clarityLoginModel.URL, node);
            ad.SendText(LogInClarityLoginuserNameText, "userName", clarityLoginModel.Username, node);
            ad.SendText(OBJLoginPasswordText, "Password", TestDataReader.Decoding(clarityLoginModel.Password), node);
            ad.DropDownByText(OBJloginCountryCombo, "OBJloginCountryCombo", clarityLoginModel.Country, node);
			ad.Click(OBJloginButton, "login", node);
			ad.IsAlertPresent(node);
			ad.WaitForBusyElementToGo();
			if (ad.ElementDisplayed(modulesPopup,node))
			{
				ad.Click(modulesPopup, "modulesPopup", node);
			}
			ad.ElementDisplayed(GetconnectionLink, node);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
        }
	}
}