using SeleniumTestProject.PageObject.GetConnected;
using SeleniumTestProject.PageObject;
using SeleniumTestProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports.Model;
using SeleniumTestProject.Utilities.DB.CustomQueries;
using SeleniumTestProject.PageObject.ManageViewing;
using SeleniumTestProject.PageObject.MakePayment;
using SeleniumTestProject.PageObject.ManageAccount;
using SeleniumTestProject.PageObject.ManageCustomer;
using AventStack.ExtentReports.Gherkin.Model;

namespace SeleniumTestProject.Tests.SA
{
    public class ManageViewingTests : BaseTestClass
    {
        /// <summary>
        /// TC: 60480 Manage Viewing : Change Charge period on Device information page from "Annually to Monthly" South Africa
        /// </summary>
        [Test]
        public void ManageViewingViewChangeChargePeriodOnDeviceInformationPageFromAnnuallyToMonthlySouthAfrica()
        {
            TestDataStore.ReadTestData("South Africa");
            test = Extent.CreateTest(TestContext.CurrentContext.Test.Name);
            ClarityLogin cl = new ClarityLogin(driver, test);
            cl.Login(TestDataStore.ClarityLoginModel);
            string ResidentialCustomerNumber = dbe.GetData(SubQuery.GetResidentialCustomerWithAnnuallyCpntractPeriod, TestDataStore.ClarityLoginModel);
            DashboardAndReceiptPage darp = new DashboardAndReceiptPage(driver, test);
            darp.ExistingCustomerSearch(ResidentialCustomerNumber);
            DashBoardOptionsPage doptions = new DashBoardOptionsPage(driver, test);
            doptions.SelectModule("Manage Viewing");
            DeviceInformationAndCsiLogs dicsil = new DeviceInformationAndCsiLogs(driver, test);
            dicsil.ChangeChargeFromAnnuallyToMonthly();
            doptions.ClicklogoutOption();
        }
        ///<summary>
        /// Test Case 60520: S2-Schedule Reconnect with the schedule end date for Add-to-bill on the suspended HH viewing-Residential - Timeshifting
        ///</summary>

        [Test]
        public void ManageViewingS2ScheduleReconnectWithTheScheduleEndDateForAddTobillOnTheSuspendedHHViewingResidentialTimeShiftingSouthAfrica()
        {
            TestDataStore.ReadTestData("South Africa");
            TestDataStore.SuspendedHolidayHomeViewing.Country = TestDataStore.ClarityLoginModel.Country;
            test = Extent.CreateTest(TestContext.CurrentContext.Test.Name);
            ClarityLogin cl = new ClarityLogin(driver, test);
            cl.Login(TestDataStore.ClarityLoginModel);
            string customerNumber = dbe.GetData(SubQuery.GetResidentialCustomerWithSuspendedHolidayHome, TestDataStore.ClarityLoginModel);
            DashboardAndReceiptPage darp = new DashboardAndReceiptPage(driver, test);
            darp.ExistingCustomerSearch(customerNumber);    //11713297 //132796480 //28632991
            DashBoardOptionsPage doptions = new DashBoardOptionsPage(driver, test);
            doptions.SelectModule("Manage Viewing");
            ManageViewingOptionPage mvop = new ManageViewingOptionPage(driver, test);
            TestDataStore.SuspendedHolidayHomeViewing.DecoderNumber = mvop.GrabSmartCardNumberforProduct(TestDataStore.SuspendedHolidayHomeViewing);
            doptions.SelectModule("Holiday Homes");
            HolidayHomesPage hhp = new HolidayHomesPage(driver, test);
            hhp.ScheduleReconnectionWithScheduledEndDateForAddToBill(TestDataStore.SuspendedHolidayHomeViewing);
            doptions.SelectModule("Manage Viewing");
            doptions.SelectModule("Scheduled Changes");
            ScheduledChangesPage sc = new ScheduledChangesPage(driver, test);
            sc.ScheduledChangesValidation("reconnect");
            doptions.SelectOption("ManageCustomer");
            DashBoardSubOptionPage dbsop = new DashBoardSubOptionPage(driver, test);
            dbsop.SelectSubOption("history");
            History h = new History(driver, test);
            h.VerifyHistoryEventID("100171");
            doptions.SelectOption("ManageCustomer");
            doptions.SelectModule("Customer Interactions");
            CustomerInteractions ci = new CustomerInteractions(driver, test);
            ci.VerifyCustomerInteractions("Schedule Reconnect with the schedule end date for Add-to-bill", "Scheduled Reconnect");
            doptions.ClicklogoutOption();
            Assert.Pass("S2-Schedule Reconnect with the schedule end date for Add-to-bill on the suspended HH viewing-Residential - Timeshifting has been completed successfully");
        }

