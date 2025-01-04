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
    [RoutePrefix("api/_Inspection")]
    public class _InspectionController : ApiController
    {
        [HttpGet]
        [Route("GetInspection")]
        public IHttpActionResult GetInspection(int requestId) // api/_Inspection/GetInspection
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            tbl_Inspection InspectionData = unitOfWork.Inspection.GetInspectionViaRequest(requestId);            
            return Ok(InspectionData);
        }

        [HttpPost]
        [Route("CreateInspectionData")]
        public IHttpActionResult CreateInspectionData(object Model) // api/_Inspection/CreateInspectionData
        {
            try
            {
                var jsonString = Model.ToString();
                tbl_Inspection InspectionData = JsonConvert.DeserializeObject<tbl_Inspection>(jsonString);
                IUnitOfWork unitOfWork = new UnitOfWork();
                InspectionData.Email_Sent = 0;
                InspectionData.Email_date = System.DateTime.Now;
                unitOfWork.Inspection.Add(InspectionData);
                unitOfWork.Complete();

                IUnitOfWork unitOfWork1 = new UnitOfWork();
                tbl_customer_request RequestInDb = unitOfWork1.CustomerRequest.Get(InspectionData.RequestId ?? 0);
                if (RequestInDb == null)
                {
                    return NotFound();
                }

                RequestInDb.Last_Modified = DateTime.Now;
                unitOfWork1.Complete();

                var newInsID = unitOfWork.Inspection.GetAll().OrderByDescending(x => x.InspectionID).FirstOrDefault();
                return Ok(newInsID);
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
        [Route("UpdateInspection")]
        public IHttpActionResult UpdateInspection(object model) // api/_Inspection/UpdateInspection/1
        {
            try
            {
                var jsonString = model.ToString();
                tbl_Inspection InspectionData = JsonConvert.DeserializeObject<tbl_Inspection>(jsonString);

                IUnitOfWork unitOfWork = new UnitOfWork();
                tbl_Inspection InspectionInDb = unitOfWork.Inspection.Get(InspectionData.InspectionID);
                if (InspectionInDb == null)
                {
                    return NotFound();
                }
                               
                InspectionInDb.ServiceTask = InspectionData.ServiceTask;
                InspectionInDb.Complaint = InspectionData.Complaint;
                InspectionInDb.Create8DReport = InspectionData.Create8DReport;
                InspectionInDb.createRp = InspectionData.createRp;
                InspectionInDb.ReportDone = InspectionData.ReportDone;
                InspectionInDb.report8DDone = InspectionData.report8DDone;
                InspectionInDb.Department = InspectionData.Department;
                InspectionInDb.Description = InspectionData.Description;
                InspectionInDb.Diagnosis = InspectionData.Diagnosis;
                InspectionInDb.Reason = InspectionData.Reason;
                InspectionInDb.Operator = InspectionData.Operator;

                unitOfWork.Complete();


                IUnitOfWork unitOfWork1 = new UnitOfWork();
                tbl_customer_request RequestInDb = unitOfWork1.CustomerRequest.Get(InspectionData.RequestId ?? 0);
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
        [Route("UpdateInspectionEmail")]
        public IHttpActionResult UpdateInspectionEmail(object model) // api/_Inspection/UpdateInspectionEmail/1
        {
            try
            {
                var jsonString = model.ToString();
                tbl_Inspection InspectionData = JsonConvert.DeserializeObject<tbl_Inspection>(jsonString);

                IUnitOfWork unitOfWork = new UnitOfWork();
                tbl_Inspection InsInDb = unitOfWork.Inspection.Get(InspectionData.InspectionID);
                if (InsInDb == null)
                {
                    return NotFound();
                }

                InsInDb.Email_Sent = InspectionData.Email_Sent;
                InsInDb.Email_date = InspectionData.Email_date;
               // InsInDb.Confirmation = "Yes";
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

        [HttpGet]
        [Route("GetInspectionEmailData")]
        public IHttpActionResult GetInspectionEmailData(int requestId) // api/_Inspection/GetInspectionEmailData
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            tbl_Inspection InspectionData = unitOfWork.Inspection.GetInspectionViaRequest(requestId);

            if (InspectionData != null)
            {
                tbl_ServiceTask Servicedata = new tbl_ServiceTask();
                IUnitOfWork unitOfWork1 = new UnitOfWork();
                Servicedata = unitOfWork1.ServiceTask.GetOneServiceTasks(InspectionData.ServiceTask ?? 0);
                InspectionData.Operator = Servicedata.Categories;

                tbl_Departments departmentData = new tbl_Departments();
                IUnitOfWork unitOfWork2 = new UnitOfWork();
                departmentData = unitOfWork2.Departments.GetOneDepartment(InspectionData.Department ?? 0);
                InspectionData.Complaint = departmentData.Dep_Name;
                InspectionData.report8DDone = departmentData.Email;
            }

            return Ok(InspectionData);


          
        }       

    }
}
