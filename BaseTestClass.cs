using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTestProject.Models;
using System.Configuration;
using System.Data.Common;
using SeleniumTestProject.Utilities.DB.Base;
using SeleniumTestProject.PageObject.ManageViewing;
using SeleniumTestProject.PageObject;
using SeleniumTestProject.Utilities.DB.CustomQueries;


namespace SeleniumTestProject.Utilities
{
	public class BaseTestClass
    {
        public ExtentTest test;
        public IWebDriver driver;
        string WorkingDirectory;
        string ProjectDirectory;
        public IDictionary<string, TestDataStructures> testDataStructures;      
        public ExtentReports Extent { get; set; }
        public DbEngine dbe;

        [OneTimeSetUp]
        public void Initilazation()
        {
            WorkingDirectory = Environment.CurrentDirectory; 
            ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;            
            string reportPath = ProjectDirectory.Replace("\\", "/") + "/Reporting/";
			ScreenShot.ProjectDirectory = reportPath;
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            Extent = new ExtentReports();
            Extent.AttachReporter(htmlReporter);
            dbe = new DbEngine();
        }

        [SetUp]
        public void Setup()
        {
            var chromeOptions = new ChromeOptions();
#if !DEBUG
            var proxy = new Proxy
			{
				Kind = ProxyKind.Manual,
				IsAutoDetect = false,
				HttpProxy = "http://03rnb-censorn03:8080",
				SslProxy = "http://03rnb-censorn03:8080"
			};
                chromeOptions.Proxy = proxy;
#endif

	            chromeOptions.AddArguments("--headless=new");
                chromeOptions.AddArgument("--window-size=1920,1080");
                chromeOptions.AddArgument("--start-maximized");
                chromeOptions.AddUserProfilePreference("download.default_directory", TestDataReader.DownloadFilePath());
            driver = new ChromeDriver(chromeOptions);

            driver.Manage().Cookies.DeleteAllCookies(); 
            try
            {
                string clarityRootPath = ConfigurationManager.AppSettings["ClarityService"];
                // If directory does not exist, don't even try   
                Directory.Delete(clarityRootPath, true);
            }
            catch(Exception Ex) 
            {
                Console.WriteLine(Ex.Message);
            }
        }

        [OneTimeTearDown]
		public void TearDownOne()
		{
			try
			{
				Extent.Flush();
			}
			catch (Exception ex)
			{
				TestContext.Progress.WriteLine(ex.Message);
			}
		}

		[TearDown]
        public void TearDown()
        {
            driver.Quit();
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;
            DateTime time = DateTime.Now;
			_ = "Screenshot_" + time.ToString("h_mm_ss") + ".png";

			if (status == TestStatus.Failed)
            {
 
                _ = test.Fail("Test failed");
                test.Log(Status.Fail, "test failed with logtrace" + stackTrace);
                TestContext.Progress.WriteLine(stackTrace); 
            }
            else if (status == TestStatus.Passed)
            {
                _ = test.Pass("Test passed");
                test.Log(Status.Pass, "test passed");
                TestContext.Progress.WriteLine("Test passed");
            }
		}
        /// <summary>
        /// 63191	To Verify products description in Portuguese while creating 3 point xtra view
        /// EXPLORA DEVICE WITH PREMIUM Package
        /// </summary>
        [Test]
        public void ManageViewingToBreak3rdPointClarityWebApplicationAngola()
        {
            TestDataStore.ReadTestData("Angola");
            test = Extent.CreateTest(TestContext.CurrentContext.Test.Name);
            string custNo = dbe.GetData(SubQuery.GetCustomerProductsDescriptionInPortugueseWhileCreating3PointXtraView, TestDataStore.ClarityLoginModel);
            ClarityLogin cl = new ClarityLogin(driver, test);
            cl.Login(TestDataStore.ClarityLoginModel);
            DashboardAndReceiptPage darp = new DashboardAndReceiptPage(driver, test);
            ManageViewingOptionPage mvop = new ManageViewingOptionPage(driver, test);
            DashBoardOptionsPage doptions = new DashBoardOptionsPage(driver, test);
            XtraviewPage xvp = new XtraviewPage(driver, test);
            darp.ExistingCustomerSearch(custNo);
            doptions.SelectOption("ManageViewing");
            mvop.SelectSubOption("Xtraview");
            xvp.CreateThreePointXtraview(TestDataStore.XtraViewActivationModel);
            xvp.BreakThreePointExtraView();
            Assert.Pass("Pass");
        }
    }
}