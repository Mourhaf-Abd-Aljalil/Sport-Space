using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSpaceDataAccessLayer.ClassDTO
{
    public class FieldDTO
    {
        public int FieldID { get; set; }
        public string FieldName { get; set; }
        public int OwnerID { get; set; }
        public string Location { get; set; }
        public string FieldType { get; set; }
        public int Capacity { get; set; }


        public FieldDTO(int ID)
        {

            FieldID = -1;
            FieldName = "";
        }

        public FieldDTO()
        {
            FieldID = -1;
            FieldName = "";
            Location = "";
            FieldType = "";
            Capacity = 0;
            OwnerID = 0;

           

        }

        public FieldDTO( string FieldNamet, int OwnerID, string Location, string FieldTypet, int Capacity)
        {
        
            this.FieldName = FieldNamet;
            this.Location = Location;
            this.FieldType = FieldTypet;
            this.Capacity = Capacity;
            this.OwnerID = OwnerID;

          
        }
       


    }
}
