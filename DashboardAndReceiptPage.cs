using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumTestProject.Models;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumTestProject.Utilities;
using AventStack.ExtentReports.Gherkin.Model;
using System.Xml.Linq;
using SeleniumTestProject.Utilities.DB.Base;
using SeleniumTestProject.Utilities.DB.CustomQueries;
using SeleniumTestProject.PageObject.GetConnected;

namespace SeleniumTestProject.PageObject
{
    public class DashboardAndReceiptPage
    {
        readonly IWebDriver driver;
        readonly ActionDriver ad;
        readonly ExtentTest test;
        string customerNumber;

        public By DealerCreated = By.XPath("//p[contains(text(),'Dealer Created')]");
        public By SearchField = By.Id("searchfield");
        public By SearchButton = By.XPath("//button[@class='btn btn-primary btn-sm']");
        public By SelectCustomer = By.XPath("//td[@class='searchresults-type']");
        public By CustomersNumber = By.XPath("//span[@id='customerNumberData']");
        public By SelectQuote = By.XPath("//td[@class='searchresults-type']");
        public By CustomerVerified = By.XPath("//button[contains(text(),'Customer Verified')]");
        public By FullName = By.XPath("//*[contains(@id,'fullName-label')]");
        public By CompanyRegistrationNumber = By.Id("companyRegistrationNumberData");
        public By VatNumber = By.Id("vatNumberData");
        public By TaxNumber = By.Id("taxNumberData");
        public By DelearName = By.Id("customertitle");
        public By CustomerAuthorised = By.XPath("//button[@id='modal-customerAuthorised-action']");
        public By Email = By.Id("customeremail");
        public By Phone = By.Id("customerphone");
        public By PhysicalAddress = By.Id("physicalAddressData");
        public By CustomerType = By.Id("customertype");
        public By PrimaryDropDownToggleButton = By.XPath("//*[contains(@data-toggle,'dropdown')]//span");
        public By SearchQuoteActionDropDownButton = By.XPath("//li[@id='searchQuote-action']//a");
        public By DataStatus = By.XPath("//span[contains(text(),'Completed')]");
        public By AcceptQuoteButton = By.XPath("//button[@id='createCustomer-action']");
        public By ExtraElement = By.XPath("//div[@class='simplemodal-overlay']");
        public By UpdateCustomerDetailsNo = By.XPath("//button[@id='modal-no-action']");
        public By CompanyName = By.XPath("//div[@class='left']//div[2]//span[1]");
        public By CompanyNumber = By.XPath("//div[@class='left']//div[2]//span[2]");
        public By PersonMakingContact = By.XPath("//select[@id='modal-contactedPerson']");
        public By ThirdPartyPersonMakingContact = By.XPath("//select[@id='modal-customerInformationModel-personContactData']");
        public By SelectRecentCust = By.XPath("//*[@id='recentCustomersButton']");
        public By ClickOnViewRecent = By.XPath("//*[@class='ember-view ember-link']");
        public By ActivateCustomerYesBtn = By.XPath("//button[@id=\"modal-yes-action\"]");
        public By UpdatCustomerDetails = By.XPath("//div[@class='message-box-warning']/h4");
        public By UpdatCustomerDetailsBUttonNo = By.XPath("//button[@id='modal-no-action']");
        public By ActiveStatus = By.XPath("//select[@id='viewAccountInformationModel-selectedAcccountStatus']/option[contains(., 'Open')]");
        public By SaveBtn = By.Id("saveAccountStatus-action");
        public By StatusUpdatePopUp = By.Id("modal-ok-action");
        public By IncompleteCustomerDataMessageBox = By.XPath("//*[contains(text(),'Incomplete Customer Data')]");
        public By CompleteCustomerDetailsYes = By.XPath("//button[@id='modal-yes-action']");
        public By MenuToggleIcon = By.XPath("//div[@id='icon-toggle']");
        public By SearchResultText = By.XPath("//p[contains(text(),\"No result\")]");
        public By CloseSearchResult = By.XPath("//a[@class='close']");
        public By SearchButtonDropDown = By.XPath("//button[@class='btn btn-primary btn-sm']//following-sibling::button");
        public By CaseOptionFromDropDown = By.XPath("//a[contains(text(),'Device')]//parent::li//preceding-sibling::li[1]");
        public By SelectCustomerCase = By.XPath("//table[@class='komodo-searchresults']//td[@class='sub-heading']");
        public By OkButton = By.XPath("//button[@id='modal-ok-action']");
        public By NoResultFound = By.XPath("//p[contains(text(),'No result found!')]");
        readonly By UpdateCustomerDetailsYes = By.XPath("//button[@id='modal-yes-action']");
        readonly By EditSpecialistCustomerPage = By.XPath("//a[text()='Specialist - Edit Customer Information']");

