using SeleniumTestProject.PageObject.MakePayment;
using SeleniumTestProject.PageObject;
using SeleniumTestProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumTestProject.PageObject.GetConnected;
using SeleniumTestProject.PageObject.ManageViewing;
using SeleniumTestProject.Utilities.DB.CustomQueries;

namespace SeleniumTestProject.Tests.SA
{
    public class MakePaymentsTests : BaseTestClass
    {
        /// <summary>
        /// 58151 - Clarity: Add and Assign Printers - Print Receipt
        /// </summary>
        [Test]
        public void ManagePaymentsClarityAddAndAssignPrintersPrintReceiptSouthAfrica()
        {
            TestDataStore.ReadTestData("South Africa");
            string amount = "10";
            test = Extent.CreateTest(TestContext.CurrentContext.Test.Name);
            ClarityLogin cl = new ClarityLogin(driver, test);
            cl.Login(TestDataStore.ClarityLoginModel);
            DashBoardOptionsPage doptions = new(driver, test);
            doptions.SelectOption("GetConnected");
            DashBoardSubOptionPage dsuboptions = new DashBoardSubOptionPage(driver, test);
            dsuboptions.SelectSubOption("makePayments");
            dsuboptions.SelectSubOption("addPrinters");
            AddPrinters ap = new AddPrinters(driver, test);
            string printerName = ap.searchPrinter("Test");
            Console.WriteLine(printerName);
            dsuboptions.SelectSubOption("assignPrinters");
            AssignPrintersPage app = new AssignPrintersPage(driver, test);
            app.SearchPrinter(printerName);
            app.AssignPrinter(TestDataStore.ClarityLoginModel, printerName);
            try
            {
                DashboardAndReceiptPage DARP = new DashboardAndReceiptPage(driver, test);
                string ResidentialCustomerNumber = dbe.GetData(SubQuery.GetResidentialCustomerNumberQuerySingleCustomerSA, TestDataStore.ClarityLoginModel);
                DARP.ExistingCustomerSearch(ResidentialCustomerNumber);
                dsuboptions.SelectSubOption("makePayments");
                CustomerPayment cp = new CustomerPayment(driver, test);
                cp.MakePayment(amount);
                cp.CloseReceipt();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dsuboptions.SelectSubOption("makePayments");
            dsuboptions.SelectSubOption("assignPrinters");
            app.UnassignPrinter(TestDataStore.ClarityLoginModel, printerName);
        }
    }
}
