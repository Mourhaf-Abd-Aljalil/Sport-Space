using Microsoft.AspNetCore.Mvc;
using SportSpaceBussinesLayer.Repository;
using SportSpaceDataAccessLayer.ClassDTO;
using SportSpaceDataAccessLayer.Data;
using SportSpaceDataAccessLayer.Models;
using System.Data;

namespace SportSpace.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class Field_ServicesController: ControllerBase
    {
        private readonly Field_ServicesRepository _Service;
    

        public Field_ServicesController(Field_ServicesRepository Service)
        {
            _Service = Service;
        }

        [HttpGet("GetFieldsByService")]
        public List<int> GetFieldsByService(string ServiceName)
        {
            {

                DataTable dt = _Service.GetFieldsByService(ServiceName);

                List<int> Fields_ID = dt.AsEnumerable().Select(row => row.Field<int>("Field_ID")
                    ).ToList<int>();

                return Fields_ID;

            }

        }

        [HttpGet(" GetAllFieldsWithServices")]
        public List<Field_ServicesModel> GetAllFieldsWithServices()
        {
            {

                DataTable dt = _Service.GetAllFieldsWithServices();

                List<Field_ServicesModel> Field_Service = dt.AsEnumerable().Select(row => new Field_ServicesModel()
                {
                    FieldID = row.Field<int>("Field_ID"),
                    Service_Name = row.Field<string>("Service_Name"),
                    ServiceCost = row.Field<decimal>("Service_Cost"),
                }
                ).ToList<Field_ServicesModel>();

                return Field_Service;

            }

        }
        [HttpGet("GetFields_NumbersOfService")]
        public List<FieldNumberOfServiceDTO> GetFields_NumbersOfService()
        {
            {

                DataTable dt = _Service.GetFields_NumbersOfService();

                List<FieldNumberOfServiceDTO> Field_Service = dt.AsEnumerable().Select(row => new FieldNumberOfServiceDTO()
                {
                    Field_ID = row.Field<int>("Field_ID"),
                    NumberOfService = row.Field<int>("NumberOfServices"),
                   
                }
                ).ToList<FieldNumberOfServiceDTO>();

                return Field_Service;

            }

        }

        [HttpGet("GetAllFieldsWithServicesLessThan")]
        public List<Field_ServicesModel> GetAllFieldsWithServicesLessThan(decimal Cost)
        {
            {

                DataTable dt = _Service.GetAllFieldsWithServicesLessThan(Cost);

                List<Field_ServicesModel> Field_Service = dt.AsEnumerable().Select(row => new Field_ServicesModel()
                {
                    FieldID = row.Field<int>("Field_ID"),
                    Service_Name = row.Field<string>("Service_Name"),
                    ServiceCost = row.Field<decimal>("Service_Cost"),
                }
                ).ToList<Field_ServicesModel>();

                return Field_Service;

            }

        }

        [HttpGet("GetAllFieldsWithServicesGreaterThan")]
        public List<Field_ServicesModel> GetAllFieldsWithServicesGreaterThan(decimal Cost)
        {
            {

                DataTable dt = _Service.GetAllFieldsWithServicesGreaterThan(Cost);

                List<Field_ServicesModel> Field_Service = dt.AsEnumerable().Select(row => new Field_ServicesModel()
                {
                    FieldID = row.Field<int>("Field_ID"),
                    Service_Name = row.Field<string>("Service_Name"),
                    ServiceCost = row.Field<decimal>("Service_Cost"),
                }
                ).ToList<Field_ServicesModel>();

                return Field_Service;

            }

        }







    }
}
