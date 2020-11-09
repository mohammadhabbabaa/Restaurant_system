using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ApiConnect;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class OrdersController : ApiController
    {
        ModalFactory _modal = new ModalFactory();
        OrdersData data = new OrdersData();
        private OrderEntities db = new OrderEntities();

        // GET: api/Orders
        public HttpResponseMessage GetOrders()
        {
            data.orders =
            Functions.Getorders().ToList().
                  Select(c => _modal.create(c)
                  ).ToList();
                return Request.CreateResponse(HttpStatusCode.OK,data
                   
                    );
           
        }

        // GET: api/Orders/5
        [Route("api/orders/{Tableid}")]
        [ResponseType(typeof(Order))]
        public HttpResponseMessage GetOrder(int Tableid)
        {

            data.orders = Functions.Getorders(Tableid).ToList().
                  Select(c => _modal.create(c)
                  ).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, data

                  );
        }

        // PUT: api/Orders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrder(int id, Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.ID)
            {
                return BadRequest();
            }

            db.Entry(order).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


        public IHttpActionResult PostOrder(Order order)
        {
            using (OrderEntities db = new OrderEntities())
            {

            db.Orders.Add(order);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = order.ID }, order);
            }
        }

        [HttpPost]
        [Route("api/hesap/{Tableid}")]
         public HttpResponseMessage Hesap(int Tableid)
        {
             Table newTable = new Table();
                newTable = db.Tables.Find(Tableid);
                newTable.Account = 1;

                db.Entry(newTable).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(Tableid))
                    {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
                }
                    else
                    {
                        throw;
                    }
                }
            var data =  new{
            data ="added"
            };
        
            return Request.CreateResponse(HttpStatusCode.OK,
                Newtonsoft.Json.JsonConvert.SerializeObject(data)
                    );

        }

        [HttpPost]
        [Route("api/masa/{Tableid}")]
        public HttpResponseMessage Masa(int Tableid)
        {
            Table newTable = new Table();
            newTable = db.Tables.Find(Tableid);
            newTable.Booked = 1;

            db.Entry(newTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(Tableid))
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
                }
                else
                {
                    throw;
                }
            }
            var data = new
            {
                data = "added"
            };

            return Request.CreateResponse(HttpStatusCode.OK,
                Newtonsoft.Json.JsonConvert.SerializeObject(data)
                    );

        }
        // DELETE: api/Orders/5
        [HttpDelete]
        [Route("api/orders/delete/{Orderid}")]
        [ResponseType(typeof(Order))]
        public IHttpActionResult DeleteOrder(int Orderid)
        {
            Order order = db.Orders.Find(Orderid);
            if (order == null)
            {
                return NotFound();
            }

            db.Orders.Remove(order);
            db.SaveChanges();

            return Ok(order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderExists(int id)
        {
            return db.Orders.Count(e => e.ID == id) > 0;
        }
    }
}