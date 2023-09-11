using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.Models
{
    public interface ILoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string URL { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string ServiceName { get; set; }
        public string DbUserName { get; set; }
        public string DbPassword { get; set; }
    }
}
