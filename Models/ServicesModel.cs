using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSpaceDataAccessLayer.Models
{
    public class ServicesModel
    {
        public int Service_ID { get; set; }
        public string Service_Name { get; set; }
        public decimal Service_Cost { get; set; }

        public ServicesModel()
        {
            Service_ID = -1;
            Service_Name = string.Empty;
            Service_Cost = 0;
        }

        public ServicesModel( string ServiceName , decimal ServiceCost)
        {
            Service_ID = -1;
            Service_Name = Service_Name;
            Service_Cost = Service_Cost;
        }

    }
}