        public DashboardAndReceiptPage(IWebDriver driver, ExtentTest test)
        {
            this.driver = driver;
            ad = new ActionDriver(driver);
            this.test = test;
        }

        public void VisibilityOfElement()
        {
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(80));
            w.Until(ExpectedConditions.ElementExists(DealerCreated));
            TestContext.Progress.WriteLine(driver.FindElement(DealerCreated).Text);
            Assert.That(driver.FindElement(DealerCreated).Text, Is.EqualTo("Dealer Created"));
        }

        public void CaptureCustomerNumber()
        {
            ad.FluentWaitMethod(CustomersNumber, "customernumber");
            this.customerNumber = driver.FindElement(CustomersNumber).Text;
            TestContext.Progress.WriteLine(customerNumber);
        }

        public void CustomerSearch()
        {
            var node = test.CreateNode("Customer is searched with Captured Number");
            ad.SendText(SearchField, "searchfield", customerNumber, node);
            ad.Click(SearchButton, "searchbuttton", node);
        }

        public void SelectCustomerFromPopup()
        {
            var node = test.CreateNode("searched Customer is selected");
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            w.Until(ExpectedConditions.ElementToBeClickable(SelectCustomer));
            ad.Click(SelectCustomer, "select_customer", node);
        }
        public void LoadCustomer(String customerNumber)
        {
            var node = test.CreateNode("Load Customer");
            ad.SendText(SearchField, "search_field", customerNumber, node);
            ad.Click(SearchButton, "search_buttton", node);
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            w.Until(ExpectedConditions.ElementToBeClickable(SelectCustomer));
            ad.Click(SelectCustomer, "select_customer", node);
            UpdateCustomerDetailsIfAny();
        }

        public void QuoteSearch()
        {
            var node = test.CreateNode("Customer is searched with Captured Number");
            ad.SendText(SearchField, "searchfield", "QZAF-3124870", node);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            w.Until(ExpectedConditions.InvisibilityOfElementLocated(ExtraElement));
            w.Until(ExpectedConditions.ElementToBeClickable(PrimaryDropDownToggleButton));
            ad.Click(PrimaryDropDownToggleButton, "primaryDropDownToggleButton", node);
            ad.Click(SearchQuoteActionDropDownButton, "searchQuoteActionDropDownButton", node);
        }

        public void CaptureCustomerNumberUpdated()
        {
            var node = test.CreateNode("CaptureCustomerNumberUpdated");
            TestDataStore.CreateSpecialistCustomerModel.CustomerNumber = ad.GetText(CustomersNumber, "customersNumber", node);
        }

