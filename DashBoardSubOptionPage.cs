using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using Newtonsoft.Json.Linq;
using Microsoft.VisualBasic;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V113.FedCm;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumTestProject.PageObject.MakePayment;
using SeleniumTestProject.PageObject.ManageAccount;
using SeleniumTestProject.PageObject.ManageCustomer;
using SeleniumTestProject.Utilities;
using System.Transactions;

namespace SeleniumTestProject.PageObject
{
    public class DashBoardSubOptionPage
    {
        readonly ExtentTest test;
        readonly ActionDriver ad;
        readonly IWebDriver driver;
        readonly By CreateDstvBusineesCustomer = By.CssSelector("body>div[class='ember-view']>div>div>div:nth-child(1)>div:nth-of-type(2)>div>ul>li:nth-child(7)");
        readonly By CreateDealer = By.XPath("//a[contains(text(),'Create Dealer')]");
        readonly By CreateQuote = By.XPath("//a[contains(text(),'Create Quote')]");
        readonly By CreateCSICustomer = By.XPath("//a[contains(text(),'Create CSI Customer')]");
        readonly By GetConnectedOption = By.XPath("//a[contains(text(),'Get Connected')]");
        readonly By CreateResidentialCustomerCreation = By.XPath("//a[contains(text(), 'Create Residential Customer' )]");
        readonly By CreateSpecialistCustomerlink = By.XPath("//a[contains(text(), 'Create Specialist Customer' )]");
        readonly By ManageStock = By.XPath("//a[contains(text(), 'Manage Stock' )]");
        readonly By IssueHardwareSales = By.XPath("//a[contains(text(), 'Issue Hardware - Sales' )]");
        readonly By ManageViewinglink = By.XPath("//a[contains(text(), 'Manage Viewing' )]");
        readonly By AddDevicesAndPackageslink = By.XPath("//a[contains(text(), 'Add Devices and Packages' )]");
        readonly By MakePayments = By.XPath("//a[contains(text(), 'Make Payments' )]");
        readonly By CashSale = By.XPath("//a[contains(text(), 'Cash Sale' )]");
        readonly By MovePackages = By.XPath("//a[contains(text(), 'Move Packages' )]");
        readonly By CustomerDocuments = By.XPath("//a[contains(text(),'Customer Documents')]");
        readonly By ArchivedHistory = By.XPath("//a[contains(text(),'Archived History')]");
        readonly By ManageCase = By.XPath("//a[contains(text(),'Manage Case')]");
        readonly By Quotes = By.XPath("//a[normalize-space()='Quotes']");
        readonly By ViewFinancialTransactions = By.XPath("//a[normalize-space()='View Financial Transactions']");
        readonly By CreateCampaignTemplateLink = By.XPath("//*[text()='Create Campaign Template']");
        readonly By History = By.XPath("//a[contains(text(),'History')]");
        readonly By StolenDevicesLinks = By.XPath("//a[contains(text(), 'Stolen Devices' )]");
        readonly By CreateCaseOrInteraction = By.XPath("//a[contains(text(),'Create Case or Interaction')]");
        readonly By ManageCustomer = By.XPath("//a[contains(text(),'Manage Customer')]");
        readonly By ManageAccount = By.XPath("//a[contains(text(),'Manage Account')]");
        readonly By ManageExchangeRates = By.XPath("//a[contains(text(),'Manage Exchange Rates')]");
        readonly By EditPaymentDetails = By.XPath("//*[@class='ember-view nav nav-list']/child::li[contains(.,'Edit Payment Details')][last()]");
        readonly By PaymentReports = By.XPath("//a[contains(text(),'Payment Reports')]");
        readonly By DStvBusinessAddDevicesAndPackages = By.XPath("//a[contains(text(),'DStv Business -  Add Devices and Packages')]");
        readonly By XtraView = By.XPath("//a[normalize-space()='XtraView']");

        public DashBoardSubOptionPage(IWebDriver driver, ExtentTest test)
        {
            ad = new ActionDriver(driver);
            this.test = test;
            this.driver = driver;
        }

