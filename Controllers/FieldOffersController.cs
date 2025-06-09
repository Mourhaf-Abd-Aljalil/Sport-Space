using Microsoft.AspNetCore.Mvc;
using SportSpaceBussinesLayer.Repository;
using SportSpaceDataAccessLayer.ClassDTO;
using System.Data;

namespace SportSpace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FieldOffersController : ControllerBase
    {
        private readonly OffersRepository Field_Offer;

        public FieldOffersController (OffersRepository Field_Offer)
        {
            this.Field_Offer = Field_Offer;
        }

        [HttpGet("GetFieldAndItsoffers")]
        public List<FieldOffersDTO> GetFieldAndItsoffers()
        {
            DataTable dt = Field_Offer.GetFieldAndItsOffers();

            List<FieldOffersDTO> FieldAndOffers = dt.AsEnumerable().Select(row => new FieldOffersDTO()
            {
                Field_Name = row.Field<string>("Field_Name"),
                Description = row.Field<string>("Descripyion"),
                DiscountPercenttag = row.Field<decimal>("DiscountPercenttag"),
            }).ToList<FieldOffersDTO>();

            return FieldAndOffers;
        }

        [HttpGet("GetFieldAndItsOffersGreaterThan")]
        public List<FieldOffersDTO> GetFieldAndItsOffersGreaterThan(decimal DiscountPercenttag)
        {
            DataTable dt = Field_Offer.GetFieldAndItsOffersGreaterThan(DiscountPercenttag);

            List<FieldOffersDTO> FieldAndOffers = dt.AsEnumerable().Select(row => new FieldOffersDTO()
            {
                Field_Name = row.Field<string>("Field_Name"),
                Description = row.Field<string>("Descripyion"),
                DiscountPercenttag = row.Field<decimal>("DiscountPercenttag"),
            }).ToList<FieldOffersDTO>();

            return FieldAndOffers;
        }


        [HttpGet("GetFieldAndItsOffersLessThan")]
        public List<FieldOffersDTO> GetFieldAndItsOffersLessThan(decimal DiscountPercenttag)
        {
            DataTable dt = Field_Offer.GetFieldAndItsOffersLessThan(DiscountPercenttag);

            List<FieldOffersDTO> FieldAndOffers = dt.AsEnumerable().Select(row => new FieldOffersDTO()
            {
                Field_Name = row.Field<string>("Field_Name"),
                Description = row.Field<string>("Descripyion"),
                DiscountPercenttag = row.Field<decimal>("DiscountPercenttag"),
            }).ToList<FieldOffersDTO>();

            return FieldAndOffers;
        }

        [HttpGet("GetFieldsLeastTwoOffers")]
        public List<FieldOffersDTO> GetFieldsLeastTwoOffers()
        {
            DataTable dt = Field_Offer.GetFieldsLeastTwoOffers();

            List<FieldOffersDTO> FieldAndOffers = dt.AsEnumerable().Select(row => new FieldOffersDTO()
            {
                Description = row.Field<string>("Descripyion"),
                Field_Name = row.Field<string>("Field_Name"),
                DiscountPercenttag = row.Field<decimal>("DiscountPercenttag"),
            }).ToList<FieldOffersDTO>();

            return FieldAndOffers;
        }

        [HttpGet("GetFieldsAndNumberOfferrs")]
        public List<F_NumberOfOffersDTO> GetFieldsAndNumberOfferrs()
        {
            DataTable dt = Field_Offer.GetFieldsAndNumberOfferrs();

            List<F_NumberOfOffersDTO> FieldAndOffers = dt.AsEnumerable().Select(row => new F_NumberOfOffersDTO()
            {
                Field_ID = row.Field<int>("Field_ID"),
                Field_Name = row.Field<string>("Field_Name"),
                NumberOfOferrs = row.Field<int>("NumberOfOffersForEachField"),
            }).ToList<F_NumberOfOffersDTO>();

            return FieldAndOffers;
        }


    }
}
