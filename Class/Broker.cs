using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Class
{
    public class Broker:Person
    {
        public string BrokerObjid { get; set; }
        public string PRCNo { get; set; }
        public DateTime ValidUntil { get; set; }

    }
}
