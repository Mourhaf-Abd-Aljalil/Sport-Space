using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSpaceDataAccessLayer.ClassDTO
{
    public class FieldBy
    {
        public int FieldID { get; set; }
        public string FieldName { get; set; }
       


        

        public FieldBy()
        {
            FieldID = -1;
            FieldName = "";
           
        }

        public FieldBy(string FieldNamet)
        {

            this.FieldName = FieldNamet;
            


        }

    }
}
