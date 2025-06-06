using SportSpaceDataAccessLayer.ClassDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSpaceDataAccessLayer.Models
{
    public class OwnerModel
    {

        public int ID { get; set; }
        public string OwnerName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        List<FieldDTO> Fields = new List<FieldDTO>();





        public OwnerModel()
        {
            ID = -1;
            OwnerName = "";
            Email = "";
            PhoneNumber = "";

        }

        public OwnerModel(int ID, string OwnerName, string Email, string PhoneNumber)
        {
            this.ID = ID;
            this.OwnerName = OwnerName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;

        }
    }
}
