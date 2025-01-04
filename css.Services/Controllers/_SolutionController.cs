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
    [RoutePrefix("api/_Solution")]
    public class _SolutionController : ApiController
    {
        [HttpGet]
        [Route("GetOneSolutionData")]
        public IHttpActionResult GetOneSolutionData(int RequestId) // api/_Solution/GetOneSolutionData
        {
            SolutionVM solutiondata = new SolutionVM();
            IUnitOfWork unitOfWork = new UnitOfWork();
            solutiondata.solution = unitOfWork.Solution.GetSolutionViaRequest(RequestId);
            solutiondata.options  = unitOfWork.SolutionOptions.GetSolutionOptionsViaRequest(RequestId);           
            return Ok(solutiondata);
        }

        [HttpPost]
        [Route("CreateSolutionData")]
        public IHttpActionResult CreateSolutionData(object Model) // api/_Solution/CreateSolutionData
        {
            try
            {
                var jsonString = Model.ToString();
                SolutionVM SolutionData = JsonConvert.DeserializeObject<SolutionVM>(jsonString);
                SolutionData.solution.Email_Sent = 0;
                SolutionData.solution.Email_date = System.DateTime.Now;

                IUnitOfWork unitOfWork = new UnitOfWork();
                unitOfWork.Solution.Add(SolutionData.solution);
                unitOfWork.Complete();
                var newSol = unitOfWork.Solution.GetAll().OrderByDescending(x => x.solution_id).FirstOrDefault();

                IUnitOfWork unitOfWork1 = new UnitOfWork();
                foreach (var x in SolutionData.options)
                {
                    x.solution_id = newSol.solution_id;
                    x.request_id = newSol.request_id;
                }
                unitOfWork1.SolutionOptions.AddRange(SolutionData.options);
                unitOfWork1.Complete();

                IUnitOfWork unitOfWork2 = new UnitOfWork();
                tbl_customer_request RequestInDb = unitOfWork2.CustomerRequest.Get(SolutionData.solution.request_id);
                if (RequestInDb == null)
                {
                    return NotFound();
                }

                RequestInDb.Last_Modified = DateTime.Now;
                unitOfWork2.Complete();

                return Ok(newSol);
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
        [Route("UpdateSolutionData")]
        public IHttpActionResult UpdateSolutionData(object model) // api/_Solution/UpdateSolutionData/1
        {
            try
            {
                var jsonString = model.ToString();
                SolutionVM SolutionData = JsonConvert.DeserializeObject<SolutionVM>(jsonString);

                IUnitOfWork unitOfWork = new UnitOfWork();
                tbl_Solution SolutionInDb = unitOfWork.Solution.Get(SolutionData.solution.solution_id);
                if (SolutionInDb == null)
                {
                    return NotFound();
                }
                SolutionInDb.Notes = SolutionData.solution.Notes;
                SolutionInDb.reminder1 = SolutionData.solution.reminder1;
                SolutionInDb.reminder2 = SolutionData.solution.reminder2;
                SolutionInDb.statement = SolutionData.solution.statement;
                unitOfWork.Complete();

                IUnitOfWork unitOfWork3 = new UnitOfWork();
                IEnumerable<tbl_SolutionOptions> OptionsInDb = unitOfWork3.SolutionOptions.GetSolutionOptionsViaRequest(SolutionData.solution.request_id);
                if (SolutionInDb == null)
                {
                    return NotFound();
                }
                
                // IUnitOfWork unitOfWork1 = new UnitOfWork();
                unitOfWork3.SolutionOptions.RemoveRange(OptionsInDb);
                unitOfWork3.Complete();

                foreach (var x in  SolutionData.options)
                {
                    x.request_id = SolutionData.solution.request_id;
                    x.solution_id = SolutionData.solution.solution_id;
                }

                IUnitOfWork unitOfWork2 = new UnitOfWork();
                unitOfWork2.SolutionOptions.AddRange(SolutionData.options);
                unitOfWork2.Complete();

                IUnitOfWork unitOfWork4 = new UnitOfWork();
                tbl_customer_request RequestInDb = unitOfWork4.CustomerRequest.Get(SolutionData.solution.request_id);
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
        [Route("UpdateSolutionEmail")]
        public IHttpActionResult UpdateSolutionEmail(object model) // api/_Solution/UpdateSolutionEmail/1
        {
            try
            {
                var jsonString = model.ToString();
                tbl_Solution SolutionData = JsonConvert.DeserializeObject<tbl_Solution>(jsonString);

                IUnitOfWork unitOfWork = new UnitOfWork();
                tbl_Solution SolInDb = unitOfWork.Solution.Get(SolutionData.solution_id);
                if (SolInDb == null)
                {
                    return NotFound();
                }

                SolInDb.Email_Sent = SolutionData.Email_Sent;
                SolInDb.Email_date = SolutionData.Email_date;                
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