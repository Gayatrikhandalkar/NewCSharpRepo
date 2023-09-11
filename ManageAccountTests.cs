using SeleniumTestProject.PageObject.ManageCustomer;
using SeleniumTestProject.PageObject;
using SeleniumTestProject.Utilities;
using SeleniumTestProject.PageObject.MakePayment;
using SeleniumTestProject.PageObject.ManageAccount;
using SeleniumTestProject.PageObject.ManageViewing;
using SeleniumTestProject.PageObject.GetConnected;
using SeleniumTestProject.PageObject.ManagePaymentsAndTransactions;
using SeleniumTestProject.Utilities.DB.CustomQueries;
using Microsoft.Web.Administration;

namespace SeleniumTestProject.Tests.SA
{
    public class ManageAccountTests : BaseTestClass
    {
        /// <summary>
        /// 58903 - Manage Account : Change billing type from "Add-to-Bill" to "Pay-in-advance" on customer with BO-Residential
        /// </summary>
        [Test]
        public void ManageAccountChangeBillingTypeFromAddToBillToPayInAdvanceOnCustomerWithBoResidentialSouthAfrica()
        {
            TestDataStore.ReadTestData("South Africa");
            test = Extent.CreateTest(TestContext.CurrentContext.Test.Name);
            ClarityLogin cl = new ClarityLogin(driver, test);
            cl.Login(TestDataStore.BillingCollectionSupervisorModel);
            string ResidentialCustomerNumber = dbe.GetData(SubQuery.GetResidentialDebitOrderCustomerSA, TestDataStore.ClarityLoginModel);
            DashboardAndReceiptPage DARP = new DashboardAndReceiptPage(driver, test);
            DARP.ExistingCustomerSearch(ResidentialCustomerNumber);
            DashBoardSubOptionPage DBSOP = new DashBoardSubOptionPage(driver, test);
            DBSOP.SelectSubOption("manageAccount");
            ManageAccount ma = new ManageAccount(driver, test);
            string currentBillingType = ma.CurrentBillingType();
            DBSOP.SelectSubOption("editPaymentDetailsMenuLink");            
            EditPaymentDetailsPage epdp = new EditPaymentDetailsPage(driver, test);
            epdp.ChangeBillingTypeToPayInAdvance(currentBillingType);
            DBSOP.SelectSubOption("manageCustomer");            
            DBSOP.SelectSubOption("manageAccount");            
            ma.VerifyBillingTypeAsPayInAdvance();
        }


        /// <summary>
        /// 58904 - Manage Account : Change billing type from "pay-in-advance" to "Add-to-Bill" on customer with BO-Specialist
        /// </summary>
        [Test]
        public void ManageAccountChangeBillingTypeFromPayInAdvanceToAddToBillOnCustomerWithBoSpecialistSouthAfrica()
        {
            TestDataStore.ReadTestData("South Africa");
            test = Extent.CreateTest(TestContext.CurrentContext.Test.Name);
            ClarityLogin cl = new ClarityLogin(driver, test);
            cl.Login(TestDataStore.BillingCollectionSupervisorModel);
            string ResidentialCustomerNumber = dbe.GetData(SubQuery.GetResidentialDebitOrderCustomerSA, TestDataStore.ClarityLoginModel);
            DashboardAndReceiptPage DARP = new DashboardAndReceiptPage(driver, test);
            DARP.ExistingCustomerSearch(ResidentialCustomerNumber);
            DashBoardSubOptionPage DBSOP = new DashBoardSubOptionPage(driver, test);
            DBSOP.SelectSubOption("manageAccount");
            EditPaymentDetailsPage epdp = new EditPaymentDetailsPage(driver, test);
            ManageAccount ma = new ManageAccount(driver, test);
            string currentBillingTypeBeforeChange = ma.CurrentBillingType();
            if (currentBillingTypeBeforeChange.Equals("Pay in Advance"))
            {
                DBSOP.SelectSubOption("editPaymentDetailsMenuLink");
                epdp.ChangeBillingTypeToAddToBill(currentBillingTypeBeforeChange);
                ma.VerifyBillingTypeAsAddToBill();
            }
            else
            {
                DBSOP.SelectSubOption("editPaymentDetailsMenuLink");                
                epdp.ChangeBillingTypeToPayInAdvance(currentBillingTypeBeforeChange);
                DBSOP.SelectSubOption("manageCustomer");
                DBSOP.SelectSubOption("manageAccount");
                ma.VerifyBillingTypeAsPayInAdvance();
                string currentBillingTypeAfterChange = ma.CurrentBillingType();
                DBSOP.SelectSubOption("editPaymentDetailsMenuLink");                
                epdp.ChangeBillingTypeToAddToBill(currentBillingTypeAfterChange);
                DBSOP.SelectSubOption("manageCustomer");
                DBSOP.SelectSubOption("manageAccount");
                ma.VerifyBillingTypeAsAddToBill();

            }
            
        }

    }
}