        public void SelectQuoteFromPopup()
        {
            var node = test.CreateNode("searched Customer is selected");
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(80));
            w.Until(ExpectedConditions.ElementExists(SelectQuote));
            ad.Click(SelectQuote, "selectquote", node);
        }

        public void VerifyQuoteDetails()
        {
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            w.Until(ExpectedConditions.ElementExists(DataStatus));
            Assert.That(driver.FindElement(DataStatus).Text, Is.EqualTo("Completed"));
            w.Until(ExpectedConditions.ElementExists(AcceptQuoteButton));
            Assert.That(driver.FindElement(AcceptQuoteButton).Enabled, Is.False);
        }


        public void ExistingCustomerSearch(ExistingCustomerModel existingCustomerModel, string CustomerType)
        {
            switch (CustomerType)
            {
                case "customerNumber":

                    LoadCustomer(existingCustomerModel.CustomerNumber);

                    break;

                case "CustomerDealerNumber":

                    LoadCustomer(existingCustomerModel.CustomerDealerNumber);

                    break;
                case "SpecialistCustomerNumber":

                    LoadCustomer(existingCustomerModel.SpecialistCustomerNumber);

                    break;
                case "CommercialCustomerNumber":

                    LoadCustomer(existingCustomerModel.CommercialCustomerNumber);

                    break;
                case "CommercialCustomerNumberK":

                    LoadCustomer(existingCustomerModel.CommercialCustomerNumberClearError);

                    break;
                case "MigratedCustomer":

                    LoadCustomer(existingCustomerModel.MigratedCustomer);

                    break;
                case "PiracyAccount":

                    LoadCustomer(existingCustomerModel.PiracyAccount);

                    break;
                case "Suspended":

                    LoadCustomer(existingCustomerModel.Suspended);

                    break;
                case "CommercialCustomerNumberSuspension":

                    LoadCustomer(existingCustomerModel.CommercialCustomerNumberSuspension);

                    break;

                case "CustomerNumberForPreactivateEBQPendingQuote":

                    LoadCustomer(existingCustomerModel.CustomerNumberForPreactivateEBQPendingQuote);

                    break;

                case "ArchivedFinancialTransactionsCustomer":

                    LoadCustomer(existingCustomerModel.ArchivedFinancialTransactionsCustomer);

                    break;

                case "ResidentialCustomerNumberCash":

                    LoadCustomer(existingCustomerModel.ResidentialCustomerNumberCash);

                    break;

                case "SpecialistHHSwitchingDeviceGeneralCustomer":

                    LoadCustomer(existingCustomerModel.SpecialistHHSwitchingDeviceGeneralCustomer);

                    break;

                case "PreActivateXtraviewQuoteCustomer":

                    LoadCustomer(existingCustomerModel.PreActivateXtraviewQuoteCustomer);

                    break;

                case "ResidentialPrintandEmailProformaNig":

                    LoadCustomer(existingCustomerModel.ResidentialPrintandEmailProformaNig);

                    break;

                case "ReversalForArchiveFTApprovalRequired":

                    LoadCustomer(existingCustomerModel.ReversalForArchiveFTApprovalRequired);

                    break;

                case "ManualDebitOrCreditRejectJournal":

                    LoadCustomer(existingCustomerModel.ManualDebitOrCreditRejectJournal);

                    break;
                case "CustomerClearingCashSale":

                    LoadCustomer(existingCustomerModel.CustomerClearingCashSale);

                    break;

                case "CommercialWithMultipleDeviceLinked":

                    LoadCustomer(existingCustomerModel.CommercialWithMultipleDeviceLinked);

                    break;

                case "CustomerNumberForEditDeviceForAngola":

                    LoadCustomer(existingCustomerModel.CustomerNumberForEditDeviceForAngola);

                    break;

                case "CustomerNumberForEditDeviceForKenya":

                    LoadCustomer(existingCustomerModel.CustomerNumberForEditDeviceForKenya);

                    break;
                case "CustomerNumberForEditDeviceForNigeria":

                    LoadCustomer(existingCustomerModel.CustomerNumberForEditDeviceForNigeria);

                    break;
                case "MovePackagesLikeToLikeDecoder":

                    LoadCustomer(existingCustomerModel.MovePackagesLikeToLikeDecoder);

                    break;

                case "MovePackagesLikeToDifferentDecoder":
                    LoadCustomer(existingCustomerModel.MovePackagesLikeToDifferentDecoder);
                    break;

                case "MaximumGarceDaysUsedResidential":

                    LoadCustomer(existingCustomerModel.MaximumGarceDaysUsedResidential);
                    break;

                case "CommercialCustomer":

                    LoadCustomer(existingCustomerModel.CommercialCustomer);

                    break;
            }
        }

        public void ExistingCustomerSearch(String CustNo)
        {
            var node = test.CreateNode("Customer is searched with Existing Number");
            EditCustomerPage ecp = new EditCustomerPage(driver, test);
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            ad.SendText(SearchField, "search_field", CustNo, node);
            ad.Click(SearchButton, "search_buttton", node);
            if (ad.ElementDisplayed(NoResultFound, node))
            {
                ad.Click(CloseSearchResult, "CloseSearchResult", node);
                ad.SendText(SearchField, "search_field", CustNo, node);
                ad.Click(SearchButton, "search_buttton", node);
            }
            w.Until(ExpectedConditions.ElementToBeClickable(SelectCustomer));
            ad.Click(SelectCustomer, "select_customer", node);
            if (ad.IsElementPresent(PersonMakingContact) && ad.GetDropDownValueAtOption(PersonMakingContact, "personMakingContact", 0, node).Equals(""))
            {
                ad.DropDownByIndex(PersonMakingContact, "personMakingContact", 1, node);
            }
            else if(ad.IsElementPresent(ThirdPartyPersonMakingContact) && ad.GetDropDownValueAtOption(ThirdPartyPersonMakingContact, "ThirdPartyPersonMakingContact",0, node).Equals(""))
            {
                ad.DropDownByIndex(ThirdPartyPersonMakingContact, "ThirdPartyPersonMakingContact", 1, node);
            }
            w.Until(ExpectedConditions.ElementToBeClickable(CustomerVerified));
            Assert.That(driver.FindElement(CustomerVerified).Enabled, Is.True);
            ad.Click(CustomerVerified, "select_customer", node);
            if (ad.ElementDisplayed(IncompleteCustomerDataMessageBox, node).ToString().Equals("True"))
            {
                ad.Click(CompleteCustomerDetailsYes, "CompleteCustomerDetailsYes", node);
                ecp.BypassEditCustomerDetails();
            }                                  
            if (ad.ElementDisplayed(UpdatCustomerDetails, node).ToString().Equals("True"))
            {
                ad.Click(UpdatCustomerDetailsBUttonNo, "UpdatCustomerDetailsBUttonNo", node);
            }
        }

        public void VerifyCompanyDetails(string CustomerDealer)
		{
			var node = test.CreateNode("Company details verification");
            ad.Click(MenuToggleIcon, "MenuToggleIcon",node);
            TestContext.Progress.WriteLine(driver.FindElement(CompanyName).Text);
            TestContext.Progress.WriteLine(driver.FindElement(CompanyNumber).Text);
			Assert.Multiple(() =>
			{
				Assert.That(driver.FindElement(CompanyName).Text, !Is.Empty);
				Assert.That(driver.FindElement(CompanyNumber).Text, Is.EqualTo(CustomerDealer));
			});
		}

		public void VerifyCompanyDetails(ExistingCustomerModel existingCustomerModel)
		{
			TestContext.Progress.WriteLine(driver.FindElement(CompanyName).Text);
            TestContext.Progress.WriteLine(driver.FindElement(CompanyNumber).Text);
			Assert.Multiple(() =>
			{
				Assert.That(driver.FindElement(CompanyName).Text, !Is.Empty);
				Assert.That(driver.FindElement(CompanyNumber).Text, Is.EqualTo(existingCustomerModel.CustomerDealerNumber));
			});
		}

		public void SelectRecentCustomer()
        {
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
            var node = test.CreateNode("Select recent customer");
            ad.Click(SelectRecentCust, " Selected recent customer", node);
            w.Until(ExpectedConditions.ElementExists(ClickOnViewRecent));
            ad.Click(ClickOnViewRecent, "VIew", node);
            w.Until(ExpectedConditions.ElementExists(CustomerVerified));
            ad.Click(CustomerVerified, "Approve customer", node);
        }
        public void UpdateCustomerDetailsIfAny()
        {
            var node = test.CreateNode("Updating details if needed");
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            if (ad.GetDropDownValueAtOption(PersonMakingContact, "personMakingContact", 0, node).Equals(""))
            {
                ad.DropDownByIndex(PersonMakingContact, "personMakingContact", 1, node);
            }
            w.Until(ExpectedConditions.ElementToBeClickable(CustomerVerified));
            Assert.That(driver.FindElement(CustomerVerified).Enabled, Is.True);
            ad.Click(CustomerVerified, "select_customer", node);
            if (ad.IsElementPresent(UpdateCustomerDetailsNo))
            {
                    ad.Click(UpdateCustomerDetailsNo, "updateCustomerDetailsNo", node);
            }
            if (ad.IsElementPresent(ActivateCustomerYesBtn))
            {
                ad.Click(ActivateCustomerYesBtn, "ActivateCustomerYesBtn", node);
                w.Until(ExpectedConditions.ElementToBeClickable(ActiveStatus));
                ad.Click(ActiveStatus, "ActiveStatus", node);
                ad.Click(SaveBtn, "SaveBtn", node);
                ad.Click(StatusUpdatePopUp, "StatusUpdatePopUp", node);
            }
        }

        public void SelectCase(string caseNumber)
        {
            var node = test.CreateNode("Customer is searched with Case Number");
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            ad.SendText(SearchField, "SearchField", caseNumber, node);
            ad.Click(SearchButtonDropDown, "SearchButtonDropDown", node);
            ad.Click(CaseOptionFromDropDown, "CaseOptionFromDropDown", node);
            w.Until(ExpectedConditions.ElementExists(SelectCustomerCase));
            ad.Click(SelectCustomerCase, "select_customer", node);
            ad.Click(OkButton, "OkButton", node);
            ad.SendText(SearchField, "SearchField", caseNumber, node);
            ad.Click(SearchButtonDropDown, "SearchButtonDropDown", node);
            ad.Click(CaseOptionFromDropDown, "CaseOptionFromDropDown", node);
            w.Until(ExpectedConditions.ElementExists(SelectCustomerCase));
            ad.Click(SelectCustomerCase, "select_customer", node);
        }

        public void SearchChangeOfOwnershipDevice(String deviceNum)
        {
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
            var node = test.CreateNode("Search Updated Elastic change of Onwnership Device");
            w.Until(ExpectedConditions.ElementExists(SearchButton));
            ad.SendText(SearchField, "Searching Device", deviceNum, node);
            ad.Click(SearchButton, "VIew", node);
            ad.WaitForBusyElementToGo();
            ad.TextVerificationContains(SearchResultText, "Verifying Search Result", "No result", node);
            ad.Click(CloseSearchResult, "Closing Search result", node);
        }
        public void ExistingCustomerEdit(String CustNo)
        {
            var node = test.CreateNode("Customer is searched with Existing Number");
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            ad.SendText(SearchField, "search_field", CustNo, node);
            ad.Click(SearchButton, "search_buttton", node);
            w.Until(ExpectedConditions.ElementToBeClickable(SelectCustomer));
            ad.Click(SelectCustomer, "select_customer", node);
            if (ad.IsElementPresent(PersonMakingContact) && ad.GetDropDownValueAtOption(PersonMakingContact, "personMakingContact", 0, node).Equals(""))
            {
                ad.DropDownByIndex(PersonMakingContact, "personMakingContact", 1, node);
            }
            else if (ad.IsElementPresent(ThirdPartyPersonMakingContact) && ad.GetDropDownValueAtOption(ThirdPartyPersonMakingContact, "ThirdPartyPersonMakingContact", 0, node).Equals(""))
            {
                ad.DropDownByIndex(ThirdPartyPersonMakingContact, "ThirdPartyPersonMakingContact", 1, node);
            }
            try
            {
                if (driver.FindElement(UpdateCustomerDetailsNo).Displayed)
                {
                    ad.Click(UpdateCustomerDetailsNo, "updateCustomerDetailsNo", node);
                }
            }
            catch (NoSuchElementException Ex)
            {
                Console.WriteLine("NoSuchElementException" + Ex.Message);
            }
            w.Until(ExpectedConditions.ElementToBeClickable(CustomerVerified));
            Assert.That(driver.FindElement(CustomerVerified).Enabled, Is.True);
            ad.Click(CustomerVerified, "select_customer", node);
            if (ad.ElementDisplayed(UpdateCustomerDetailsYes, node).ToString().Equals("True"))
            {
                ad.Click(UpdateCustomerDetailsYes, "CompleteCustomerDetailsYes", node);

            }
            else
            {
                ad.Click(EditSpecialistCustomerPage, "CompleteCustomerDetailsYes", node);
            }
            if (ad.ElementDisplayed(UpdatCustomerDetails, node).ToString().Equals("True"))
            {
                ad.Click(UpdatCustomerDetailsBUttonNo, "UpdatCustomerDetailsBUttonNo", node);
            }

        }
    }
}
