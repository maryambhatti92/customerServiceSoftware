using css.Data.Models;
using css.Repository;
using css.Repository.Interfaces;
using css.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;

namespace css.Services.Controllers
{
    [RoutePrefix("api/_OrderData")]
    public class _OrderDataController : ApiController
    {
        // GET: _CustomerRequest
        [HttpGet]
        [Route("GetOneOrderData")]
        public IHttpActionResult GetOneOrderData(int RequestId) // api/_OrderData/GetOneOrderData
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            tbl_OrderData OrderData = unitOfWork.OrderData.GetOrderViaRequest(RequestId);
            return Ok(OrderData);
        }

        [HttpPost]
        [Route("CreateOrderData")]
        public IHttpActionResult CreateOrderData(object Model) // api/_OrderData/CreateOrderData
        {
            try
            {
                var jsonString = Model.ToString();
                tbl_OrderData OrderData = JsonConvert.DeserializeObject<tbl_OrderData>(jsonString);
                OrderData.Email_Sent = 0;
                OrderData.Email_date = System.DateTime.Now;
                IUnitOfWork unitOfWork = new UnitOfWork();
                unitOfWork.OrderData.Add(OrderData);
                unitOfWork.Complete();
                var newORd= unitOfWork.OrderData.GetAll().OrderByDescending(x => x.Order_id).FirstOrDefault();

                IUnitOfWork unitOfWork1 = new UnitOfWork();
                tbl_customer_request RequestInDb = unitOfWork1.CustomerRequest.Get(OrderData.Request_id ?? 0);
                if (RequestInDb == null)
                {
                    return NotFound();
                }
               
                RequestInDb.Last_Modified = DateTime.Now;
                unitOfWork1.Complete();

                return Ok(newORd);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        [HttpPut]
        [Route("UpdateOrderData")]
        public IHttpActionResult UpdateOrderData(object model) // api/_OrderData/UpdateOrderData/1
        {
            try
            {
                var jsonString = model.ToString();
                tbl_OrderData OrderData = JsonConvert.DeserializeObject<tbl_OrderData>(jsonString);

                IUnitOfWork unitOfWork = new UnitOfWork();
                tbl_OrderData OrderInDb = unitOfWork.OrderData.Get(OrderData.Order_id);
                if (OrderInDb == null)
                {
                    return NotFound();
                }

                OrderInDb.Confirmation = OrderData.Confirmation;
                OrderInDb.CustomerNumber_FrmSheet = OrderData.CustomerNumber_FrmSheet;
                OrderInDb.CustomerNumber_Org = OrderData.CustomerNumber_Org;
                OrderInDb.DeliveryDate = OrderData.DeliveryDate;
              //  OrderInDb.Email_Sent = OrderData.Email_Sent;
                OrderInDb.OrginalOrderNumber = OrderData.OrginalOrderNumber;
                OrderInDb.Orignal_Quantity = OrderData.Orignal_Quantity;
                OrderInDb.Quantity = OrderData.Quantity;
                OrderInDb.Waranty = OrderData.Waranty;
                OrderInDb.product = OrderData.product;                
                unitOfWork.Complete();

                IUnitOfWork unitOfWork1 = new UnitOfWork();
                tbl_customer_request RequestInDb = unitOfWork1.CustomerRequest.Get(OrderData.Request_id ?? 0);
                if (RequestInDb == null)
                {
                    return NotFound();
                }

                RequestInDb.Last_Modified = DateTime.Now;
                unitOfWork1.Complete();

                return Ok("Successful");
            }

            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        [HttpPut]
        [Route("UpdateOrderEmail")]
        public IHttpActionResult UpdateOrderEmail(object model) // api/_OrderData/UpdateOrderEmail/1
        {
            try
            {
                var jsonString = model.ToString();
                tbl_OrderData OrderData = JsonConvert.DeserializeObject<tbl_OrderData>(jsonString);

                IUnitOfWork unitOfWork = new UnitOfWork();
                tbl_OrderData OrderInDb = unitOfWork.OrderData.Get(OrderData.Order_id);
                if (OrderInDb == null)
                {
                    return NotFound();
                }

                OrderInDb.Email_Sent = OrderData.Email_Sent;
                OrderInDb.Email_date = OrderData.Email_date;
                OrderInDb.Confirmation = "Yes";
                unitOfWork.Complete();

                return Ok("Successful");
            }

            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }


    }
}