        public void SelectSubOption(string subOption)
        {
            TestContext.Progress.WriteLine("Please Select the Get connected");
            var node = test.CreateNode("Select Sub Option");
            switch (subOption)
            {
                case "createDstvBusineesCustomer":
                    ad.Click(CreateDstvBusineesCustomer, "createdstvbusineescustomer", node);

                    break;
                case "createDealer":
                    ad.Click(CreateDealer, "createdealer", node);

                    break;
                case "createQuote":
                    ad.Click(CreateQuote, "createQuote", node);
                    break;
                case "getconnected":

                    ad.Click(GetConnectedOption, "getconnected", node);
                    break;
                case "createResidentialCustomer":

                    ad.Click(CreateResidentialCustomerCreation, "CreateResidentialCustomerCreation", node);
                    break;
                case "createSpecialistCustomer":

                    ad.Click(CreateSpecialistCustomerlink, "CreateSpecialistCustomerlink", node);
                    break;
                case "archivedHistory":
                    ad.Click(ArchivedHistory, "archivedHistory", node);
                    break;
                case "customerDocuments":
                    ad.Click(CustomerDocuments, "customerDocuments", node);
                    break;
                case "ManageStock":
                    ad.Click(ManageStock, "ManageStock", node);
                    break;
                case "IssueHardwareSales":
                    ad.Click(IssueHardwareSales, "IssueHardwareSales", node);
                    break;
                case "manageViewing":
                    ad.Click(ManageViewinglink, "ManageViewinglink", node);
                    ad.WaitForBusyElementToGo();
                    break;
                case "addDeviceAndPackages":
                    ad.WaitForBusyElementToGo();
                    ad.Click(AddDevicesAndPackageslink, "AddDevicesAndPackageslink", node);
                    break;
                case "makePayments":
                    ad.Click(MakePayments, "MakePayments", node);
                    break;
                case "cashSale":
                    ad.Click(CashSale, "CashSale", node);
                    break;
                case "movePackages":
                    ad.Click(MovePackages, "MovePackages", node);
                    break;
                case "manageCase":
                    ad.Click(ManageCase, "ManageCase", node);
                    break;
                case "Quotes":
                    ad.Click(Quotes, "Quotes", node);
                    break;
                case "ViewFinancialTransactions":
                    ad.Click(ViewFinancialTransactions, "ViewFinancialTransactions", node);
                    break;
                case "CreateCampaignTemplateLink":
                    ad.Click(CreateCampaignTemplateLink, "Create Campaign Template", node);
                    break;

                case "StolenDevices":
                    ad.WaitForBusyElementToGo();
                    ad.Click(StolenDevicesLinks, "Stolen Devices", node);
                    break;
                case "history":
                    ad.Click(History, "history", node);
                    break;
                case "createcase":
                    ad.Click(CreateCaseOrInteraction, "CreateCaseOrInteraction", node);
                    break;
                case "manageAccount":
                    ad.Click(ManageAccount, "ManageAccount", node);
                    break;
                case "manageCustomer":
                    ad.Click(ManageCustomer, "ManageCustomer", node);
                    break;
                case "ManageExchangeRates":
                    ad.Click(ManageExchangeRates, "Manage Exchange Rates", node);
                    break;
                case "paymentReports":
                    ad.Click(PaymentReports, "PaymentReports", node);
                    break;
                case "dStvBusinessAddDevicesAndPackages":
                    ad.Click(DStvBusinessAddDevicesAndPackages, "DStvBusinessAddDevicesAndPackages", node);
                    break;                              
                case "editPaymentDetails":
                    ad.Click(EditPaymentDetails, "editPaymentDetails", node);
                    break;
                case "XtraView":
                    ad.Click(XtraView, "XtraView", node);
                    break;
            }
        }
        /// <summary>
        /// Click on CSI Customer Link
        /// </summary>
        public void ClickOnCSICustomerLink()
        {
            var node = test.CreateNode("Click on Create CSI Customer");
            ad.Click(CreateCSICustomer, "Create CSI Customer", node);
        }
    }
}
