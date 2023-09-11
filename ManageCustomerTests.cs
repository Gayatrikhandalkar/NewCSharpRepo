using iTextSharp.text.pdf.parser;
using Microsoft.VisualBasic.FileIO;
using MongoDB.Bson.Serialization.Attributes;
using SeleniumTestProject.PageObject;
using SeleniumTestProject.PageObject.GetConnected;
using SeleniumTestProject.PageObject.ManageAccount;
using SeleniumTestProject.PageObject.ManageCustomer;
using SeleniumTestProject.Utilities;
using SeleniumTestProject.Utilities.DB.CustomQueries;

namespace SeleniumTestProject.Tests.SA
{
    public class ManageCustomerTests : BaseTestClass
    {
        private string customerNumber;

        /// <summary>
        ///  59428: Unlink linked customer
        /// Pre-Conditions: Use specialist customer that has a child customer(has general customer linked to it)   
        /// </summary>
        [Test]
        public void ManageCustomerUnLinkLinkedCustomerSouthAfrica()
        {
            TestDataStore.ReadTestData("South Africa");
            string specialistCustomerNumber = dbe.GetData(SubQuery.GetSpecialCustomerNumberMultichoiceTypeSouthAfrica, TestDataStore.ClarityLoginModel);
            string residentialCustomerNumber = dbe.GetData(SubQuery.GetResidentialCustomerWithActivePackageSouthAfrica, TestDataStore.ClarityLoginModel);
            test = Extent.CreateTest(TestContext.CurrentContext.Test.Name);
            ClarityLogin cl = new ClarityLogin(driver, test);
            cl.Login(TestDataStore.ClarityLoginModel);
            DashBoardOptionsPage doptions = new DashBoardOptionsPage(driver, test);
            DashboardAndReceiptPage darp = new DashboardAndReceiptPage(driver, test);
            darp.ExistingCustomerSearch(specialistCustomerNumber);
            doptions.SelectModule("Manage Employee Links");
            ManageEmployeeLinksPage melp = new ManageEmployeeLinksPage(driver, test);
            melp.LinkCustomer(residentialCustomerNumber);
            melp.UnlinkLinkdedCustomer(residentialCustomerNumber);
            doptions.SelectModule("Customer Interactions");
            CustomerInteractions ci=new CustomerInteractions(driver, test);
            ci.VerifyCustomerInteractions("General Services");
            ci.VerifyCustomerInteractions("Complete");
            ci.GetDetailsOfCIPrintInvoice();
            doptions.ClicklogoutOption();
        }

        /// <summary>
        ///  59427: Link Employee Customer To General Customer
        ///  Pre-Condition:Use a specialist Customer(Multichoice, Media 24/Naspers).
        /// </summary>
        [Test]
        public void ManageCustomerLinkEmployeeCustomerToGeneralCustomerSouthAfrica()
        {
            TestDataStore.ReadTestData("South Africa");
           string specialCustomerNumber = dbe.GetData(SubQuery.GetSpecialCustomerNumberMultichoiceTypeSouthAfrica, TestDataStore.ClarityLoginModel);
            string residentialCustomerNumber = dbe.GetData(SubQuery.GetResidentialCustomerWithActivePackageSouthAfrica, TestDataStore.ClarityLoginModel);
            test = Extent.CreateTest(TestContext.CurrentContext.Test.Name);
            ClarityLogin cl = new ClarityLogin(driver, test);
            cl.Login(TestDataStore.ClarityLoginModel);
            DashBoardOptionsPage doptions = new DashBoardOptionsPage(driver, test);
            DashboardAndReceiptPage darp = new DashboardAndReceiptPage(driver, test);
            darp.ExistingCustomerSearch(specialCustomerNumber);
            doptions.SelectModule("Manage Employee Links");
            ManageEmployeeLinksPage melp = new ManageEmployeeLinksPage(driver, test);
            melp.LinkCustomer(residentialCustomerNumber);
            doptions.SelectModule("Customer Interactions");
            CustomerInteractions ci = new CustomerInteractions(driver, test);
            ci.VerifyCustomerInteractions("General Services");
            ci.VerifyCustomerInteractions("Complete");
            ci.GetDetailsOfCIPrintInvoice();
            darp.ExistingCustomerSearch(residentialCustomerNumber);
            doptions.SelectModule("Customer Interactions");
            ci.VerifyCustomerInteractions("General Services");
            ci.VerifyCustomerInteractions("Complete");
            ci.GetDetailsOfCIPrintInvoice();
            doptions.ClicklogoutOption();
        }

