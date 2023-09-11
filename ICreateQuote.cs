using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.Models
{
    public interface ICreateQuote
    {
        public string Country { get; set; }
        public string BusinessUnit { get; set; }
        public string CustomerType { get; set; }
        public string PrincipalPackages { get; set; }
        public string Subscription { get; set; }
        public string Devices { get; set; }
        public string Insurance { get; set; }
        public string HaveAddOn { get; set; }
        public string AddOn { get; set; }
        public string QuotationNumber { get; set; }
        public string VatNo { get; set; }
        public string AddCustInfo { get; set; }
        public string CaptureVatNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phoneprefix { get; set; }
        public string CountryCode { get; set; }
        public string SupervisorUsername { get; set; }
        public string PassCode { get; set; }
    }
}
