using SeleniumTestProject.Models;
using Newtonsoft.Json;

namespace SeleniumTestProject.Utilities
{
    public static class TestDataStore
    {
        public static string CurrentCountry { get; private set; }
        public static CreateDealerModel CreateDealerModel { get; private set; }
        public static CreateCsiCustomerModel CreateCSICustomerModel { get; private set; }
        public static SelectModuleModel SelectModuleModel { get; private set; }
        public static CreateSpecialistCustomerModel CreateSpecialistCustomerModel { get; private set; }
        public static CreateQuoteModel CreateQuoteModel { get; private set; }
        public static CreateQuoteModelWithAddOn CreateQuoteModelWithAddOn { get; private set; }
        public static CreateQuoteModelWithVat CreateQuoteModelWithVat { get; private set; }
        public static SelectCountryModel SelectCountryModel { get; private set; }
        public static ExistingCustomerModel ExistingCustomerModel { get; private set; }
        public static CreateResidentialCustomerModel CreateResidentialCustomerModel { get; private set; }
        public static CreateQuoteModelWithVatForLojaCabinda CreateQuoteModelWithVatForLojaCabinda { get; private set; }
        public static ClarityLoginModel ClarityLoginModel { get; private set; }
        public static SupervisorLoginModel SupervisorLoginModel { get; private set; }
        public static StockAndDistributionCashSaleIssueStockPaymentMade StockAndDistributionCashSaleIssueStockPaymentMade { get; private set; }
		public static ManageCustomerModel ManageCustomerModel { get; private set; }
		public static GlobalSearchResidentialGOtvModel GlobalSearchResidentialGOtvModel { get; private set; }
		public static ManageCustomerResidentialGOtvModel ManageCustomerResidentialGOtvModel { get; private set; }
		public static AddDeviceAndPackageFirstDevice AddDeviceAndPackageFirstDevice { get; private set; }
		public static AddDeviceAndPackageSecondDevice AddDeviceAndPackageSecondDevice { get; private set; }
		public static AddDeviceAndPackageThirdDevice AddDeviceAndPackageThirdDevice { get; private set; }
		public static AddDeviceAndPackageAddOnDevice AddDeviceAndPackageAddOnDevice { get; private set; }
		public static CommercialCustomerSuspension CommercialCustomerSuspension { get; private set; }                                      
		public static MasterDetailsModel MasterDetailsModel { get; private set; }
		public static AddDeviceAndPackagesModelPreactivateXtraview AddDeviceAndPackagesModelPreactivateXtraview { get; private set; }
		public static ReconnectionOfSelectedDevice ReconnectionOfSelectedDevice { get; private set; }
		public static AddDeviceAndPackagesModel AddDeviceAndPackagesModel { get; private set; }
		public static ClarityCreditControlResidentialsLoginModel ClarityCreditControlResidentialsLoginModel { get; private set; }
		public static StolenDeviceSmartCard StolenDeviceSmartCard { get; private set; }
		public static StolenDeviceDecoder StolenDeviceDecoder { get; private set; }
		public static DBAccessModel DBAccessModel { get; private set; }
		public static AddDeviceAndPackageExistingDevice AddDeviceAndPackageExistingDevice { get; private set; }	
		public static AddDeviceAndPackageAddOn AddDeviceAndPackageAddOn { get; private set; }
		public static SuperUserDetailsModel SuperUserDetailsModel { get; private set; }
        public static SuperUserLoginModel SuperUserLoginModel { get; private set; }
        public static BillingCollectionSupervisorModel BillingCollectionSupervisorModel { get; private set; }
        public static CustomersServiceDetailsModel CustomersServiceDetailsModel { get; private set; }
        public static AddDeviceAndProductDetails AddDeviceAndProductDetails { get; private set; }
		public static AddDeviceAndPackageForDsd1132Device AddDeviceAndPackageForDsd1132Device { get; private set; }
		public static CreateSpecialistCustomerForGOtvBusinessUnit CreateSpecialistCustomerForGOtvBusinessUnit { get; private set; }       	               
        public static CommercialCustomerModel CommercialCustomerModel { get; private set; }
        public static XtraViewActivationModel XtraViewActivationModel { get; private set; }
        public static ClarityCommercialCreditControlResidentialsLoginModel ClarityCommercialCreditControlResidentialsLoginModel { get; private set; }
        public static ImmediateUpgradeDisconnectedPrinciplePackage ImmediateUpgradeDisconnectedPrinciplePackage { get; private set; }
        public static ImmediateDowngradeDisconnectedPrincipleandAddon ImmediateDowngradeDisconnectedPrincipleandAddon { get; private set; }
        public static ImmediateUpgradeDisconnectedPrincipleandAddon ImmediateUpgradeDisconnectedPrincipleandAddon { get; private set; }
        public static XtraviewResidentialCustomerDowngradeDiconnectedPackages XtraviewResidentialCustomerDowngradeDiconnectedPackages { get; private set; }
        public static XtraviewResidentialCustomerUpgradeDiconnectedPackages XtraviewResidentialCustomerUpgradeDiconnectedPackages { get; private set; }
        public static ImmediatePackageSuspensionViaSuspendAll ImmediatePackageSuspensionViaSuspendAll { get; private set; }
        public static BranchSuperuserToVerifyUserGettingErrorMessageAfterUsingGraceDays BranchSuperuserToVerifyUserGettingErrorMessageAfterUsingGraceDays { get; private set; }        
        public static AddDeviceAndPackageForGOtvDevice AddDeviceAndPackageForGOtvDevice { get; private set; }        
        public static ScheduleUpgradeActivePrinciplePackage ScheduleUpgradeActivePrinciplePackage { get; private set; }
        public static ImmediateUpgradeActivePrinciplePackage ImmediateUpgradeActivePrinciplePackage { get; private set; }        
        public static ScheduleReconnectDisconnectedPrinciplePackage ScheduleReconnectDisconnectedPrinciplePackage { get; private set; }
        public static ImmediateReconnectDisconnectedPrinciplePackage ImmediateReconnectDisconnectedPrinciplePackage { get; private set; }
        public static ScheduleDowngradeActivePrinciplePackage ScheduleDowngradeActivePrinciplePackage { get; private set; }
        public static AddDeviceAndPackageForBoxOffice AddDeviceAndPackageForBoxOffice { get; private set; }
        public static AddSmartCardPremiumE36ForSwap AddSmartCardPremiumE36ForSwap { get; private set; }
        public static SmartCardForBoxOffice SmartCardForBoxOffice { get; private set; }
        public static GrabSmartCardNumberForBoxOffice GrabSmartCardNumberForBoxOffice { get; private set; }
        public static HolidayHomeInstallation HolidayHomeInstallation { get; private set; }
        public static AddDeviceAndPackageForPs5100ImcDevice AddDeviceAndPackageForPs5100ImcDevice { get; private set; }
        public static AddDeviceAndActivate AddDeviceAndActivate { get; private set; }
        public static ImmediatePackageDisconnection ImmediatePackageDisconnection { get; private set; }
        public static ImmediateDowngradeMonthlyToQuaterly ImmediateDowngradeMonthlyToQuaterly { get; private set; }
        public static DowngradeWithAnnuallyChargePeriod DowngradeWithAnnuallyChargePeriod { get; private set; }
        public static ImmediateDowngradeDisconnectedPrinciplePackage ImmediateDowngradeDisconnectedPrinciplePackage { get; private set; }
        public static SuspendedHolidayHomeViewing SuspendedHolidayHomeViewing { get; private set; }
        public static ActivateDccWithXtraView ActivateDccWithXtraView { get; private set; }
        public static DccLoginSAModel DccLoginSAModel { get; private set; }
        public static GetGeneralSmartcardNumber GetGeneralSmartcardNumber { get; private set; }
        public static CustomerInteractionMessages CustomerInteractionMessages { get; private set; }
        public static FinancialTransactionTexts FinancialTransactionTexts { get; private set; }
        public static CsiLogsMessage CsiLogsMessage { get; private set; }
        public static HistoryEventIds HistoryEventIds { get; private set; }
        public static GetDecoderAnnually GetDecoderAnnually { get; private set; }
        public static CreateResidentialCustomerModelSA CreateResidentialCustomerModelSA { get; private set; }


