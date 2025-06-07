using SportSpaceDataAccessLayer.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSpaceBussinesLayer.Repository
{
    public class Field_ServicesRepository
    {

        public DataTable GetFieldsByService(string ServiceName)
        {
            return Field_ServicesData.GetFieldsByService(ServiceName);
        }

        public DataTable GetAllFieldsWithServices()
        {
            return Field_ServicesData.GetAllFieldsWithServices();
        }
        public DataTable GetFields_NumbersOfService()
        {
            return Field_ServicesData.GetFields_NumbersOfService();
        }

        public DataTable GetAllFieldsWithServicesLessThan(decimal Cost)
        {
            return Field_ServicesData.GetAllFieldsWithServicesLessThan(Cost);
        }
        public DataTable GetAllFieldsWithServicesGreaterThan(decimal Cost)
        {
            return Field_ServicesData.GetAllFieldsWithServicesGreaterThan(Cost);
        }
    }
}
