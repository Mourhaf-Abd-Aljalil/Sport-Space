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
    public class OffersRepository
    {
        public OffersModel FindOfferByID(int ID)
        {


            OffersModel Offer = OffersData.FindOffersByID(ID);
            if (Offer != null)
                return Offer;
            else
                return null;
        }

        public bool AddNewOffer(OffersModel Offer)
        {
            Offer.Offers_ID = OffersData.AddNewOffer(Offer);
            return (Offer.Offers_ID != -1);
        }


        public bool UpdateOffer(OffersModel Offer)
        {
            return OffersData.UpdateOffer(Offer);
        }



        public bool DeleteOffer(int ID)
        {
            return OffersData.DeleteOffer(ID);
        }


        public bool isOfferExist(int ID)
        {
            return OffersData.IsOfferExist(ID);
        }
        public DataTable GetAllOffers()
        {
            return OffersData.GetAllOffers();

        }

        public DataTable GetFieldAndItsOffers()
        {
            return Field_OffersData.GetFieldAndItsOffers();
        }
        public DataTable GetFieldAndItsOffersGreaterThan(decimal DiscountPercenttag)
        {
            return  Field_OffersData.GetFieldAndItsOffersGreaterThan(DiscountPercenttag);
        }
        public DataTable GetFieldAndItsOffersLessThan(decimal DiscountPercenttag)
        {
            return Field_OffersData.GetFieldAndItsOffersLessThan(DiscountPercenttag);
        }

        public DataTable GetFieldsLeastTwoOffers()
        {
            return Field_OffersData.GetFieldsLeastTwoOffers();
        }
        public DataTable GetFieldsAndNumberOfferrs()
        {
            return Field_OffersData.GetFieldsAndNumberOfferrs();
        }
    }
}
