using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSpaceDataAccessLayer.ClassDTO
{
    public class F_NumberOfOffersDTO
    {
        public int Field_ID { get; set; }
        public string Field_Name { get; set; }
       
        public int NumberOfOferrs { get; set; }

        public F_NumberOfOffersDTO()
        {
            Field_ID = 0;
            Field_Name = string.Empty;
            NumberOfOferrs = 0;

        }

        public F_NumberOfOffersDTO(int Field_ID,string Field_Name, int NumberOfOferrs)
        {
            this.Field_ID = Field_ID;
            this.Field_Name = Field_Name;
            this.NumberOfOferrs = NumberOfOferrs;
        }



    }
}
