using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Class
{
    class ProjectBlock:Project
    {
        public int Blockno { get; set; }
        public int Lotno { get; set; }
        public double Area { get; set; }
        public decimal TCP { get; set; }
        public string Model { get; set; }

    }
}