        private static TestDataStructures testDataStructures;

        public static void ReadTestData(string country)
        {
            CurrentCountry = country;
            testDataStructures = GetTestDataJsonObject(country);
            CreateDealerModel = testDataStructures.TestDataModel.CreateDealerModel;
            CreateCSICustomerModel = testDataStructures.TestDataModel.CreateCsiCustomerModel;
            SelectModuleModel = testDataStructures.TestDataModel.SelectModuleModel;
            CreateSpecialistCustomerModel = testDataStructures.TestDataModel.CreateSpecialistCustomerModel;
            CreateQuoteModel = testDataStructures.TestDataModel.CreateQuoteModel;
            CreateQuoteModelWithAddOn = testDataStructures.TestDataModel.CreateQuoteModelWithAddOn;
            CreateQuoteModelWithVat = testDataStructures.TestDataModel.CreateQuoteModelWithVat;
            SelectCountryModel = testDataStructures.TestDataModel.SelectCountryModel;
            ClarityLoginModel = testDataStructures.TestDataModel.ClarityLoginModel;
            SupervisorLoginModel = testDataStructures.TestDataModel.SupervisorLoginModel;
            BillingCollectionSupervisorModel = testDataStructures.TestDataModel.BillingCollectionSupervisorModel;
            SelectCountryModel = testDataStructures.TestDataModel.SelectCountryModel;
            ExistingCustomerModel = testDataStructures.TestDataModel.ExistingCustomerModel;
            CreateResidentialCustomerModel = testDataStructures.TestDataModel.CreateResidentialCustomerModel;
            CreateQuoteModelWithVatForLojaCabinda = testDataStructures.TestDataModel.CreateQuoteModelWithVatForLojaCabinda;
            StockAndDistributionCashSaleIssueStockPaymentMade = testDataStructures.TestDataModel.StockAndDistributionCashSaleIssueStockPaymentMade;
            GlobalSearchResidentialGOtvModel = testDataStructures.TestDataModel.GlobalSearchResidentialGOtvModel;
            ManageCustomerResidentialGOtvModel = testDataStructures.TestDataModel.ManageCustomerResidentialGOtvModel;
            ManageCustomerModel = testDataStructures.TestDataModel.ManageCustomerModel;
            AddDeviceAndPackageFirstDevice = testDataStructures.TestDataModel.AddDeviceAndPackageFirstDevice;
            AddDeviceAndPackageSecondDevice = testDataStructures.TestDataModel.AddDeviceAndPackageSecondDevice;
            AddDeviceAndPackageThirdDevice = testDataStructures.TestDataModel.AddDeviceAndPackageThirdDevice;
            AddDeviceAndPackageAddOnDevice = testDataStructures.TestDataModel.AddDeviceAndPackageAddOnDevice;            
            CommercialCustomerSuspension = testDataStructures.TestDataModel.CommercialCustomerSuspension;
            MasterDetailsModel = testDataStructures.TestDataModel.MasterDetailsModel;
            AddDeviceAndPackagesModelPreactivateXtraview = testDataStructures.TestDataModel.AddDeviceAndPackagesModelPreactivateXtraview;
            AddDeviceAndPackagesModel = testDataStructures.TestDataModel.AddDeviceAndPackagesModel;
            ReconnectionOfSelectedDevice = testDataStructures.TestDataModel.ReconnectionOfSelectedDevice;
            ClarityCreditControlResidentialsLoginModel = testDataStructures.TestDataModel.ClarityCreditControlResidentialsLoginModel;
            StolenDeviceSmartCard = testDataStructures.TestDataModel.StolenDeviceSmartCard;
            StolenDeviceDecoder = testDataStructures.TestDataModel.StolenDeviceDecoder;
            DBAccessModel = testDataStructures.TestDataModel.DBAccessModel;
			SuperUserDetailsModel = testDataStructures.TestDataModel.SuperUserDetailsModel;
            SuperUserLoginModel = testDataStructures.TestDataModel.SuperUserLoginModel;
            CustomersServiceDetailsModel = testDataStructures.TestDataModel.CustomersServiceDetailsModel;
            AddDeviceAndPackageExistingDevice = testDataStructures.TestDataModel.AddDeviceAndPackageExistingDevice;
			AddDeviceAndPackageAddOn = testDataStructures.TestDataModel.AddDeviceAndPackageAddOn;           
			AddDeviceAndProductDetails = testDataStructures.TestDataModel.AddDeviceAndProductDetails;
            AddDeviceAndPackageForDsd1132Device = testDataStructures.TestDataModel.AddDeviceAndPackageForDsd1132Device;
			CreateSpecialistCustomerForGOtvBusinessUnit = testDataStructures.TestDataModel.CreateSpecialistCustomerForGOtvBusinessUnit;
            CommercialCustomerModel = testDataStructures.TestDataModel.CommercialCustomerModel;
            XtraViewActivationModel = testDataStructures.TestDataModel.XtraViewActivationModel;
            ClarityCommercialCreditControlResidentialsLoginModel = testDataStructures.TestDataModel.ClarityCommercialCreditControlResidentialsLoginModel;
            ImmediateUpgradeDisconnectedPrinciplePackage = testDataStructures.TestDataModel.ImmediateUpgradeDisconnectedPrinciplePackage;
            ImmediateDowngradeDisconnectedPrincipleandAddon = testDataStructures.TestDataModel.ImmediateDowngradeDisconnectedPrincipleandAddon;
            ImmediateUpgradeDisconnectedPrincipleandAddon = testDataStructures.TestDataModel.ImmediateUpgradeDisconnectedPrincipleandAddon;
            XtraviewResidentialCustomerDowngradeDiconnectedPackages = testDataStructures.TestDataModel.XtraviewResidentialCustomerDowngradeDiconnectedPackages;
            XtraviewResidentialCustomerUpgradeDiconnectedPackages = testDataStructures.TestDataModel.XtraviewResidentialCustomerUpgradeDiconnectedPackages;
            ImmediatePackageSuspensionViaSuspendAll = testDataStructures.TestDataModel.ImmediatePackageSuspensionViaSuspendAll;
            BranchSuperuserToVerifyUserGettingErrorMessageAfterUsingGraceDays = testDataStructures.TestDataModel.BranchSuperuserToVerifyUserGettingErrorMessageAfterUsingGraceDays;
            AddDeviceAndPackageForGOtvDevice = testDataStructures.TestDataModel.AddDeviceAndPackageForGOtvDevice;
            ScheduleUpgradeActivePrinciplePackage = testDataStructures.TestDataModel.ScheduleUpgradeActivePrinciplePackage; 
            ImmediateUpgradeActivePrinciplePackage = testDataStructures.TestDataModel.ImmediateUpgradeActivePrinciplePackage; 
            ScheduleReconnectDisconnectedPrinciplePackage = testDataStructures.TestDataModel.ScheduleReconnectDisconnectedPrinciplePackage;
            ImmediateReconnectDisconnectedPrinciplePackage = testDataStructures.TestDataModel.ImmediateReconnectDisconnectedPrinciplePackage;
            ScheduleDowngradeActivePrinciplePackage = testDataStructures.TestDataModel.ScheduleDowngradeActivePrinciplePackage;
            AddDeviceAndPackageForBoxOffice = testDataStructures.TestDataModel.AddDeviceAndPackageForBoxOffice;
            AddSmartCardPremiumE36ForSwap = testDataStructures.TestDataModel.AddSmartCardPremiumE36ForSwap;
            SmartCardForBoxOffice = testDataStructures.TestDataModel.SmartCardForBoxOffice;
            GrabSmartCardNumberForBoxOffice = testDataStructures.TestDataModel.GrabSmartCardNumberForBoxOffice;
            HolidayHomeInstallation = testDataStructures.TestDataModel.HolidayHomeInstallation;
            AddDeviceAndPackageForPs5100ImcDevice = testDataStructures.TestDataModel.AddDeviceAndPackageForPs5100ImcDevice;
            AddDeviceAndActivate = testDataStructures.TestDataModel.AddDeviceAndActivate;
            ImmediatePackageDisconnection = testDataStructures.TestDataModel.ImmediatePackageDisconnection;
            ImmediateDowngradeMonthlyToQuaterly = testDataStructures.TestDataModel.ImmediateDowngradeMonthlyToQuaterly;
            DowngradeWithAnnuallyChargePeriod = testDataStructures.TestDataModel.DowngradeWithAnnuallyChargePeriod;
            ImmediateDowngradeDisconnectedPrinciplePackage = testDataStructures.TestDataModel.ImmediateDowngradeDisconnectedPrinciplePackage;
            SuspendedHolidayHomeViewing = testDataStructures.TestDataModel.SuspendedHolidayHomeViewing;
            ActivateDccWithXtraView = testDataStructures.TestDataModel.ActivateDccWithXtraView;
            DccLoginSAModel = testDataStructures.TestDataModel.DccLoginSAModel;
            GetGeneralSmartcardNumber = testDataStructures.TestDataModel.GetGeneralSmartcardNumber;
            CustomerInteractionMessages = testDataStructures.TestDataModel.CustomerInteractionMessages;
            FinancialTransactionTexts = testDataStructures.TestDataModel.FinancialTransactionTexts;
            CsiLogsMessage = testDataStructures.TestDataModel.CsiLogsMessage;
            GetDecoderAnnually = testDataStructures.TestDataModel.GetDecoderAnnually;
            HistoryEventIds = testDataStructures.TestDataModel.HistoryEventIds;
            CreateResidentialCustomerModelSA = testDataStructures.TestDataModel.CreateResidentialCustomerModelSA;
        }

        public static string GetProjectRootDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            return currentDirectory.Split("bin")[0];
        }

        public static TestDataStructures GetTestDataJsonObject(string country)
        {
            string path1 = Path.Combine(GetProjectRootDirectory(), "TestData", country + "_Clarity_TestData.json");
            var jObject1 = File.ReadAllText(path1);
            var jsonObj1 = JsonConvert.DeserializeObject<TestDataStructures>(jObject1);
            return jsonObj1;
        }
    }
}