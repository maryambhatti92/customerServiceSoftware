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
    [RoutePrefix("api/_Reason")]
    public class _ReasonController : ApiController
    {
        [HttpGet]
        [Route("GetAllReason")]
        public IHttpActionResult GetAllReason() // api/_Reason/GetAllReason
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            IEnumerable<tbl_Reason> ReasonData = unitOfWork.Reason.GetAll();
            return Ok(ReasonData);
        }

        [HttpPost]
        [Route("CreateReason")]
        public IHttpActionResult CreateReason(object Model) // api/_Reason/CreateReason
        {
            try
            {
                var jsonString = Model.ToString();
                tbl_Reason ReasonData = JsonConvert.DeserializeObject<tbl_Reason>(jsonString);
                IUnitOfWork unitOfWork = new UnitOfWork();
                unitOfWork.Reason.Add(ReasonData);
                unitOfWork.Complete();
                var newReason = unitOfWork.Reason.GetAll().OrderByDescending(x => x.ReasonID).FirstOrDefault();
                return Ok(newReason);
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