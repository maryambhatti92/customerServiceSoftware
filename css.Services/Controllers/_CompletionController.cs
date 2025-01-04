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
using System.Web.Http.Cors;



namespace css.Services.Controllers
{ 
    [RoutePrefix("api/_Completion")]
    public class _CompletionController : ApiController
    {
        [HttpGet]
        [Route("GetOneCompletionData")]
        public IHttpActionResult GetOneCompletionData(int RequestId) // api/_Completion/GetOneCompletionData
        {
            tbl_Completion Completiondata = new tbl_Completion();
            IUnitOfWork unitOfWork = new UnitOfWork();
            Completiondata = unitOfWork.Completion.GetCompletionViaRequest(RequestId);           
            return Ok(Completiondata);
        }

        [HttpPost]
        [Route("CreateCompletionData")]
        public IHttpActionResult CreateCompletionData(object Model) // api/_Completion/CreateCompletionData
        {
            try
            {
                var jsonString = Model.ToString();
                tbl_Completion CompletionData = JsonConvert.DeserializeObject<tbl_Completion>(jsonString);
                              
                IUnitOfWork unitOfWork = new UnitOfWork();
                unitOfWork.Completion.Add(CompletionData);
                unitOfWork.Complete();

                IUnitOfWork unitOfWork4 = new UnitOfWork();
                tbl_customer_request RequestInDb = unitOfWork4.CustomerRequest.Get(CompletionData.request_id ?? 0);
                if (RequestInDb == null)
                {
                    return NotFound();
                }

                RequestInDb.Last_Modified = DateTime.Now;
                unitOfWork4.Complete();

                var newCompletion = unitOfWork.Completion.GetAll().OrderByDescending(x => x.Completion_id).FirstOrDefault();
                return Ok(newCompletion);
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
        [Route("UpdateCompletionData")]
        public IHttpActionResult UpdateCompletionData(object model) // api/_Completion/UpdateCompletionData/1
        {
            try
            {
                var jsonString = model.ToString();
                tbl_Completion CompletionData = JsonConvert.DeserializeObject<tbl_Completion>(jsonString);

                IUnitOfWork unitOfWork = new UnitOfWork();
                tbl_Completion CompletionInDb = unitOfWork.Completion.Get(CompletionData.Completion_id);
                if (CompletionInDb == null)
                {
                    return NotFound();
                }
                CompletionInDb.order_number = CompletionData.order_number;
                CompletionInDb.credite_note_number = CompletionData.credite_note_number;
                CompletionInDb.Disposal = CompletionData.Disposal;
                CompletionInDb.order_number = CompletionData.order_number;
                //CompletionInDb.Evaluation_Request = CompletionData.Evaluation_Request;
                //CompletionInDb.Availability = CompletionData.Availability;
                //CompletionInDb.Professional_Competence = CompletionData.Professional_Competence;
                //CompletionInDb.Reaction_Time = CompletionData.Reaction_Time;
                //CompletionInDb.Kindness = CompletionData.Kindness;
                //CompletionInDb.Text = CompletionData.Text;

                unitOfWork.Complete();

                IUnitOfWork unitOfWork4 = new UnitOfWork();
                tbl_customer_request RequestInDb = unitOfWork4.CustomerRequest.Get(CompletionData.request_id ?? 0);
                if (RequestInDb == null)
                {
                    return NotFound();
                }

                RequestInDb.Last_Modified = DateTime.Now;
                unitOfWork4.Complete();



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
        [Route("UpdateCompletionEmail")] //not done yet - order 5
        public IHttpActionResult UpdateCompletionEmail(object model) // api/_Completion/UpdateCompletionEmail/1
        {
            try
            {
                var jsonString = model.ToString();
                tbl_Completion CompletionData = JsonConvert.DeserializeObject<tbl_Completion>(jsonString);

                IUnitOfWork unitOfWork = new UnitOfWork();
                tbl_Completion SolInDb = unitOfWork.Completion.Get(CompletionData.Completion_id);
                if (SolInDb == null)
                {
                    return NotFound();
                }

                SolInDb.Email_Sent = CompletionData.Email_Sent;
                SolInDb.Email_date = CompletionData.Email_date;
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
        
        [HttpPut]
        [Route("UpdateCompletionEvaluation")] //not done yet - order 5
        public IHttpActionResult UpdateCompletionEvaluation(object model) // api/_Completion/UpdateCompletionEvaluation/1
        {
            try
            {
                var jsonString = model.ToString();
                tbl_Completion CompletionData = JsonConvert.DeserializeObject<tbl_Completion>(jsonString);
                if (CompletionData.Availability != null && CompletionData.Professional_Competence != null && CompletionData.Reaction_Time != null && CompletionData.Kindness != null && CompletionData.Text != null  )

                { 
                IUnitOfWork unitOfWork = new UnitOfWork();
                tbl_Completion CompInDb = unitOfWork.Completion.Get(CompletionData.Completion_id);
                if (CompInDb == null)
                {
                    return NotFound();
                }

                CompInDb.Availability = CompletionData.Availability;
                CompInDb.Professional_Competence = CompletionData.Professional_Competence;
                CompInDb.Reaction_Time = CompletionData.Reaction_Time;
                CompInDb.Kindness = CompletionData.Kindness;
                CompInDb.Text = CompletionData.Text;
                unitOfWork.Complete();

                return Ok("Successful");
            }
                return Ok("UnSuccessful");

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