using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumTestProject.Models;
using SeleniumTestProject.Utilities;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestProject.PageObject
{
    internal class CreateSpecialistCustomer
    {
		readonly ActionDriver ad;
        public ExtentTest test;
        readonly IWebDriver driver;
        public string emailID;
        public string mobileNo;
        public string identificationNo;
        public string CustomerNumber;

        public By GetConnected = By.XPath("//*[contains(@src,'Content/Images/Home/getConnected.svg')]");
        public By CustomerType = By.Id("customerDataModel-custType");
        public By ResidenceType = By.Id("customerDataModel-locationIndicator");
        public By Title = By.Id("customerDataModel-title-1");
        public By FirstName = By.Id("customerDataModel-firstName-2-3");
        public By LastName = By.Id("customerDataModel-lastName-2-3");
        public By Identification = By.Id("customerDataModel-identityDetailType-1");
        public By IdentificationNo = By.Id("customerDataModel-idValue-2-3");
        public By Position = By.Id("customerDataModel-position-1");
        public By Sponsor = By.Id("customerDataModel-sponsor");
        public By Language = By.Id("customerDataModel-language-1");
        public By PhoneNumber = By.Id("templateData-keywords-phone-contactValue-2");
        public By Email = By.Id("templateData-keywords-email-contactValue-2");
        public By Province = By.Id("templateData-keywords-view-parentView-address-province");
        public By City = By.Id("templateData-keywords-view-parentView-address-city");
        public By Suburb = By.Id("templateData-keywords-view-parentView-address-suburb");
        public By UnitNumber = By.Id("templateData-keywords-view-parentView-address-unit-1");
        public By BuildingName = By.Id("templateData-keywords-view-parentView-address-building-1");
        public By StreetNumber = By.Id("templateData-keywords-view-parentView-address-streetNumber-1");
        public By StreetName = By.Id("streetName-1");
        public By MethodofPayment = By.Id("templateData-keywords-view-parentView-paymentDetails-debitOrderDay");
        public By HouseholdMemberandAuthorityDelegationInformation = By.Id("addHouseHoldInfoVisible-action");
        public By HouseholdFirstName = By.Id("householdMemberAndAuthority-firstNameHouseholdMemberAndAuthority-1");
        public By HouseholdLastName = By.Id("householdMemberAndAuthority-lastNameHouseholdMemberAndAuthority-1");
        public By HouseholdRelation = By.Id("householdMemberAndAuthority-relation");
        public By PrimaryAddress = By.Id("addAddress-action");
        public By HouseholdAddress = By.Id("addHouseholdMemberAndAuthority-action");
        public By Savecustomer= By.Id("createSpecialistCustomer-action");
        public By GetconnectionLink = By.XPath("/html/body/div[3]/div/div/div[2]/div[4]/div/div[1]/div/h3");
        public By modulesPopup = By.Id("modal-ok-action");
        public By settingsBtn = By.XPath("//*[@class='settings-btn']");
        public By logoutBtn = By.XPath("//*[@class='settings-nav-logout settings-nav']");
        public By ok = By.XPath("//button[@id='modal-ok-action']");
        public By Bank = By.Id("templateData-keywords-view-parentView-paymentDetails-bank");
        public By Accounttype = By.Id("templateData-keywords-view-parentView-paymentDetails-accountType");
        public By AccountNo = By.Id("templateData-keywords-view-parentView-paymentDetails-accountNo-1");
        public By BranchName = By.Id("templateData-keywords-view-parentView-paymentDetails-branchName");
        public By Homebutton = By.Id("homebutton");
        public By BusinessUnitRadioBtn;
        public By CreatedCustomerNumber = By.XPath("//span[@id='customerNumberData']");
        public By RegisteredForVATYesCheckBox = By.Id("customerDataModel-isRegisteredForVAT-1");
        public By RegisteredForVATNoCheckBox = By.Id("customerDataModel-isRegisteredForVAT-0");
        public By RegisteredForVATtextBox = By.Id("customerDataModel-vatNumber-2-3");
        public By EmployeeNumberText = By.Id("customerInformationModel-personalDetails-employeeNumber-1");

        public CreateSpecialistCustomer(IWebDriver driver, ExtentTest test)
        {
            ad = new ActionDriver(driver);
            this.test = test;
            this.driver = driver;
        }

        public void CreateSpecialistCustomers(CreateSpecialistCustomerModel createSpecialistCustomerModel)
        {
            driver.Navigate().Refresh();
            var node = test.CreateNode("CreateSpecialistCustomer");

            DashBoardSubOptionPage dsuboptions = new DashBoardSubOptionPage(driver, test);
            dsuboptions.SelectSubOption("createSpecialistCustomer");
            ad.WaitForBusyElementToGo();
            ad.DropDownByText(CustomerType, "CustomerType",createSpecialistCustomerModel.CustomerType,node);
            ad.DropDownByText(ResidenceType, "ResidenceType", createSpecialistCustomerModel.ResidenceType,node);
            ad.DropDownByText(Title, "Title", "Mr", node);
            ad.SendText(FirstName, "FirstName", createSpecialistCustomerModel.FirstName, node);
            ad.SendText(LastName, "LastName", createSpecialistCustomerModel.LastName, node);
            ad.DropDownByText(Identification, "Identification", "National ID", node);
            ad.SendText(IdentificationNo, "IdentificationNo", createSpecialistCustomerModel.IdentificationNo, node);
            ad.DropDownByText(Language, "Language", "English", node);
            ad.SendText(PhoneNumber, "PhoneNumber", createSpecialistCustomerModel.PhoneNumber, node);
            ad.SendText(Email, "Email", createSpecialistCustomerModel.EmailAddress, node);
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            w.Until(ExpectedConditions.ElementToBeClickable(Province));
            ad.DropDownByText(Province, "Province", "BENGO", node);
            ad.DropDownByText(City, "City", "Ambriz", node);
            ad.DropDownByText(Suburb, "Suburb", "Ambriz", node);
            ad.SendText(UnitNumber, "UnitNumber", "23", node);
            ad.SendText(BuildingName, "BuildingName", "ITcity", node);
            ad.SendText(StreetNumber, "StreetNumber", "48", node);
            ad.SendText(StreetName, "StreetName", "TesterRoad", node);
            ad.Click(PrimaryAddress, "PrimaryAddress",node);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            ad.DropDownByText(MethodofPayment, "MethodofPayment", "Day 13", node);
            ad.Click(HouseholdMemberandAuthorityDelegationInformation, "HouseholdMemberandAuthorityDelegationInformation", node);
            ad.SendText(HouseholdFirstName, "HouseholdFirstName", "ram", node);
            ad.SendText(HouseholdLastName, "HouseholdLastName", "say", node);
            ad.DropDownByText(HouseholdRelation, "HouseholdRelation", "Father", node);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            ad.Click(HouseholdAddress, "HouseholdAddress", node);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            ad.Click(Savecustomer, "HouseholdAddress", node);
            ad.WaitForBusyElementToGo();
        }


        public void CreateSpecialistCustomerAngolaDuplicaterecords()
        {
            TestDataStore.ReadTestData("Angola");
			_ = new CreateSpecialistCustomerModel();
			CreateSpecialistCustomer ca = new(driver, test);
			CreateSpecialistCustomerModel duplicateCreateSpecialistModel = ca.EnterSameDetails(TestDataStore.CreateSpecialistCustomerModel);
			for (int i = 0; i < 2; i++)
                {
                    ca.CreateSpecialistCustomers(duplicateCreateSpecialistModel);
                }
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
                ca.Logout();
        }

        public string CreateSpecialistCustomerNigeria(ISpecialistTypes specialistTypes)
        {
            driver.Navigate().Refresh();
            var node = test.CreateNode("CreateSpecialistCustomer");
            Random random = new();
            this.emailID = random.Next(100, 5000).ToString() + specialistTypes.EmailAddress;
            this.identificationNo = specialistTypes.IdentificationNo + random.Next(100, 999).ToString();
            this.mobileNo = specialistTypes.PhoneNumber + random.Next(1000, 9999).ToString();
            DashBoardSubOptionPage dsuboptions = new DashBoardSubOptionPage(driver, test);
            dsuboptions.SelectSubOption("createSpecialistCustomer");
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            w.Until(ExpectedConditions.ElementExists(CustomerType));
            BusinessUnitRadioBtn = By.XPath("//div[@id='customerDataModel-viewingPlatform']//input[contains(@data-title,'" + specialistTypes.BusinessUnit + "')]");
            ad.Click(BusinessUnitRadioBtn, "Select Business Unit Radio Button", node);
            ad.DropDownByText(CustomerType, "Customer_Type", specialistTypes.CustomerType, node);
            ad.DropDownByText(ResidenceType, "Residence_Type", specialistTypes.ResidenceType, node);
            ad.DropDownByText(Title, "Title", "Mr", node);
            ad.SendText(FirstName, "FirstName", specialistTypes.FirstName, node);
            ad.SendText(LastName, "LastName", specialistTypes.LastName, node);
            ad.DropDownByText(Identification, "Identification", "National ID", node);
            ad.SendText(IdentificationNo, "IdentificationNo", identificationNo, node);
            ad.DropDownByText(Language, "Language", "English", node);
            ad.SendText(PhoneNumber, "PhoneNumber", mobileNo, node);
            ad.SendText(Email, "Email", emailID, node);
            WebDriverWait w1 = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            w1.Until(ExpectedConditions.ElementToBeClickable(Province));
            ad.DropDownByText(Province, "Province", "Central", node);
            ad.DropDownByText(City, "City", "ABUJA", node);
            ad.DropDownByText(Suburb, "Suburb", "ABAJI", node);
            ad.SendText(UnitNumber, "UnitNumber", "23", node);
            ad.SendText(BuildingName, "BuildingName", "ITcity", node);
            ad.SendText(StreetNumber, "StreetNumber", "48", node);
            ad.SendText(StreetName, "StreetName", "TesterRoad", node);
            ad.Click(PrimaryAddress, "PrimaryAddress", node);
            ad.DropDownByText(MethodofPayment, "Method_of_Payment", "Day 13", node);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            ad.Click(Savecustomer, "HouseholdAddress", node);
            ad.WaitForBusyElementToGo();
            CustomerNumber = driver.FindElement(CreatedCustomerNumber).Text;
            return CustomerNumber;
        }

        public void CreateSpecialistCustomerNigeriaDuplicaterecords()
        {
            TestDataStore.ReadTestData("Nigeria");
			_ = new CreateSpecialistCustomerModel();
			CreateSpecialistCustomer ca = new CreateSpecialistCustomer(driver, test);
			CreateSpecialistCustomerModel duplicateCreateSpecialistModel = ca.EnterSameDetails(TestDataStore.CreateSpecialistCustomerModel);
			for (int i = 0; i < 2; i++)
            {
                ca.CreateSpecialistCustomerNigeria(duplicateCreateSpecialistModel);
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            ca.Logout();
        }

        public string CreateSpecialistCustomerKenya(ISpecialistTypes specialistTypes)
        {
            driver.Navigate().Refresh();
            var node = test.CreateNode("CreateSpecialistCustomer");
            Random random = new();
            this.emailID = random.Next(100, 5000).ToString() + specialistTypes.EmailAddress;
            this.identificationNo = specialistTypes.IdentificationNo + random.Next(100, 999).ToString();
            this.mobileNo = specialistTypes.PhoneNumber + random.Next(1000, 9999).ToString();
            DashBoardSubOptionPage dsuboptions = new DashBoardSubOptionPage(driver, test);
            dsuboptions.SelectSubOption("createSpecialistCustomer");
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(80));
            w.Until(ExpectedConditions.ElementExists(CustomerType));
            BusinessUnitRadioBtn = By.XPath("//div[@id='customerDataModel-viewingPlatform']//input[contains(@data-title,'" + specialistTypes.BusinessUnit + "')]");
            ad.Click(BusinessUnitRadioBtn, "Select Business Unit Radio Button", node);
            ad.DropDownByText(CustomerType, "CustomerType", specialistTypes.CustomerType, node);
            ad.DropDownByText(ResidenceType, "ResidenceType", specialistTypes.ResidenceType, node);
            ad.DropDownByText(Title, "Title", "Mr", node);
            ad.SendText(FirstName, "FirstName", specialistTypes.FirstName, node);
            ad.SendText(LastName, "LastName", specialistTypes.LastName, node);
            ad.DropDownByText(Identification, "Identification", "Social Identity Number", node);
            ad.SendText(IdentificationNo, "Identification_No", identificationNo, node);
            ad.DropDownByText(Language, "Language", "English", node);
            ad.SendText(PhoneNumber, "PhoneNumber", mobileNo, node);
            ad.SendText(Email, "Email", emailID, node);
            ad.DropDownByText(Province, "Province", "Baringo", node);
            ad.DropDownByText(City, "City", "BARINGO", node);
            ad.DropDownByText(Suburb, "Suburb", "BARINGO", node);
            ad.SendText(UnitNumber, "UnitNumber", "23", node);
            ad.SendText(BuildingName, "BuildingName", "ITcity", node);
            ad.SendText(StreetNumber, "StreetNumber", "48", node);
            ad.SendText(StreetName, "StreetName", "TesterRoad", node);
            ad.Click(PrimaryAddress, "PrimaryAddress", node);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            ad.DropDownByText(Bank, "Bank", "Absa Bank Kenya Plc", node);
            ad.DropDownByText(Accounttype, "Bank", "Savings", node);
            ad.SendText(AccountNo, "UnitNumber", "2354094685804", node);
            ad.DropDownByText(BranchName, "Bank", "Abc Premier Life Centre", node);
            ad.DropDownByText(MethodofPayment, "MethodofPayment", "Day 13", node);
            ad.Click(HouseholdMemberandAuthorityDelegationInformation, "HouseholdMemberandAuthorityDelegationInformation", node);
            ad.SendText(HouseholdFirstName, "HouseholdFirstName", "ram", node);
            ad.SendText(HouseholdLastName, "HouseholdLastName", "say", node);
            ad.DropDownByText(HouseholdRelation, "HouseholdRelation", "Father", node);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            ad.Click(HouseholdAddress, "HouseholdAddress", node);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            ad.Click(Savecustomer, "HouseholdAddress", node);
            ad.WaitForBusyElementToGo();
            CustomerNumber = driver.FindElement(CreatedCustomerNumber).Text;
            return CustomerNumber;
        }

        public void CreateSpecialistCustomerKenyaDuplicaterecords()
        {
            TestDataStore.ReadTestData("Kenya");
			_ = new CreateSpecialistCustomerModel();
			CreateSpecialistCustomer ca = new CreateSpecialistCustomer(driver, test);
			CreateSpecialistCustomerModel duplicateCreateSpecialistModel = ca.EnterSameDetails(TestDataStore.CreateSpecialistCustomerModel);
			for (int i = 0; i < 2; i++)
            {
                ca.CreateSpecialistCustomerKenya(duplicateCreateSpecialistModel);
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            ca.Logout();
        }

        public void Logout()
        {
            var node = test.CreateNode("Logout");
            Console.WriteLine("Alert Present Function Called " + ad.IsAlertPresent(node));
            if (ad.ElementDisplayed(ok, node))
            {
                ad.Click(ok, "ok button",node);
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            ad.Click(settingsBtn, "Settingbutton", node);
            ad.Click(logoutBtn, "logout", node);
        }

        public CreateSpecialistCustomerModel EnterSameDetails(CreateSpecialistCustomerModel createSpecialistCustomerModel)
        {
            Random random = new Random();
            this.emailID = random.Next(100, 5000).ToString() + DataGenerator.KeyWordManager("**GENERATEEMAIL");
            this.mobileNo = random.Next(10, 500).ToString() + createSpecialistCustomerModel.PhoneNumber;
            this.identificationNo = DataGenerator.KeyWordManager("**GENERATESPECIALCUSTOMERID");
			createSpecialistCustomerModel.PhoneNumber = mobileNo;
			createSpecialistCustomerModel.IdentificationNo = identificationNo;
			createSpecialistCustomerModel.EmailAddress = emailID;
            createSpecialistCustomerModel.FirstName = DataGenerator.KeyWordManager("**GENERATEFIRSTNAME");
            createSpecialistCustomerModel.LastName = DataGenerator.KeyWordManager("**GENERATEFIRSTNAME");
            return createSpecialistCustomerModel;
        }

        public void SearchVatRegisteredField()
        {
             var node = test.CreateNode("Verifying Vat Field");
             WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(80));
             w.Until(ExpectedConditions.ElementExists(RegisteredForVATYesCheckBox));
             w.Until(ExpectedConditions.ElementExists(RegisteredForVATNoCheckBox));
             ad.ScrollTo(RegisteredForVATNoCheckBox, node);
             if (ad.IsElementPresent(RegisteredForVATYesCheckBox) && ad.IsElementPresent(RegisteredForVATNoCheckBox))
             {
                 TestContext.WriteLine("Vat Registered Available");
             }
        }
        public void CreateSpecialistCustomerWithAlphaNumericVatKenya(CreateSpecialistCustomerModel createSpecialistCustomerModel, string identityNumber, string alphaNumericVatNumber, string mobileNumber, string emailId)
        {
            driver.Navigate().Refresh();
            var node = test.CreateNode("CreateSpecialistCustomer");
            DashBoardSubOptionPage dsuboptions = new DashBoardSubOptionPage(driver, test);
            dsuboptions.SelectSubOption("createSpecialistCustomer");
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(80));
            w.Until(ExpectedConditions.ElementExists(CustomerType));
            ad.DropDownByText(CustomerType, "CustomerType", createSpecialistCustomerModel.CustomerType, node);
            ad.DropDownByText(ResidenceType, "ResidenceType", createSpecialistCustomerModel.ResidenceType, node);
            ad.DropDownByText(Title, "Title", "Mr", node);
            ad.SendText(FirstName, "FirstName", createSpecialistCustomerModel.FirstName, node);
            ad.SendText(LastName, "LastName", createSpecialistCustomerModel.LastName, node);
            w.Until(ExpectedConditions.ElementExists(Identification));
            ad.DropDownByText(Identification, "Identification", "Social Identity Number", node);
            ad.SendText(IdentificationNo, "Identification_No", identityNumber, node);
            ad.ScrollTo(IdentificationNo, node);
            ad.DropDownByText(Language, "Language", "English", node);
            w.Until(ExpectedConditions.ElementExists(RegisteredForVATYesCheckBox));
            ad.Click(RegisteredForVATYesCheckBox, "Vat Register", node);
            w.Until(ExpectedConditions.ElementIsVisible(RegisteredForVATtextBox));
            ad.SendText(RegisteredForVATtextBox, "Vat Text", alphaNumericVatNumber, node);
            ad.SendText(PhoneNumber, "PhoneNumber", "715" + mobileNumber, node);
            ad.SendText(Email, "Email", emailId + "@gmail.com", node);
            ad.DropDownByText(Province, "Province", "Baringo", node);
            ad.DropDownByText(City, "City", "BARINGO", node);
            ad.DropDownByText(Suburb, "Suburb", "BARINGO", node);
            ad.SendText(UnitNumber, "UnitNumber", "23", node);
            ad.SendText(BuildingName, "BuildingName", "ITcity", node);
            ad.SendText(StreetNumber, "StreetNumber", "48", node);
            ad.SendText(StreetName, "StreetName", "TesterRoad", node);
            ad.Click(PrimaryAddress, "PrimaryAddress", node);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            ad.DropDownByText(Bank, "Bank", "Absa Bank Kenya Plc", node);
            ad.DropDownByText(Accounttype, "Bank", "Savings", node);
            ad.SendText(AccountNo, "UnitNumber", "2354094685804", node);
            ad.DropDownByText(BranchName, "Bank", "Abc Premier Life Centre", node);
            ad.DropDownByText(MethodofPayment, "MethodofPayment", "Day 13", node);
            ad.Click(HouseholdMemberandAuthorityDelegationInformation, "HouseholdMemberandAuthorityDelegationInformation", node);
            ad.SendText(HouseholdFirstName, "HouseholdFirstName", "ram", node);
            ad.SendText(HouseholdLastName, "HouseholdLastName", "say", node);
            ad.DropDownByText(HouseholdRelation, "HouseholdRelation", "Father", node);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            ad.Click(HouseholdAddress, "HouseholdAddress", node);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            ad.Click(Savecustomer, "HouseholdAddress", node);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

        }
      
    }
}


    

