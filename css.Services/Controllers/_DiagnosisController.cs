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
    [RoutePrefix("api/_Diagnosis")]
    public class _DiagnosisController : ApiController
    {
        [HttpGet]
        [Route("GetAllDiagnosis")]
        public IHttpActionResult GetAllDiagnosis(int companyID) // api/_Diagnosis/GetAllDiagnosis
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            IEnumerable<tbl_Diagnosis> DiagnosisData = unitOfWork.Diagnosis.GetDiagnosisCompanyVise(companyID);
            return Ok(DiagnosisData);
        }

        [HttpPost]
        [Route("CreateDiagnosis")]
        public IHttpActionResult CreateDiagnosis(object Model) // api/_Diagnosis/CreateDiagnosis
        {
            try
            {
                var jsonString = Model.ToString();
                tbl_Diagnosis DiagnosisData = JsonConvert.DeserializeObject<tbl_Diagnosis>(jsonString);
                IUnitOfWork unitOfWork = new UnitOfWork();
                unitOfWork.Diagnosis.Add(DiagnosisData);
                unitOfWork.Complete();
                //var newDia = unitOfWork.Diagnosis.GetAll().OrderByDescending(x => x.DiagnosisID).FirstOrDefault();
                // return Ok(newDia);
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

        [HttpPost]
        [Route("DelteDiagnosis")]
        public IHttpActionResult DelteDiagnosis(object Model) // api/_Diagnosis/DelteDiagnosis
        {
            try
            {
                var jsonString = Model.ToString();
                tbl_Diagnosis DiagnosisData = JsonConvert.DeserializeObject<tbl_Diagnosis>(jsonString);                

                IUnitOfWork unitOfWork = new UnitOfWork();
                IEnumerable<tbl_Inspection> InsInDb = unitOfWork.Inspection.GetInspectionViaDiagnosis(DiagnosisData.DiagnosisID);
                if (InsInDb != null)
                {
                   if(InsInDb.Count() == 0)
                    {
                        IUnitOfWork unitOfWork1 = new UnitOfWork();
                        tbl_Diagnosis DiagnosisInDb = unitOfWork1.Diagnosis.Get(DiagnosisData.DiagnosisID);

                        DiagnosisInDb.isdelete = true;
                        unitOfWork1.Complete();
                        return Ok("Successful");
                    }
                }
               
                // InsInDb.Confirmation = "Yes";
               return Ok("Diagnosis cannot be delete, It is used in Inspection");                
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