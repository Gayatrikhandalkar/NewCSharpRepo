using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.Models
{
    public interface ISpecialistTypes
    {
        public string BusinessUnit { get; set; }
        public string CustomerType { get; set; }
        public string ResidenceType { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Identification { get; set; }
        public string IdentificationNo { get; set; }
        public string Language { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Suburb { get; set; }
        public string UnitNumber { get; set; }
        public string BuildingName { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string MethodOfPayment { get; set; }
        public string HouseholdFirstName { get; set; }
        public string HouseholdLastName { get; set; }
        public string CustomerNumber { get; set; }
        public string Device { get; set; }
    }
}
