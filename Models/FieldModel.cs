using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSpaceDataAccessLayer.Models
{
    public class FieldModel
    {

        public int FieldID { get; set; }
        public string FieldName { get; set; }
        public int OwnerID { get; set; }
        public string Location { get; set; }
        public string FieldType { get; set; }
        public int Capacity { get; set; }


        public FieldModel()
        {
            FieldID = -1;
            FieldName = "";
            Location = "";
            FieldType = "";
            Capacity = 0;
            OwnerID = 0;



        }

        public FieldModel(int FieldID, string FieldNamet, int OwnerID, string Location, string FieldTypet, int Capacity)
        {
            this.FieldID = FieldID;
            this.FieldName = FieldNamet;
            this.Location = Location;
            this.FieldType = FieldTypet;
            this.Capacity = Capacity;
            this.OwnerID = OwnerID;


        }
    }
}
