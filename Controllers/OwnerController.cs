using Microsoft.AspNetCore.Mvc;
using SportSpaceBussinesLayer.Repository;
using SportSpaceDataAccessLayer.ClassDTO;
using System.Data;
using System.Runtime.CompilerServices;

namespace SportSpace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class OwnerController :ControllerBase
    {

        private readonly OwnerRepository Owner;

            public OwnerController(OwnerRepository Owner)
            {
                this.Owner = Owner;
            }



        [HttpGet("GetFindOwnerByID")]
        public ActionResult GetFindOwnerByID(int ID)
        {
            var owner = Owner.FindOwnerByID(ID);

            if (owner != null)
            {
                return Ok(new OwnerDTO()
                {
                    ID = owner.ID,
                    OwnerName = owner.OwnerName,
                    Email = owner.Email,
                    PhoneNumber = owner.PhoneNumber,
                });
            }


            return BadRequest();

        }

        [HttpPost("AddNewOwner")]
        public string AddNewOwner(int ID, string Name , string Email, string PhoneNumber)
        {

            var owner = new OwnerDTO(ID , Name ,Email, PhoneNumber);

            // Owner.AddNewOwner(owner);

            if (Owner.AddNewOwner(owner))
            {
                return $"Yes, the Owner has been Added.";
            }
            else
                return $"No, the Owner has not been added.";
            

        }


        [HttpPut("UpdateOwner")]
        public string UpdateOwner(int ID, string Name, string Email, string PhoneNumber)
        {

            OwnerDTO owner = Owner.FindOwnerByID(ID);

            if (owner.ID != -1)
            {

                owner.ID = ID;
                owner.OwnerName = Name;
                owner.Email = Email;
                owner.PhoneNumber = PhoneNumber;

                if (Owner.UpdateOwner(owner))
                {

                    return $"Yes, the Owner has been Update.";
                }
                else
                {
                    return $"No, the Owner has not been Update.";
                }
            }
            else
            {
                return $"Owner Not Found Id= " + ID;
            }

        }

        [HttpDelete("DeleteOwner")]
        public string DeleteOwner(int ID)
        {

            OwnerDTO owner = Owner.FindOwnerByID(ID);

            if (owner.ID != -1)
            {

                if (Owner.DeleteOwner(ID))
                {

                    return $"Yes, the Owner has been Delete.";
                }
                else
                {
                    return $"No, the Owner has not been Delete.";
                }
            }
            else
            {
                return $"Owner Not Found Id= " + ID;
            }

        }


        [HttpGet("isOwnerExist")]
        public string isOwnerExist(int ID)
        {
            if (Owner.isOwnerExist(ID))
            {
                return $"Yes, the Owner Is found {ID}.";
            }
            else
            {
                return $"No, the Owner has not found {ID}.";
            }
        }


    }
}