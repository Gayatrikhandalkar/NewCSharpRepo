using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.Models
{
    public interface IGrabDecoderModel
    {
        public string Status { get; set; }
        public string DecoderNumber { get; set; }
        public string DeviceSelection { get; set; }
        public string ContractPeriod { get; set; }
        public string Country { get; set; }
        public string Agreement { get; set; }
        public string IsDeviceNumber { get; set; }
    }
}
