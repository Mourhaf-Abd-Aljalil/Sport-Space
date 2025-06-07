using Microsoft.AspNetCore.Mvc;
using SportSpaceBussinesLayer.Repository;
using SportSpaceDataAccessLayer.ClassDTO;
using System.Data;

namespace SportSpace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class FieldController : ControllerBase
    {

        private readonly FieldRepository Field;

        public FieldController(FieldRepository Field)
        {
            this.Field = Field;
        }



        [HttpGet("GetFindByID")]
        public ActionResult GetFindFieldByID(int ID)
        {
            var field = Field.FindFieldByID(ID);

            if (Field != null)
            {
                return Ok(new FieldDTO()
                {
                    FieldID = field.FieldID,
                    FieldName = field.FieldName,
                    OwnerID = field.OwnerID,
                    Location = field.Location,
                    FieldType = field.FieldType,
                    Capacity = field.Capacity,
                });
            }


            return BadRequest();

        }

        [HttpPost("AddNewField")]
        public string AddNewField( string FieldName, int OwnerID, string Location, string FieldType, int Capacity)
        {

            var field = new FieldDTO( FieldName, OwnerID, Location, FieldType, Capacity);

            // Field.AddNewField(Field);

            if (Field.AddNewField(field))
            {
                return $"Yes, the Field has been Added.";
            }
            else
                return $"No, the Field has not been added.";


        }


        [HttpPut("UpdateField")]
        public string UpdateField(int FieldID, string FieldName, int OwnerID, string Location, string FieldType, int Capacity)
        {

            FieldDTO field = Field.FindFieldByID(FieldID);

            if (field.FieldID != -1)
            {

                field.FieldID = FieldID;
                field.FieldName = FieldName;
                field.OwnerID = OwnerID;
                field.Location = Location;
                field.FieldType = FieldType;
                field.Capacity = Capacity;


                if (Field.UpdateField(field))
                {

                    return $"Yes, the Field has been Update.";
                }
                else
                {
                    return $"No, the Field has not been Update.";
                }
            }
            else
            {
                return $"Field Not Found Id= " + FieldID;
            }

        }

        [HttpDelete("DeleteField")]
        public string DeleteField(int ID)
        {

            FieldDTO field = Field.FindFieldByID(ID);

            if (field.FieldID != -1)
            {

                if (Field.DeleteField(ID))
                {

                    return $"Yes, the Field has been Delete.";
                }
                else
                {
                    return $"No, the Field has not been Delete.";
                }
            }
            else
            {
                return $"Field Not Found Id= " + ID;
            }

        }


        [HttpGet("isFieldExist")]
        public string isFieldExist(int ID)
        {
            if (Field.isFieldExist(ID))
            {
                return $"Yes, the Field Is found {ID}.";
            }
            else
            {
                return $"No, the Field has not found {ID}.";
            }
        }

        [HttpGet("GetAllFields")]
        public List<FieldDTO> GetAllFields()
        {

            DataTable dt = Field.GetAllFields();

            List<FieldDTO> Fields = dt.AsEnumerable().Select(row => new FieldDTO()
            {
                FieldID = row.Field<int>("Field_ID"),
                OwnerID = row.Field<int>("Owner_ID"),
                FieldName = row.Field<string>("Field_Name"),
                Location = row.Field<string>("Location"),
                FieldType = row.Field<string>("Field_Type"),
                Capacity = row.Field<int>("Capacity"),
            }).ToList<FieldDTO>();

            return Fields;

        }
        [HttpGet("GetAllFieldsByTypeORType")]
        public List<FieldBy> GetAllFieldsByTypeORType(string Type1 ,string Type2)
        {

            DataTable dt = Field.GetAllFieldsByTypeORType(Type1 ,Type2);

            List<FieldBy> Fields = dt.AsEnumerable().Select(row => new FieldBy()
            {
                FieldID = row.Field<int>("Field_ID"),
                FieldName = row.Field<string>("Field_Name"),
               
            }).ToList<FieldBy>();

            return Fields;

        }

        [HttpGet("GetAllFieldsByCapacity")]
        public List<FieldBy> GetAllFieldsByCapacity(int Capacity)
        {

            DataTable dt = Field.GetAllFieldsByCapacity(Capacity);

            List<FieldBy> Fields = dt.AsEnumerable().Select(row => new FieldBy()
            {
                FieldID = row.Field<int>("Field_ID"),
                FieldName = row.Field<string>("Field_Name"),

            }).ToList<FieldBy>();

            return Fields;

        }


    }
}