        /// </summary>
        /// 59396 - Archived History for Migrated customers
        /// </summary>
        [Test]
        public void ManageCustomerArchiveHistoryOfMigratedCustomerSouthAfrica()
        {
            TestDataStore.ReadTestData("South Africa");
            test = Extent.CreateTest(TestContext.CurrentContext.Test.Name);
            ClarityLogin cl = new ClarityLogin(driver, test);
            cl.Login(TestDataStore.ClarityLoginModel);
            string migratedCustomer = dbe.GetData(SubQuery.GetMigratedSingleCustomerSA, TestDataStore.ClarityLoginModel);
            DashboardAndReceiptPage DARP = new DashboardAndReceiptPage(driver, test);
            DARP.ExistingCustomerSearch(migratedCustomer);
            DashBoardSubOptionPage DBSOP = new DashBoardSubOptionPage(driver, test);
            DBSOP.SelectSubOption("archivedHistory");
            ArchiveHistoryPage AHP = new ArchiveHistoryPage(driver, test);
            AHP.AddFromDateAndToDateForMigratedCustomer();
            AHP.CheckVisibilityOfHoistoryGrid();
            AHP.VerificationOfPresensOfFields();
            DashBoardOptionsPage DBOP = new DashBoardOptionsPage(driver, test);
            DBOP.ClicklogoutOption();
        }
        ///<summary>
        ///  59414:Validation of New ID Type "Refugee" - Specialist Customer
        ///  Pre-Condition:Use a specialist Customer
        /// </summary>
        [Test]
        public void ManageCustomerValidationOfNewIDTypeRefugeeSpeciaListCustomerSouthAfrica()
        {
            TestDataStore.ReadTestData("South Africa");
            string specialCustomerNumber = dbe.GetData(SubQuery.GetSpecialCustomerNumberMultichoiceTypeSouthAfrica, TestDataStore.ClarityLoginModel);
            test = Extent.CreateTest(TestContext.CurrentContext.Test.Name);
            ClarityLogin cl = new ClarityLogin(driver, test);
            cl.Login(TestDataStore.DccLoginSAModel);
            DashboardAndReceiptPage darp = new DashboardAndReceiptPage(driver, test);
            darp.ExistingCustomerSearch(specialCustomerNumber);
            DashBoardOptionsPage doptions = new DashBoardOptionsPage(driver, test);
            doptions.SelectModule("Edit Customer Details");
            EditCustomerDetailsPage ecip = new EditCustomerDetailsPage(driver, test);
            ecip.VerifyErrorMessageForInvalidUser();
            doptions.ClicklogoutOption();
            driver.Manage().Window.Minimize();
            cl.Login(TestDataStore.ClarityLoginModel);
            darp.ExistingCustomerSearch(specialCustomerNumber);
            doptions.SelectModule("Edit Customer Details");
            ecip.ValidateIdentificationForValidUser();
            doptions.ClicklogoutOption();
            Assert.Pass("passed");
        }
        ///<summary>
        ///  59415 :Banner - Customer Status Change from Active to Deceased with Pending Quote
        ///  Pre-Condition:Use a specialist Customer
        /// </summary>
        [Test]
        public void ManageCustomerBannerCustomerStatusChangeFromActiveToDeceasedWithPendingQuoteSouthAfrica()
        {
            TestDataStore.ReadTestData("South Africa");
            string residentialCustomerNumber = dbe.GetData(SubQuery.GetResidentialCustomerWithPendingQuoteSouthAfrica, TestDataStore.ClarityLoginModel);
            test = Extent.CreateTest(TestContext.CurrentContext.Test.Name);
            ClarityLogin cl = new ClarityLogin(driver, test);
            cl.Login(TestDataStore.ClarityLoginModel);
            DashboardAndReceiptPage darp = new DashboardAndReceiptPage(driver, test);
            darp.ExistingCustomerSearch(residentialCustomerNumber);
            DashBoardOptionsPage doptions = new DashBoardOptionsPage(driver, test);
            ManageCustomer mc = new ManageCustomer(driver, test);
            mc.ChangeCustomerStatusFromActiveToDeceased();
            doptions.SelectModule("Manage Account");
            ManageAccount ma = new ManageAccount(driver, test);
            ma.VerifyStatus();
            doptions.SelectModule("Quotes");
            QuotesPage qp = new QuotesPage(driver, test);
            qp.VerifyStatusOfQuote("Rejected");
            doptions.ClicklogoutOption();
            Assert.Pass("passed");
        }

