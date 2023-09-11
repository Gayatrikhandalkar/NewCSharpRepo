using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.Models
{
    public interface IAddDeviceAndPackage
    {
        public string DeviceIndex { get; set; }
        public string DeviceNumber { get; set; }
        public string DevicePackageInclude { get; set; }
        public string DevicePackageType { get; set; }
        public string DeviceType { get; set; }
        public string DeviceAddOnInclude { get; set; }
        public string DeviceAddOnType { get; set; }
        public string DeviceInsuranceInclude { get; set; }
        public string PrincipalPackage { get; set; }
        public string AddOnPackage { get; set; }
        public string ProductType { get; set; }
        public string ChargePeriod { get; set; }
        public string AddOnCount { get; set; }
        public string DeviceBoxOfficeInclude { get; set; }
        public string BoxOfficeCount { get; set; }
        public string BoxOfficePackage { get; set; }
        public string IccStatus { get; set; }
        public string SapStatus { get; set; }
    }
}
