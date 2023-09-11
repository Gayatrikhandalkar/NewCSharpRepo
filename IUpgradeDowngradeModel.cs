using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.Models
{
    public interface IUpgradeDowngradeModel : IGrabDecoderModel
    {  
        public string Action { get; set; }
        public string ChargePeriod { get; set; }
        public string IpDate { get; set; }
        public string Package { get ; set; }
        public string Schedule { get; set; }
    }
}
