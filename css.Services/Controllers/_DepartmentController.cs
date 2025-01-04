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
    [RoutePrefix("api/_Department")]
    public class _DepartmentController : ApiController
    {

        [HttpGet]
        [Route("GetDepartmentbyID")]
        public IHttpActionResult GetDepartmentbyID(int deptID) // api/_Department/GetDepartmentbyID?deptID=1
        {
           IUnitOfWork unitOfWork = new UnitOfWork();
           tbl_Departments DepData = unitOfWork.Departments.Get(deptID);
            return Ok(DepData);
        }

        [HttpGet]
        [Route("GetDepartmentbyCompanyID")]
       public IHttpActionResult GetDepartmentbyCompanyID(int CompanyID, int Lang) // api/_Department/GetDepartmentbyCompanyID?CompanyID=1
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            IEnumerable<tbl_Departments> DepData = unitOfWork.Departments.GetDepartViaCompany(CompanyID,Lang);
            return Ok(DepData);
        }

        [HttpGet]
        [Route("GetDepartment")]
        public IHttpActionResult GetDepartment() // api/_Department/GetDepartment
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            IEnumerable<tbl_Departments> DepData = unitOfWork.Departments.GetAll();
            return Ok(DepData);
        }
        [HttpPost]
        [Route("CreateDepartment")]
        public IHttpActionResult CreateDepartment(object Model) // api/_Department/CreateDepartment
        {
            try
            {
                var jsonString = Model.ToString();
                tbl_Departments DepartmentData = JsonConvert.DeserializeObject<tbl_Departments>(jsonString);
                IUnitOfWork unitOfWork = new UnitOfWork();
                unitOfWork.Departments.Add(DepartmentData);
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
        [Route("UpdateDepartment")]
        public IHttpActionResult UpdateDepartment(object Model) // api/_Department/UpdateDepartment
        {
            try
            {
                var jsonString = Model.ToString();
                tbl_Departments DepartData = JsonConvert.DeserializeObject<tbl_Departments>(jsonString);
                IUnitOfWork unitOfWork = new UnitOfWork();


                tbl_Departments DepartmentInDb = unitOfWork.Departments.Get(DepartData.DepartmentID);
                if (DepartmentInDb == null)
                {
                    return NotFound();
                }
                DepartmentInDb.Dep_Name = DepartData.Dep_Name;
                DepartmentInDb.Email = DepartData.Email;
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
        [Route("DeleteDepartment")]
        public IHttpActionResult DeleteDepartment(object Model) // api/_Department/DeleteDepartment
        {
            try
            {
                var jsonString = Model.ToString();
                tbl_Departments DepartData = JsonConvert.DeserializeObject<tbl_Departments>(jsonString);
                IUnitOfWork unitOfWork = new UnitOfWork();


                tbl_Departments DepartmentInDb = unitOfWork.Departments.Get(DepartData.DepartmentID);
                if (DepartmentInDb == null)
                {
                    return NotFound();
                }
                unitOfWork.Departments.Remove(DepartmentInDb);
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

    }
}