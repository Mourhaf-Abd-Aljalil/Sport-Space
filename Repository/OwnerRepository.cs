using SportSpaceDataAccessLayer.ClassDTO;
using SportSpaceDataAccessLayer.Data;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace SportSpaceBussinesLayer.Repository
{
    public class OwnerRepository
    {
      
        public OwnerDTO FindOwnerByID(int ID)
        {

            OwnerDTO owner = OwnerData.FindOwnerByID(ID);
            if (owner != null)
                return owner;
            else
                return null;




        }
      /*  public static OwnerModel FindOwnerByName(string OwnerName)
        {


            int ID = 0;
            string Email = "", PhoneNumber = "";
            if (OwnerData.FindOwnerByName(ref ID, OwnerName, ref Email, ref PhoneNumber))
            {
             
            }
            else
                return null;
        }
    */



        
         public bool AddNewOwner(OwnerDTO Owner)
         {
             return OwnerData.AddNewOwner(Owner);
         }
         public bool UpdateOwner(OwnerDTO Owner)
         {
             return OwnerData.UpdateOwner(Owner);
         }
         public bool DeleteOwner(int ID)
         {
             return OwnerData.DeleteOwner(ID);
         }
         public bool isOwnerExist(int ID)
         {
             return OwnerData.IsOwnerExist(ID);
         }
        public DataTable GetAllOwners()
        {
            return OwnerData.GetAllOwners();

        }

        
        

    }
}
