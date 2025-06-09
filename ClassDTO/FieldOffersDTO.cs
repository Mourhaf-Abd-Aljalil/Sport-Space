using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSpaceDataAccessLayer.ClassDTO
{
    public class FieldOffersDTO
    {
        public string Field_Name { get; set; }
        public string Description { get; set; }
        public decimal DiscountPercenttag { get; set; }

        public FieldOffersDTO()
        {
            Field_Name = string.Empty;
            Description = string.Empty;
            DiscountPercenttag = decimal.MinValue;

        }

        public FieldOffersDTO(string Field_Name, string Description, decimal DiscountPercenttag)
        {
            this.Field_Name = Field_Name;
            this.Description = Description;
            this.DiscountPercenttag = DiscountPercenttag;
        }

    }
}
