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
    [RoutePrefix("api/_ServiceTask")]
    public class _ServiceTaskController : ApiController
    {
        [HttpGet]
        [Route("GetAllServiceTask")]
        public IHttpActionResult GetAllServiceTask() // api/_ServiceTask/GetAllServiceTask
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            IEnumerable<tbl_ServiceTask> ServiceData = unitOfWork.ServiceTask.GetActiveServiceTasks();
            return Ok(ServiceData);
        }

        [HttpPost]
        [Route("CreateServiceTask")]
        public IHttpActionResult CreateServiceTask(object Model) // api/_ServiceTask/CreateServiceTask
        {
            try
            {
                var jsonString = Model.ToString();
                tbl_ServiceTask ServiceTaskData = JsonConvert.DeserializeObject<tbl_ServiceTask>(jsonString);
                IUnitOfWork unitOfWork = new UnitOfWork();
                unitOfWork.ServiceTask.Add(ServiceTaskData);
                unitOfWork.Complete();
                var newService = unitOfWork.ServiceTask.GetAll().OrderByDescending(x => x.DiagnosisCatID).FirstOrDefault();
                return Ok(newService);
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