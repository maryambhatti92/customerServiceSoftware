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
    [RoutePrefix("api/_Login")]
    public class _LoginController : ApiController
    {
        [HttpGet]
        [Route("GetLoginbyID")]
        public IHttpActionResult GetLoginbyID(int LogintID) // api/_Login/GetLoginbyID?LogintID=1
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            tbl_SequawareLogin LoginData = unitOfWork.Login.Get(LogintID);
            return Ok(LoginData);
        }

        [HttpGet]
        [Route("GetUserViaCompany")]
        public IHttpActionResult GetUserViaCompany(int CompanyID) // api/_Login/GetUserViaCompany?CompanyID=
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            IEnumerable<tbl_SequawareLogin> LoginData = unitOfWork.Login.GetLoginViaCompany(CompanyID);
            return Ok(LoginData);
        }

        [HttpPost]
        [Route("GetLogin")]
        public IHttpActionResult GetLogin(object Model) // api/_Login/GetLogin
        {
            var jsonString = Model.ToString();
            tbl_SequawareLogin loginData = JsonConvert.DeserializeObject<tbl_SequawareLogin>(jsonString);
            IUnitOfWork unitOfWork = new UnitOfWork();
            tbl_SequawareLogin LoginData = unitOfWork.Login.GetLogin(loginData);
            return Ok(LoginData);
        }
        
        [HttpPost]
        [Route("GetDataforForgetPassword")]
        public IHttpActionResult GetDataforForgetPassword (object Model) // api/_Login/GetDataforForgetPassword
        {
            var jsonString = Model.ToString();
            tbl_SequawareLogin loginData = JsonConvert.DeserializeObject<tbl_SequawareLogin>(jsonString);
            IUnitOfWork unitOfWork = new UnitOfWork();
            tbl_SequawareLogin LoginData = unitOfWork.Login.GetDataforForgetPassword(loginData);
            return Ok(LoginData);
        }

        [HttpPost]
        [Route("CreateLogin")]
        public IHttpActionResult CreateLogin(object Model) // api/_Login/CreateLogin
        {
            try
            {
                var jsonString = Model.ToString();
                tbl_SequawareLogin LoginData = JsonConvert.DeserializeObject<tbl_SequawareLogin>(jsonString);

                IUnitOfWork unitOfWork1 = new UnitOfWork();
                tbl_SequawareLogin LoginData1 = unitOfWork1.Login.GetLoginViaUserandCompany(LoginData);
                if (LoginData1 == null)
                { 
                LoginData.isActive = true;
                IUnitOfWork unitOfWork = new UnitOfWork();
                unitOfWork.Login.Add(LoginData);
                unitOfWork.Complete();
                //var newDia = unitOfWork.Diagnosis.GetAll().OrderByDescending(x => x.DiagnosisID).FirstOrDefault();
                // return Ok(newDia);
                return Ok("Successful");
            }
                else
                {
                    return Ok("User already exists");
                }
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
        [Route("UpdateLogin")]
        public IHttpActionResult UpdateLogin(object Model) // api/_Login/UpdateLogin
        {
            try
            {
                var jsonString = Model.ToString();
                tbl_SequawareLogin LoginData = JsonConvert.DeserializeObject<tbl_SequawareLogin>(jsonString);
                IUnitOfWork unitOfWork = new UnitOfWork();


                tbl_SequawareLogin LoginInDb = unitOfWork.Login.Get(LoginData.Id);
                if (LoginInDb == null)
                {
                    return NotFound();
                }
                LoginInDb.UserName = LoginData.UserName;
                LoginInDb.Password = LoginData.Password;
                LoginInDb.Email = LoginData.Email;
                LoginInDb.Company_ID = LoginData.Company_ID;
                LoginInDb.role = LoginData.role;
                LoginInDb.languageID = LoginData.languageID;
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
        [Route("DeleteLogin")]
        public IHttpActionResult DeleteLogin(object Model) // api/_Login/DeleteLogin
        {
            try
            {
                var jsonString = Model.ToString();
                tbl_SequawareLogin LoginData = JsonConvert.DeserializeObject<tbl_SequawareLogin>(jsonString);
                IUnitOfWork unitOfWork = new UnitOfWork();


                tbl_SequawareLogin LoginInDb = unitOfWork.Login.Get(LoginData.Id);
                if (LoginInDb == null)
                {
                    return NotFound();
                }
                LoginInDb.isActive = false;
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
        [Route("UpdateActivationCode")]
        public IHttpActionResult UpdateActivationCode(object Model) // api/_Login/UpdateActivationCode
        {
            try
            {
                var jsonString = Model.ToString();
                tbl_SequawareLogin LoginData = JsonConvert.DeserializeObject<tbl_SequawareLogin>(jsonString);
                IUnitOfWork unitOfWork = new UnitOfWork();


                tbl_SequawareLogin LoginInDb = unitOfWork.Login.GetDataforForgetPassword(LoginData);
                if (LoginInDb == null)
                {
                    return NotFound();
                }               
                LoginInDb.ForgotPasswordCode = LoginData.ForgotPasswordCode;
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

        [HttpGet]
        [Route("GetUserViaAuthenticationCode")]
        public IHttpActionResult GetUserViaAuthenticationCode(string code) // api/_Login/GetUserViaCompany?CompanyID=
        {
           
            IUnitOfWork unitOfWork = new UnitOfWork();
            tbl_SequawareLogin LoginData = unitOfWork.Login.GetDataViaResetCode(code);
            return Ok(LoginData);
        }

        [HttpPost]
        [Route("UpdatePassword")]
        public IHttpActionResult UpdatePassword(object Model) // api/_Login/UpdatePassword
        {
            try
            {
                var jsonString = Model.ToString();
                ResetPasswordModel LoginData = JsonConvert.DeserializeObject<ResetPasswordModel>(jsonString);
                IUnitOfWork unitOfWork = new UnitOfWork();


                tbl_SequawareLogin LoginInDb = unitOfWork.Login.GetDataViaResetCode(LoginData.ResetCode);
                if (LoginInDb == null)
                {
                    return NotFound();
                }
                LoginInDb.Password = LoginData.NewPassword;
                LoginInDb.ForgotPasswordCode = "";

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