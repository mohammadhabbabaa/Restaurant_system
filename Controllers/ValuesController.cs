using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiConnect;
using WebApi.Models;


namespace WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        ModalFactory _modal;
        public ValuesController()
        {
            _modal = new ModalFactory();


        }
      
        // GET api/values
        public IEnumerable<CategoyModal> Get()
        {
        return  GetCategoryies.GetAllCategory().ToList().Select(c => _modal.create(c));
        }

        // GET api/values/5
        public IEnumerable<CategoyModal> Get(int id)
        {

            return GetCategoryies.GetAllCategoryByRestourantID(id).ToList().Select(c => _modal.create(c));
            
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
