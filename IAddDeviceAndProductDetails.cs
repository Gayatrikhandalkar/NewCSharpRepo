using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.Models
{
    public interface IAddDeviceAndProductDetails
    {
        public string DeviceNumber { get; set; }
        public bool AddOn { get; set; }
        public string AddOnCount { get; set; }
        public string ChargePeriod { get; set; }
        public string PrincipalPackage { get; set; }
        public string Product { get; set; }
    }
}
