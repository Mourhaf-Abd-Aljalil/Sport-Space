using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSpaceDataAccessLayer.Models
{
    public class Field_ServicesModel
    {
        public int FieldID { get; set; }
        //public string FieldName { get; set; }
        //public int OwnerID { get; set; }
        //public string Location { get; set; }
        //public string FieldType { get; set; }
        //public int Capacity { get; set; }
        //public int Service_ID { get; set; }
        public string Service_Name { get; set; }
        public decimal ServiceCost { get; set; }

        public Field_ServicesModel()
        {
            FieldID = -1;
            Service_Name = string.Empty;
            ServiceCost = 0;
        }

        public Field_ServicesModel(int ID , string Service_Name ,decimal Service_Cost)
        {
            this.FieldID = ID;
            this.Service_Name = Service_Name;
            this.ServiceCost = Service_Cost;
        }

       

    }
}
