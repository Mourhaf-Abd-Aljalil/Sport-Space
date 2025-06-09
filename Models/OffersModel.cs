using Microsoft.VisualBasic.FileIO;
using SportSpaceDataAccessLayer.ClassDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSpaceDataAccessLayer.Models
{
    public class OffersModel
    {
        public int Offers_ID { get; set; }
        public int Field_ID { get; set; }
        public string Description { get; set; }

        public decimal DiscountPercenttag { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }

        public OffersModel()
        {
            Offers_ID = -1;
            Field_ID = 0;
            Description = "";
            DiscountPercenttag = 0;
            Start_Date = DateTime.Now;
            End_Date = DateTime.Now;



        }

        public OffersModel( int FieldID, string Description, decimal DiscountPercenttag, DateTime Start_Date, DateTime End_Date )
        {
            
            this.Field_ID = FieldID;
            this.Description = Description;
            this.DiscountPercenttag = DiscountPercenttag;
            this.Start_Date = Start_Date;
            this.End_Date = End_Date;
        }


    }
}
