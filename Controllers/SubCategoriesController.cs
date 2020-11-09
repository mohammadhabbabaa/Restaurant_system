using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using ApiConnect;

namespace WebApi.Controllers
{
    public class SubCategoriesController : ApiController
    {
        ModalFactory _modal = new ModalFactory();

        SubCategoriesData data = new SubCategoriesData();
        // GET api/values
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.NotFound,"Please enter the Categoy ID in the URL");
      }

        // GET api/values/RestourantID
        public HttpResponseMessage Get(int id)
        {
            var newobject = Functions.GetSubCategoiesByCategoryID(id).ToList().Select(c => _modal.create(c)).ToArray();
            if (!newobject.Any())
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Sory We Can Not Found Any Data");

            }
            else
            {
              
                data.subcategories = Functions.GetSubCategoiesByCategoryID(id).ToList().Select(c => _modal.create(c)).ToList();
                return Request.CreateResponse(HttpStatusCode.OK,data);

            }

        }
    }
}
