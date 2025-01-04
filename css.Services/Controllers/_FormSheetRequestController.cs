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
    [RoutePrefix("api/_FormSheetRequest")]
    public class _FormSheetRequestController : ApiController
    {

        [HttpPost]
        [Route("CreateFormSheet")]
        public IHttpActionResult CreateFormSheet(object Model) // api/_FormSheetRequest/CreateFormSheet
        {
            try
            {
                
                var jsonString = Model.ToString();
                FormSheetVM FormSheetData = JsonConvert.DeserializeObject<FormSheetVM>(jsonString);
                IUnitOfWork unitOfWork = new UnitOfWork();
                unitOfWork.Customer.Add(FormSheetData.Customer);
                unitOfWork.Complete();
                var NewCustomer = unitOfWork.Customer.GetAll().OrderByDescending(x => x.Customer_id).FirstOrDefault();


                IUnitOfWork unitOfWork1 = new UnitOfWork();
                FormSheetData.Person1.customer_id = NewCustomer.Customer_id ;
                unitOfWork1.ContactPerson.Add(FormSheetData.Person1);
                unitOfWork1.Complete();

                IUnitOfWork unitOfWork2 = new UnitOfWork();
                FormSheetData.Person2.customer_id = NewCustomer.Customer_id;
                unitOfWork2.ContactPerson.Add(FormSheetData.Person2);
                unitOfWork2.Complete();

                IUnitOfWork unitOfWork3 = new UnitOfWork();
                FormSheetData.Request.customer_id = NewCustomer.Customer_id;
                //FormSheetData.Request.status = "1";
                //FormSheetData.Request.priority = "1";
                unitOfWork3.CustomerRequest.Add(FormSheetData.Request);
                unitOfWork3.Complete();

                var NewReq = unitOfWork3.CustomerRequest.GetAll().OrderByDescending(x => x.Request_id).FirstOrDefault();


                return Ok(NewReq);
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
              //  throw raise;
                return Ok("Unsuccessful");
            }

           
        }


        [HttpPost]
        [Route("CreateFormSheetWeb")]
        public IHttpActionResult CreateFormSheetWeb(object Model) // api/_FormSheetRequest/CreateFormSheetWeb
        {
            try
            {

                var jsonString = Model.ToString();
                FormSheetVMWeb FormSheetData = JsonConvert.DeserializeObject<FormSheetVMWeb>(jsonString);
                IUnitOfWork unitOfWork = new UnitOfWork();

                tbl_customer Customer = new tbl_customer();
                Customer.Zipcode = FormSheetData.Zipcode;
                Customer.company = FormSheetData.company;
                Customer.Country = FormSheetData.Country;
                Customer.CustomerRefNo = FormSheetData.ref_num;
                Customer.street = FormSheetData.street;


                tbl_contact_person contact = new tbl_contact_person();
                contact.name = FormSheetData.name;
                contact.email = FormSheetData.email;
                contact.phone = FormSheetData.phone;

                tbl_customer_request request = new tbl_customer_request();
                request.issue = FormSheetData.Issue;
                request.FurtherInformatipn = FormSheetData.FurtherInformatin;
                request.ref_num = FormSheetData.ref_num;
                request.error_description = FormSheetData.reason;
                request.date_added = System.DateTime.Now;
                request.Last_Modified = System.DateTime.Now;
                request.FurtherInformatipn = FormSheetData.FurtherInformatin;
                request.isActive = true;
                request.isDelete = false;
                request.Company_ID = FormSheetData.companyID;
                request.CreatedBy = FormSheetData.CreatedBy;

                unitOfWork.Customer.Add(Customer);
                unitOfWork.Complete();
                var NewCustomer = unitOfWork.Customer.GetAll().OrderByDescending(x => x.Customer_id).FirstOrDefault();


                IUnitOfWork unitOfWork1 = new UnitOfWork();
                contact.customer_id = NewCustomer.Customer_id;
                unitOfWork1.ContactPerson.Add(contact);
                unitOfWork1.Complete();

                

                IUnitOfWork unitOfWork3 = new UnitOfWork();
                request.customer_id = NewCustomer.Customer_id;               
                unitOfWork3.CustomerRequest.Add(request);
                unitOfWork3.Complete();

                var NewReq = unitOfWork3.CustomerRequest.GetAll().OrderByDescending(x => x.Request_id).FirstOrDefault();


                return Ok(NewReq);
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
                //  throw raise;
                return Ok("Unsuccessful");
            }


        }


    }
}