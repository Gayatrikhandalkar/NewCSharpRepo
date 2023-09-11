using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumTestProject.Utilities;

namespace SeleniumTestProject.PageObject
{
    internal class DashBoardOptionsPage
    {
        readonly ActionDriver ad;
        public ExtentTest test;
        readonly IWebDriver driver;

        public By GetConnectedOption = By.XPath("//*[contains(@src,'Content/Images/Home/getConnected.svg')]");
        public By SettingOption = By.Id("settingsImage");
        public By LogoutButton = By.XPath("//div[@class='settings-nav-logout settings-nav']//div//a");

        public By ManageCustomerLink = By.XPath("//*[text()='Manage Customer']");
        public By MakePaymentsLink = By.XPath("(//*[text()='Make Payments'])[2]");

        public By ManageViewingLink = By.XPath("//*[text()=\"Manage Viewing\"]");
        public By BusyIndicator = By.XPath("//*[@class='ember-view komodo-busy']");
        public By ViewBtn = By.XPath("//*[@class='ember-view btn btn-sm btn-primary btn-xs visible']");
        public By ManageAccountLink = By.XPath("//a[text()='Manage Account']");
        public By ManageCustomerOption = By.XPath("//a[text()='Manage Customer']");
        public By PrincipleStatusText = By.XPath("//tr[contains(., 'Pending')]");
        public By PrincipleStatusTextafter = By.XPath("//tr[contains(., 'Active')]");
        public By DashboardNav = By.XPath("//div[not(contains(@class,'komodo-hidden')) and contains (@role,'navigation')]");

        public By UpdatCustomerDetails = By.XPath("//div[@class='message-box-warning']/h4");
        public By UpdatCustomerDetailsBUttonNo = By.XPath("//button[@id='modal-no-action']");

        public By ManageStockLink = By.XPath("//a[text()='Manage Stock']");
        public By ManagePaymentAndTransactions = By.XPath("//*[contains(@src,'Content/Images/Home/unallocatedPayments.svg')]");
        public By ManagePaymentAndTransactionsLink = By.XPath("//a[contains(text(),'Manage Payments')]");
        public By EditPaymentDetails = By.XPath("(//a[text()='Edit Payment Details'])[2]");
        public By ManageExchangesRates = By.XPath("//a[contains(text(), 'Manage Exchange Rates' )]");
        public By MakePayments = By.XPath("//a[text()='Make Payments']");
        readonly By SearchSiteButton = By.XPath("//img[@id='sitesearchbutton']");

        public DashBoardOptionsPage(IWebDriver driver, ExtentTest test)
        {
            ad = new ActionDriver(driver);
            this.test = test;
            this.driver = driver;
        }

        public void SelectOption(string dashboardOption)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            var node = test.CreateNode("Select Option");
            ad.ScrollTo(SearchSiteButton, node);
            switch (dashboardOption)
            {
                case "GetConnected":

                    w.Until(ExpectedConditions.ElementExists(GetConnectedOption));
                    ad.Click(GetConnectedOption, "getconnected", node);
                    break;

                case "ManageViewing":

                    w.Until(ExpectedConditions.ElementExists(ManageViewingLink));
                    ad.Click(ManageViewingLink, "Manage Viewing Page Link", node);
                    break;

                case "ManageCustomer":
                    w.Until(ExpectedConditions.ElementExists(ManageCustomerLink));
                    ad.Click(ManageCustomerLink, "Manage Customer Page Link", node);
                    if (ad.ElementDisplayed(UpdatCustomerDetails, node).ToString().Equals("True"))
                    {
                        ad.Click(UpdatCustomerDetailsBUttonNo, "UpdatCustomerDetailsBUttonNo", node);
                    }
                    break;

                case "ManageAccount":
                    w.Until(ExpectedConditions.ElementExists(ManageAccountLink));
                    ad.Click(ManageAccountLink, "Manage Account Page Link", node);
                    w.Until(ExpectedConditions.ElementToBeClickable(ViewBtn));
                    break;

                case "MakePayments":
                    w.Until(ExpectedConditions.ElementExists(MakePayments));
                    ad.WaitForBusyElementToGo();
                    ad.Click(MakePayments, "MakePayments", node);
                    break;

                case "Manage Stock":
                    w.Until(ExpectedConditions.ElementExists(ManageStockLink));
                    ad.Click(ManageStockLink, "Manage Stock Page Link", node);
                    break;

                case "ManagePaymentAndTransactions":
                    w.Until(ExpectedConditions.ElementExists(ManagePaymentAndTransactions));
                    ad.Click(ManagePaymentAndTransactions, "ManagePayment And Transactions", node);
                    ad.WaitForBusyElementToGo();
                    break;

                case "ManagePaymentAndTransactionsLink":
                    w.Until(ExpectedConditions.ElementExists(ManagePaymentAndTransactionsLink));
                    ad.Click(ManagePaymentAndTransactionsLink, "ManagePayment And Transactions", node);
                    ad.WaitForBusyElementToGo();
                    break;

                case "ManageCampaignsAndOperationalMessages":
                    ad.Click(By.XPath("//h3[contains(text(),'" + "Manage Campaigns And Operational Messages" + "')]"), "Select Module", node);
                    ad.WaitForBusyElementToGo();
                    break;

                case "EditPaymentDetails":
                    w.Until(ExpectedConditions.ElementExists(EditPaymentDetails));
                    ad.Click(EditPaymentDetails, "Edit Payment Details", node);
                    ad.WaitForBusyElementToGo();
                    break;
                case "ManageExchangesRates":
                    w.Until(ExpectedConditions.ElementExists(ManageExchangesRates));
                    ad.WaitForBusyElementToGo();
                    ad.Click(ManageExchangesRates, "ManageExchangesRates", node);
                    break;

                default:

                    TestContext.Progress.WriteLine("Please Select the correct option");
                    break;
            }
        }

        public void SelectModule(string module)
        {
            var node = test.CreateNode("Click on the " + module + " module!");
            if (ad.IsElementPresent(DashboardNav))
            {
                ad.ScrollTo(By.XPath("//img[@id='sitesearchbutton']"), node);
                ad.Click(By.XPath("//a[contains(text(),'" + module + "')]"), "Select Module", node);
            }
            else
            {
                ad.Click(By.XPath("//h3[contains(text(),'" + module + "')]"), "Select Module", node);
            }
            if(ad.IsElementPresent(BusyIndicator))
            {
                ad.FluentWaitForBusyElement();
            }
        }

        public void ClicklogoutOption()
        {
            var node = test.CreateNode("Logout option performed");
            ad.Click(SettingOption, "settingOption", node);
            ad.Click(LogoutButton, "logoutButton", node);
            if (ad.IsAlertPresent(node))
            {
                ad.IsAlertPresent(node);
            }
        }

        public string GetPrinciplePackageNameadnStatus()
        {
            var node = test.CreateNode("Select Manage Viewing Option");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.Until(ExpectedConditions.ElementIsVisible(PrincipleStatusText));
            String principlePackageNameadnStatusText = ad.GetText(PrincipleStatusText, "Grabing product name and it status on Manage Viewing page", node);
            return principlePackageNameadnStatusText;

        }

        public string GetPrinciplePackageNameadnStatusAfter()
        {
            var node = test.CreateNode("Select Manage Viewing Option");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.Until(ExpectedConditions.ElementIsVisible(PrincipleStatusTextafter));
            String principlePackageNameadnStatusText = ad.GetText(PrincipleStatusTextafter, "Grabing product name and it status on Manage Viewing page", node);
            return principlePackageNameadnStatusText;
        }

    }
}
