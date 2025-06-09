using Microsoft.AspNetCore.Mvc;
using SportSpaceBussinesLayer.Repository;
using SportSpaceDataAccessLayer.ClassDTO;
using SportSpaceDataAccessLayer.Models;
using System.Data;

namespace SportSpace.Controllers
{
        [ApiController]
        [Route("[controller]")]
       
    public class OffersController : ControllerBase
    {


            private readonly OffersRepository Offer;

            public OffersController(OffersRepository Offer)
            {
                this.Offer = Offer;
            }


            [HttpGet("GetFindByID")]
            public ActionResult GetFindOfferByID(int ID)
            {
                var offer = Offer.FindOfferByID(ID);

                if (Offer != null)
                {
                    return Ok(new OffersModel()
                    {
                        Offers_ID = offer.Offers_ID,
                        Field_ID = offer.Field_ID,
                        Description = offer.Description,
                        DiscountPercenttag = offer.DiscountPercenttag,
                        Start_Date = offer.Start_Date,
                        End_Date = offer.End_Date,
                    });
                }


                return BadRequest();

            }

            [HttpPost("AddNewOffer")]
            public string AddNewOffer( int Field_ID, string Description, decimal DiscountPercenttag, DateTime Start_Date, DateTime End_Date)
            {

                var offer = new OffersModel( Field_ID, Description, DiscountPercenttag, Start_Date, End_Date);

                // Offer.AddNewOffer(Offer);

                if (Offer.AddNewOffer(offer))
                {
                    return $"Yes, the Offer has been Added.";
                }
                else
                    return $"No, the Offer has not been added.";


            }


            [HttpPut("UpdateOffer")]
            public string UpdateOffer(int Offers_ID, int Field_ID, string Description, decimal DiscountPercenttag, DateTime Start_Date, DateTime End_Date)
            {

                OffersModel offer = Offer.FindOfferByID(Offers_ID);

                if (offer.Offers_ID != -1)
                {

                    offer.Offers_ID = Offers_ID;
                    offer.Field_ID = Field_ID;
                    offer.Description = Description;
                    offer.DiscountPercenttag = DiscountPercenttag;
                    offer.Start_Date = Start_Date;
                    offer.End_Date = End_Date;


                    if (Offer.UpdateOffer(offer))
                    {

                        return $"Yes, the Offer has been Update.";
                    }
                    else
                    {
                        return $"No, the Offer has not been Update.";
                    }
                }
                else
                {
                    return $"Offer Not Found Id= " + Offers_ID;
                }

            }

            [HttpDelete("DeleteOffer")]
            public string DeleteOffer(int ID)
            {

                OffersModel offer = Offer.FindOfferByID(ID);

                if (offer.Offers_ID != -1)
                {

                    if (Offer.DeleteOffer(ID))
                    {

                        return $"Yes, the Offer has been Delete.";
                    }
                    else
                    {
                        return $"No, the Offer has not been Delete.";
                    }
                }
                else
                {
                    return $"Offer Not Found Id= " + ID;
                }

            }


            [HttpGet("isOfferExist")]
            public string isOfferExist(int ID)
            {
                if (Offer.isOfferExist(ID))
                {
                    return $"Yes, the Offer Is found {ID}.";
                }
                else
                {
                    return $"No, the Offer has not found {ID}.";
                }
            }

            [HttpGet("GetAllOffers")]
            public List<OffersModel> GetAllOffers()
            {

                DataTable dt = Offer.GetAllOffers();

                List<OffersModel> Offers = dt.AsEnumerable().Select(row => new OffersModel()
                {
                    Offers_ID = row.Field<int>("Offer_ID"),
                    Field_ID = row.Field<int>("Field_ID"),
                    Description = row.Field<string>("Descripyion"),
                    DiscountPercenttag = row.Field<decimal>("DiscountPercenttag"),
                    Start_Date = row.Field<DateTime>("Start_Date"),
                    End_Date = row.Field<DateTime>("End_Date"),
                }).ToList<OffersModel>();

                return Offers;

            }


        }
    }

