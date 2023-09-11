using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.Models
{
    public interface IStolenDevice
    {
        public string DeviceType { get; set; }
        public string PoliceCaseNumber { get; set; }
        public string PoliceStation { get; set; }
        public string PoliceCaseDate { get; set; }
    }
}