        ///<summary>
        /// Test Case 60486: ActivateDCC - DCC with extraview customer
        ///</summary>

        [Test]
        public void ManageViewingActivateDccWithXtraViewCustomerSouthAfrica()
        {
            TestDataStore.ReadTestData("South Africa");
            TestDataStore.ActivateDccWithXtraView.Country = TestDataStore.ClarityLoginModel.Country;
            test = Extent.CreateTest(TestContext.CurrentContext.Test.Name);
            ClarityLogin cl = new ClarityLogin(driver, test);
            cl.Login(TestDataStore.ClarityLoginModel);
            string customerNumber = dbe.GetData(SubQuery.GetResidentialCustomerWithActiveXtraView, TestDataStore.ClarityLoginModel);
            DashboardAndReceiptPage darp = new DashboardAndReceiptPage(driver, test);
            darp.ExistingCustomerSearch(customerNumber);
            DashBoardOptionsPage doptions = new DashBoardOptionsPage(driver, test);
            doptions.SelectModule("Manage Viewing");
            ManageViewingOptionPage mvop = new ManageViewingOptionPage(driver, test);
            TestDataStore.SuspendedHolidayHomeViewing.DecoderNumber = mvop.GrabSmartCardNumberforProduct(TestDataStore.ActivateDccWithXtraView);
            doptions.SelectModule("XtraView");
            XtraviewPage xvp = new XtraviewPage(driver, test);
            xvp.InsuranceForDevices(TestDataStore.ActivateDccWithXtraView);
            doptions.SelectModule("Manage Viewing");
            doptions.SelectModule("Make Payments");
            doptions.SelectModule("Customer Payment");
            CustomerPayment cp = new CustomerPayment(driver, test);
            cp.PayNowMakePayment("Cash");
            doptions.SelectModule("Manage Viewing");
            ManageViewingPage mvp = new ManageViewingPage(driver, test);
            mvp.VerifyPackageStatus(TestDataStore.ActivateDccWithXtraView);
            doptions.ClicklogoutOption();
            Assert.Pass("Activate DCC with XtraView customer has been completed successfully");
        }

        /// <summary>
        /// Test Case 60474: Manage Viewing: Xtraview 3rd Point - Activate Box Office where customer has three Explora devices for 3rd Point Xtraview
        /// </summary>
        [Test]
        public void ManageViewingXtraView3rdPointActivateBoxOfficeWhereCustomerHasThreeExploraDevicesFor3rdPointXtraviewSouthAfrica()
        {

            TestDataStore.ReadTestData("South Africa");
            test = Extent.CreateTest(TestContext.CurrentContext.Test.Name);
            string customerNumber = dbe.GetData(SubQuery.GetCustomerForCreationOf3PointXtraView, TestDataStore.ClarityLoginModel);
            ClarityLogin cl = new ClarityLogin(driver, test);
            cl.Login(TestDataStore.ClarityLoginModel);
            DashboardAndReceiptPage darp = new DashboardAndReceiptPage(driver, test);
            darp.ExistingCustomerSearch(customerNumber);
            DashBoardOptionsPage doptions = new DashBoardOptionsPage(driver, test);
            doptions.SelectOption("ManageViewing");
            doptions.SelectModule("Manage Customer");
            doptions.SelectOption("ManageViewing");
            doptions.SelectModule("XtraView");
            XtraviewPage xvp = new XtraviewPage(driver, test);
            xvp.CreateThreePointXtraview(TestDataStore.XtraViewActivationModel);
            doptions.SelectModule("BoxOffice");
            BoxOfficePage bop = new BoxOfficePage(driver, test);
            bop.ActivationOfBoxOffice();
            doptions.SelectOption("ManageViewing");
            doptions.SelectOption("ManageCustomer");
            DashBoardSubOptionPage dbsop = new DashBoardSubOptionPage(driver, test);
            dbsop.SelectSubOption("history");
            History h = new History(driver, test);
            h.VerifyHistoryEventID("310");
            doptions.SelectOption("ManageCustomer");
            doptions.SelectModule("Customer Interactions");
            CustomerInteractions ci = new CustomerInteractions(driver, test);
            ci.VerifyCustomerInteractions("XtraView 3rd Point Activate BoxOffice", "Reconnected service");
            doptions.SelectOption("ManageViewing");
            doptions.SelectModule("XtraView");
            xvp.BreakThreePointExtraView();
            doptions.ClicklogoutOption();
            Assert.Pass("XtraView 3rd point activate Box Office where customer has three explora devices for 3rd point XtraView has been completed successfully");
        }

