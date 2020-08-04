using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Class
{
    class Customer:Person
    {
        public string Bldgno { get; set; }
        public string Barangay { get; set; }
        public string CityProvince { get; set; }
        public string  Country { get; set; }
        public int ZipCode { get; set; }
        public string SpouseName { get; set; }
        public string SourceofIncome { get; set; }
        public string AverageIncome { get; set; }
        public string EmployersName { get; set; }
        public int LengthofStay { get; set; }
        public string TypeofOwnership { get; set; }
        public string PicUrl { get; set; }
        public string IdUrl { get; set; }


    }
}