        /// <summary>
        /// 59401 - Manage Customer: Adding customer documents
        /// </summary>
        [Test]
        public void ManageCustomerUploaddocumentManageCustomerSouthAfrica()
        {
            TestDataStore.ReadTestData("South Africa");
            test = Extent.CreateTest(TestContext.CurrentContext.Test.Name);
            ClarityLogin cl = new ClarityLogin(driver, test);
            cl.Login(TestDataStore.ClarityLoginModel);
            string ResidentialCustomerNumber = dbe.GetData(SubQuery.GetResidentialCustomerNumberQuerySingleCustomerSA, TestDataStore.ClarityLoginModel);
            DashboardAndReceiptPage DARP = new DashboardAndReceiptPage(driver, test);
            DARP.ExistingCustomerSearch(ResidentialCustomerNumber);
            DashBoardSubOptionPage DBSOP = new DashBoardSubOptionPage(driver, test);
            DBSOP.SelectSubOption("customerDocuments");
            CustomerDocumentPage CDP = new CustomerDocumentPage(driver, test);
            CDP.UploadDocument();
        }

        /// <summary>
        /// 56046 - Clarity --> Manage Customer --> History --> Export to Excel functionality (for all types of customers and schemas)
        /// </summary>
        /// <param name="customerType"></param>
        [TestCase("ResidentialCustomerNumber")]
        [TestCase("SpecialistCustomerNumber")]
        public void ManageCustomerExportToExcelFunctionalitySouthAfrica(string customerType)
        {            
            TestDataStore.ReadTestData("South Africa");
            switch (customerType)
            {
                case "ResidentialCustomerNumber":
                    this.customerNumber = dbe.GetData(SubQuery.GetResidentialCustomerNumberQuerySingleCustomerSA, TestDataStore.ClarityLoginModel);
                    break;
                case "SpecialistCustomerNumber":
                    this.customerNumber = dbe.GetData(SubQuery.GetSpecialistCustomerNumberQuerySingleCustomer, TestDataStore.ClarityLoginModel);
                    break;
            }            
            string expectedFilePath = TestDataReader.DownloadFilePath() + "\\Customer_History_Report_" + customerNumber + "_" + CLDate.GenerateTodayDateWithFormat("dd-MM-yyyy") + ".xls";
            TestContext.Progress.WriteLine(expectedFilePath);
            test = Extent.CreateTest(TestContext.CurrentContext.Test.Name);
            ClarityLogin cl = new(driver, test);
            cl.Login(TestDataStore.ClarityLoginModel);
            DashboardAndReceiptPage DARP = new(driver, test);
            DARP.ExistingCustomerSearch(customerNumber);
            DashBoardSubOptionPage DBSOP = new(driver, test);
            DBSOP.SelectSubOption("history");
            History HP = new(driver, test);
            HP.VerificationOfPresensOfFields();
            HP.SearchOnlyWithEventID();
            HP.SearchOnlyWithDates();
            HP.SearchOnlyWithUserName();
            HP.ExportToExcel(expectedFilePath.Trim());
            TestDataReader.DeleteFile(expectedFilePath);
        }

    }
}
