using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiConnect;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CategoriesController : ApiController
    {
        ModalFactory _modal = new ModalFactory();
        OrderEntities db = new OrderEntities();



        // GET api/values
        public HttpResponseMessage  Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, GetCategoryies.GetAllCategory().ToList().Select(c => _modal.create(c)));
        }

        // GET api/values/RestourantID
        [Route("api/Categories/{masaid}")]
        public HttpResponseMessage Get(int masaid)
        {
            OrderEntities db = new OrderEntities();

            string id = db.Tables.Where(e => e.ID == masaid).Select(e => e.RestourantID).SingleOrDefault().ToString() ;

            CategoriedData data = new CategoriedData();
            if (id==null || id=="")
            {
                data.Error = "Sory We Can Not Found Any Data";
                return Request.CreateResponse(HttpStatusCode.NotFound, data);

            }
            else
            {


                var newobject = GetCategoryies.GetAllCategoryByRestourantID(int.Parse(id)).ToList().Select(c => _modal.create(c)).ToArray();
                if (!newobject.Any())
                {
                    data.Error = "Sory We Can Not Found Any Data";
                    return Request.CreateResponse(HttpStatusCode.NotFound, data);

                }
                else
                {



                    data.categories = GetCategoryies.GetAllCategoryByRestourantID(int.Parse(id)).ToList().Select(c => _modal.create(c)).ToList();


                    return Request.CreateResponse(HttpStatusCode.OK, data);


                }
            }

          

        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }



    }
}