        ///<summary>
        ///60455 - Manage Viewing: Xtraview 3rd Point - Cancel services for a Customer with Xtraview 3rd Point
        ///</summary>
        [Test]
        public void ManageViewingXtraviewThirdPointCancelServicesForCustomerWithXtraviewThirdPointSouthAfrica()
        {
            TestDataStore.ReadTestData("South Africa");
            test = Extent.CreateTest(TestContext.CurrentContext.Test.Name);
            ClarityLogin cl = new ClarityLogin(driver, test);
            cl.Login(TestDataStore.ClarityLoginModel);
            DashBoardOptionsPage doption = new DashBoardOptionsPage(driver, test);
            DashboardAndReceiptPage darp = new DashboardAndReceiptPage(driver, test);
            string customerNumber = dbe.GetData(SubQuery.GetResidentialCustomerHavingActiveXtraviewSA, TestDataStore.ClarityLoginModel);
            darp.LoadCustomer(customerNumber);
            doption.SelectModule("Manage Viewing");
            ManageViewingOptionPage mvop = new(driver, test);
            TestDataStore.GetGeneralSmartcardNumber.DecoderNumber = mvop.GrabSmartCardNumberforProduct(TestDataStore.GetGeneralSmartcardNumber);
            doption.SelectModule("Suspend - Cancel Packages");
            SuspendCancelPackages suspendCancelPackages = new SuspendCancelPackages(driver, test);
            suspendCancelPackages.CancelProductwithSlider(TestDataStore.GetGeneralSmartcardNumber.DecoderNumber);
            mvop.VerifyStatusOfPrincipalPackage(TestDataStore.ClarityLoginModel.Country, TestDataStore.GetGeneralSmartcardNumber.DecoderNumber, "-");
            mvop.ClickOnViewButtonForSmartcard(TestDataStore.GetGeneralSmartcardNumber);
            DeviceInformationAndCsiLogs deviceInformationAndCsiLogs = new DeviceInformationAndCsiLogs(driver, test);
            deviceInformationAndCsiLogs.CheckCSiLogs(TestDataStore.CsiLogsMessage.LogsId);
            doption.SelectModule("Manage Account");
            doption.SelectModule("View Financial Transactions");
            ViewFinancialTransactions viewFinancial = new ViewFinancialTransactions(driver, test);
            viewFinancial.VerifyTransactions(TestDataStore.FinancialTransactionTexts.TransactionText);
            doption.SelectModule("Manage Customer");
            doption.SelectModule("Customer Interactions");
            CustomerInteractions customerInteractions = new CustomerInteractions(driver, test);
            string date = CLDate.GenerateTodayDateWithFormat("M/d/yyyy");
            customerInteractions.VerifyCustomerInteractions(TestDataStore.CustomerInteractionMessages.ScheduledCancellationMessage + date);
            doption.ClicklogoutOption();
            Assert.Pass("Passed");
        }

