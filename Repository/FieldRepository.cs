using SportSpaceDataAccessLayer.ClassDTO;
using SportSpaceDataAccessLayer.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSpaceBussinesLayer.Repository
{
    public class FieldRepository
    {



        public FieldDTO FindFieldByID(int ID)
        {

            
            FieldDTO field = FieldData.FindFieldByID(ID);
            if (field != null)
                return field;
            else
                return null;
        }

        /*
        public DataTable FindFieldByName(string Name)
        {
            string Location = "", FieldTypet = "";
            int ID = -1, Capacity = 0, OwnerID = 0;

            DataTable dt = FieldData.FindFieldByName(ref ID, Name, ref OwnerID, ref Location, ref FieldTypet, ref Capacity);
            if (dt != null)
            {
                return dt;
            }
            else
                return null;
        }
        */
        
        public bool AddNewField(FieldDTO field)
        {
            field.FieldID = FieldData.AddNewField(field);
            return (field.FieldID != -1);
        }


        public bool UpdateField(FieldDTO field)
        {
            return FieldData.UpdateField(field);
        }


        
        public  bool DeleteField(int ID)
        {
            return FieldData.DeleteField(ID);
        }
        

        public  bool isFieldExist(int ID)
        {
            return FieldData.IsFieldExist(ID);
        }
        public  DataTable GetAllFields()
        {
            return FieldData.GetAllFields();

        }

        public DataTable GetAllFieldsByTypeORType(string Type1, string Type2)
        {
            return FieldData.GetAllFieldsByTypeORType(Type1, Type2);
        }
        public DataTable GetAllFieldsByCapacity(int Capacity)
        {
            return FieldData.GetAllFieldsByCapacity(Capacity);
        }

       

    }
}
