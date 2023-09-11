using SeleniumTestProject.PageObject.GetConnected;
using SeleniumTestProject.PageObject;
using SeleniumTestProject.Utilities;

namespace SeleniumTestProject.Tests.SA
{
    public class GetConnectedTests : BaseTestClass
    {
        [Test]
        public void GetConnectedCreateQuoteForHardwareWithAPrincipalAndAddonProductSouthAfrica()
        {
            try
            {
                TestDataStore.ReadTestData("South Africa");
                test = Extent.CreateTest(TestContext.CurrentContext.Test.Name);
                ClarityLogin cl = new ClarityLogin(driver, test);
                cl.Login(TestDataStore.ClarityLoginModel);
                DashBoardOptionsPage doptions = new DashBoardOptionsPage(driver, test);
                doptions.SelectOption("GetConnected");
                DashBoardSubOptionPage dsuboptions = new DashBoardSubOptionPage(driver, test);
                dsuboptions.SelectSubOption("createQuote");
                CreateQuotePage cqp = new CreateQuotePage(driver, test);
                cqp.CreateQuote(TestDataStore.CreateQuoteModelWithAddOn);
                Assert.Pass("GetConnectedSouthAfricaCreateQuoteWithAddon Test Passed");
            }
            catch (Exception ex)
            {
                // Log the error message or stack trace
                test.Fail("Test Failed with Exception: " + ex.Message);
                //throw ex; // rethrow the exception to mark the test as failed
                throw;
            }
        }
        [Test]
        public void GetConnectedVerifyTheAcceptQuoteIsDisabledOnACompletedSouthAfrica()
        {
            TestDataStore.ReadTestData("South Africa");
            test = Extent.CreateTest(TestContext.CurrentContext.Test.Name);
            ClarityLogin cl = new ClarityLogin(driver, test);
            cl.Login(TestDataStore.ClarityLoginModel);
            DashBoardOptionsPage doptions = new DashBoardOptionsPage(driver, test);
            doptions.SelectOption("GetConnected");
            DashboardAndReceiptPage darp = new DashboardAndReceiptPage(driver, test);
            darp.QuoteSearch();
            darp.SelectQuoteFromPopup();
            darp.VerifyQuoteDetails();
        }

        /// <summary>
        /// 55141- Create Residential Customer with Identification Type Social Identity No. and  Validate data in ICC and CRM
        /// </summary>
        [Test]
        public void GetConnectedCreateResidentialCustomerWithIdentificationTypeAsSocialIdentityNoSA()
        {
            TestDataStore.ReadTestData("South Africa");
            test = Extent.CreateTest(TestContext.CurrentContext.Test.Name);
            Random rnd = new();
            TestDataStore.CreateResidentialCustomerModelSA.CstIdNumber = Generator.SaIdGenerator(CLDate.PastDateGeneration(-rnd.Next(10000, 20000), "yyMMdd"), true, true);
            ClarityLogin cl = new ClarityLogin(driver, test);
            cl.Login(TestDataStore.ClarityLoginModel);
            DashBoardOptionsPage doptions = new DashBoardOptionsPage(driver, test);
            doptions.SelectOption("GetConnected");
            DashBoardSubOptionPage dsuboptions = new DashBoardSubOptionPage(driver, test);
            dsuboptions.SelectSubOption("createResidentialCustomer");
            CreateResidentialCustomer crc = new CreateResidentialCustomer(driver, test);
            crc.CreateResidentialCustomerWithCustIDNumberSouthAfrica(TestDataStore.CreateResidentialCustomerModelSA);
            doptions.ClicklogoutOption();
            Assert.Pass("Passed");

        }
    }
}
