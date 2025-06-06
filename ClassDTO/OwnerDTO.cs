using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSpaceDataAccessLayer.ClassDTO
{
    public class OwnerDTO
    {
        public int ID { get; set; }
        public string OwnerName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        //List<FieldRepository> Fields = new List<FieldRepository>();





        public OwnerDTO()
        {
            ID = -1;
            OwnerName = "";
            Email = "";
            PhoneNumber = "";

        }

        public OwnerDTO(int ID, string OwnerName, string Email, string PhoneNumber)
        {
            this.ID = ID;
            this.OwnerName = OwnerName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            
        }
    }
}
