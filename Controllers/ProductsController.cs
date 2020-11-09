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
    public class ProductsController : ApiController
    {
        ModalFactory _modal = new ModalFactory();
        ProductsData data = new ProductsData();
        // GET api/values


        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.NotFound, "Please enter the Categoy ID in the URL");



        }

    
        [Route("api/products/{categoryID}")]

        public HttpResponseMessage getByCategoryID(int categoryID)
        {
           

       

            var newobject = Functions.GetProductsByCateoryID(categoryID)
                
                
                
                .ToList().Select(c => _modal.create(c)).ToArray();
            if (!newobject.Any())
            {
                data.Error = "Sory We Can Not Found Any Data";
                return Request.CreateResponse(HttpStatusCode.NotFound, data);

            }
            else
            {
                data.products = Functions.GetProductsByCateoryID(categoryID).ToList().Select(c => _modal.create(c)).ToList();
                return Request.CreateResponse(HttpStatusCode.OK,data );

            }

        }


        [Route("api/products/sub/{sub}")]

        public HttpResponseMessage GetBysubID(int sub)
        {
            var newobject = Functions.GetProductsBySubCategoyID(sub).ToList().Select(c => _modal.create(c)).ToArray();
            if (!newobject.Any())
            {
                data.Error = "Sory We Can Not Found Any Data";
                return Request.CreateResponse(HttpStatusCode.NotFound, data);

            }
            else
            {
                data.products = Functions.GetProductsBySubCategoyID(sub).ToList().Select(c => _modal.create(c)).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }

        }



    }
}