        /// <summary>
        /// 60528	Existing Customer_Cancel the Bundle on SPL product and then Cancel the packages -Residential
        /// </summary>
        [Test]
        public void ManageViewingExistingCustomerCancelTheBundleOnSplProductAndCancelThePackagesResidentialSouthAfrica()
        {
            TestDataStore.ReadTestData("South Africa");
            test = Extent.CreateTest(TestContext.CurrentContext.Test.Name);
            ClarityLogin cl = new ClarityLogin(driver, test);
            cl.Login(TestDataStore.ClarityLoginModel);
            DashBoardOptionsPage doption = new DashBoardOptionsPage(driver, test);
            DashboardAndReceiptPage darp = new DashboardAndReceiptPage(driver, test);
            string customerNumber = dbe.GetData(SubQuery.GetActiveBundledCustomerSA, TestDataStore.ClarityLoginModel);
            darp.LoadCustomer(customerNumber);
            doption.SelectModule("Manage Viewing");
            ManageViewingOptionPage mvop = new ManageViewingOptionPage(driver, test);
            TestDataStore.GetDecoderAnnually.DecoderNumber = mvop.GrabSmartCardNumberforProduct(TestDataStore.GetDecoderAnnually);
            doption.SelectModule("Suspend - Cancel Packages");
            SuspendCancelPackages scp = new SuspendCancelPackages(driver, test);
            ViewFinancialTransactions viewFinancial = new ViewFinancialTransactions(driver, test);
            History hist = new History(driver, test);
            scp.CancelContractPeriod(TestDataStore.GetDecoderAnnually.DecoderNumber);
            doption.SelectModule("Manage Customer");
            doption.SelectModule("History");
            hist.VerifyHistoryEventID(TestDataStore.HistoryEventIds.CancelContractEventId);
            doption.SelectModule("Manage Account");
            doption.SelectModule("View Financial Transactions");
            viewFinancial.VerifyTransactions(TestDataStore.FinancialTransactionTexts.ChargeText);
            doption.SelectModule("Manage Viewing");
            doption.SelectModule("Suspend - Cancel Packages");
            scp.CancelAllPackages(TestDataStore.GetDecoderAnnually.DecoderNumber);
            doption.SelectModule("Manage Customer");
            doption.SelectModule("History");
            hist.VerifyHistoryEventID(TestDataStore.HistoryEventIds.CancelPackageEventId);
            doption.SelectModule("Manage Account");
            doption.SelectModule("View Financial Transactions");
            viewFinancial.VerifyTransactions(TestDataStore.FinancialTransactionTexts.ReversalText);
            doption.ClicklogoutOption();
            Assert.Pass("Passed");
        }
        ///<summary>
        /// TC: 60291- Manage Viewing : Holiday Home - Immediate Reconnect of Services for Prepaid Holiday Home SA
        /// </summary>
        [Test]
        public void ManageViewingHolidayHomeImmediateReconnectOfServicesForPrepaidHolidayHomeSA()
        {
            TestDataStore.ReadTestData("South Africa");
            test = Extent.CreateTest(TestContext.CurrentContext.Test.Name);
            ClarityLogin cl = new ClarityLogin(driver, test);
            cl.Login(TestDataStore.ClarityLoginModel);
            string customerNumber = dbe.GetData(SubQuery.GetResidentialCustomerWithSuspendedHolidayHome, TestDataStore.ClarityLoginModel);
            DashboardAndReceiptPage darp = new DashboardAndReceiptPage(driver, test);
            darp.ExistingCustomerSearch(customerNumber);
            DashBoardOptionsPage doptions = new DashBoardOptionsPage(driver, test);
            doptions.SelectModule("Manage Viewing");
            DeviceInformationAndCsiLogs dicsil = new DeviceInformationAndCsiLogs(driver, test);
            string smartcardForHH = dicsil.SelectSmartcardForSuspendedHolidayHomeAccount();
            doptions.SelectModule("Holiday Homes");
            HolidayHomesPage hhp = new HolidayHomesPage(driver, test);
            hhp.ReconnectHolidayHome(smartcardForHH);
            doptions.SelectModule("Manage Customer");
            doptions.SelectModule("Customer Interactions");
            CustomerInteractions ci = new CustomerInteractions(driver, test);
            ci.VerifyCustomerInteractions("Reconnect – Activation", "Reconnected services");
        }
    }
}
