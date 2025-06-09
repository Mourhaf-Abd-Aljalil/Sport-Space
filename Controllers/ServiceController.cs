using Microsoft.AspNetCore.Mvc;
using SportSpaceBussinesLayer.Repository;
using SportSpaceDataAccessLayer.ClassDTO;
using SportSpaceDataAccessLayer.Models;
using System.Data;

namespace SportSpace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly ServiceRepository service;

        public ServiceController(ServiceRepository service)
        {
            this.service = service;
        }


        [HttpGet("GetServiceByID")]
        public ActionResult GetServiceByID(int ID)
        {
            var Service = service.FindServiceByID(ID);

            if (Service != null)
            {
                return Ok(new ServicesModel()
                {
                    Service_ID = Service.Service_ID,
                    Service_Name = Service.Service_Name,
                    Service_Cost = Service.Service_Cost,
                   
                });
            }


            return BadRequest();

        }
        /*
        
        [HttpPost("AddNewService")]
        public string AddNewService(string ServiceName, decimal Cost)
        {

            ServicesModel Service = new ServicesModel(ServiceName, Cost);

            // Service.AddNewService(Service);

            if (service.AddNewService(Service))
            {
                return $"Yes, the Service has been Added.";
            }
            else
                return $"No, the Service has not been added.";


        }
       */

        [HttpPut("UpdateService")]
        public string UpdateService(int ServiceID, string ServiceName, decimal Cost)
        {

            ServicesModel Service = service.FindServiceByID(ServiceID);

            if (Service.Service_ID != -1)
            {

                Service.Service_ID = ServiceID;
                Service.Service_Name = ServiceName; 
                Service.Service_Cost = Cost;
                


                if (service.UpdateService(Service))
                {

                    return $"Yes, the Service has been Update.";
                }
                else
                {
                    return $"No, the Service has not been Update.";
                }
            }
            else
            {
                return $"Service Not Found Id= " + ServiceID;
            }

        }

        [HttpDelete("DeleteService")]
        public string DeleteService(int ID)
        {

            ;

            if (service.isServiceExist(ID))
            {

                if (service.DeleteService(ID))
                {

                    return $"Yes, the Service has been Delete.";
                }
                else
                {
                    return $"No, the Service has not been Delete.";
                }
            }
            else
            {
                return $"Service Not Found Id= " + ID;
            }

        }


        [HttpGet("isServiceExist")]
        public string isServiceExist(int ID)
        {
            if (service.isServiceExist(ID))
            {
                return $"Yes, the Service Is found {ID}.";
            }
            else
            {
                return $"No, the Service has not found {ID}.";
            }
        }

        [HttpGet("GetAllServices")]
        public List<ServicesModel> GetAllServices()
        {

            DataTable dt = service.GetAllServices();

            List<ServicesModel> Services = dt.AsEnumerable().Select(row => new ServicesModel()
            {
                Service_ID = row.Field<int>("Service_ID"),
                Service_Name = row.Field<string>("Service_Name"),
                Service_Cost = row.Field<decimal>("Service_Cost"),

            }).ToList<ServicesModel>();

            return Services;

        }

    }
}
