using SportSpaceDataAccessLayer.ClassDTO;
using SportSpaceDataAccessLayer.Data;
using SportSpaceDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSpaceBussinesLayer.Repository
{
    public class ServiceRepository
    {


        public ServicesModel FindServiceByID(int ID)
        {


            ServicesModel service = ServicesData.FindServiceByID(ID);
            if (service != null)
                return service;
            else
                return null;
        }
        /*
        public bool AddNewService(ServicesModel Service)
        {
            Service.Service_ID = ServicesData.AddNewService(Service);
            return (Service.Service_ID != -1);
        }
        */
       
        public bool UpdateService(ServicesModel Service)
        {
            return ServicesData.UpdateService(Service);
        }



        public bool DeleteService(int ID)
        {
            return ServicesData.DeleteService(ID);
        }


        public bool isServiceExist(int ID)
        {
            return ServicesData.IsServiceExist(ID);
        }
        public DataTable GetAllServices()
        {
            return ServicesData.GetAllServices();

        }

       



    }
}
