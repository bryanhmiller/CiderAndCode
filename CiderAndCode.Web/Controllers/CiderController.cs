using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CiderAndCode.Web.DataModels;
using CiderAndCode.Web.ViewModels;

namespace CiderAndCode.Web.Controllers
{
    [RoutePrefix("api/cider")]
    public class CiderController : ApiController
    {
        [Route(""), HttpPost]
        public HttpResponseMessage MakeCider(MakeCiderRequest makeCiderRequest)
        {
            var db = new AppDbContext();

            var bushel = db.Bushels.Find(makeCiderRequest.BushelId);

            if (bushel == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No bushel with the given id exists");
            }
            if (bushel.Pressed)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "This bushel has already been pressed");
            }

            bushel.Pressed = true;

            var newCider = new Cider
            {
                Type = bushel.Type,
                Bushel = bushel,
                DatePressed = DateTime.Now,
                Filtered = false,
                NumberOfGallons = bushel.Quantity * 3
            };

            db.Ciders.Add(newCider);
            
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                //log.error(ex);
                Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "Couldn't make cider today, Machine is down for repairs.");
            }

            return Request.CreateResponse(HttpStatusCode.Created, newCider);
        }

        [HttpGet, Route("")]
        public HttpResponseMessage GetAllCiders()
        {
            var db = new AppDbContext();

            var ciders = db.Ciders
                .Select(cider => new CiderResult
                {
                    NumberOfGallons = cider.NumberOfGallons,
                    TypeOfApple = cider.Type.ToString(),
                    DatePressed = cider.DatePressed
                });

            return Request.CreateResponse(HttpStatusCode.OK, ciders);
        }

    }

    public class MakeCiderRequest
    {
        public int BushelId { get; set; }
    }
}
