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
    [RoutePrefix("api/_Company")]
  //  [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class _CompanyController : ApiController
    {
        [HttpGet]
        [Route("GetAllCompany")]
        public IHttpActionResult GetAllCompany() // api/_Company/GetAllCompany
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            IEnumerable<tbl_Company> CompanyData = unitOfWork.Company.GetAllActiveCompany();
            return Ok(CompanyData);
        }

        [HttpGet]
        [Route("GetCompanyViaID")]
        public IHttpActionResult GetCompanyViaID(int id) // api/_Company/GetCompanyViaID/1
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            tbl_Company CompanyData = unitOfWork.Company.GetCompanyWithId(id);
            return Ok(CompanyData);
        }

        [HttpPost]
        [Route("UpdateCompany")]
        public IHttpActionResult UpdateCompany(object model) // api/_Company/UpdateCompany/1
        {
            try
            {
                var jsonString = model.ToString();
                tbl_Company Companydata = JsonConvert.DeserializeObject<tbl_Company>(jsonString);

                IUnitOfWork unitOfWork = new UnitOfWork();
                tbl_Company CompanyInDb = unitOfWork.Company.Get(Companydata.Company_id);
                if (CompanyInDb == null)
                {
                    return NotFound();
                }
                CompanyInDb.Comapany_Name = Companydata.Comapany_Name;
                CompanyInDb.Address = Companydata.Address;
                CompanyInDb.Email = Companydata.Email;
                CompanyInDb.Phone_Num = Companydata.Phone_Num;
                CompanyInDb.LisceneExpiryDate = Companydata.LisceneExpiryDate;
                CompanyInDb.Liscense = Companydata.Liscense;

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

        [HttpPost]
        [Route("AddCompany")]
        public IHttpActionResult AddCompany(object model) // api/_Company/AddCompany/1
        {
            try
            {
                var jsonString = model.ToString();                
                tbl_Company Companydata = JsonConvert.DeserializeObject<tbl_Company>(jsonString);
                Companydata.isActive = true;

                IUnitOfWork unitOfWorkx = new UnitOfWork();
                tbl_Company CompanyData = unitOfWorkx.Company.GetCompanyWithName(Companydata);

                if (CompanyData == null)
                {

                    IUnitOfWork unitOfWork = new UnitOfWork();
                    unitOfWork.Company.Add(Companydata);
                    unitOfWork.Complete();
                    var newCompany = unitOfWork.Company.GetAll().OrderByDescending(x => x.Company_id).FirstOrDefault();


                    IUnitOfWork unitOfWork10 = new UnitOfWork();
                    IEnumerable<tbl_SampleDepartments> SampleDepartment = unitOfWork10.SampleDepartment.GetAll();
                    foreach (var x in SampleDepartment)
                    {
                        tbl_Departments ObjDepart = new tbl_Departments();
                        ObjDepart.Company_ID = Convert.ToInt32(newCompany.Company_id);
                        ObjDepart.Dep_Name = x.DepartName;
                        ObjDepart.Email = x.Email;
                       

                        IUnitOfWork unitOfWork13 = new UnitOfWork();
                        unitOfWork13.Departments.Add(ObjDepart);
                        unitOfWork13.Complete();
                    }


                    IUnitOfWork unitOfWork11 = new UnitOfWork();
                    IEnumerable<SampleEmailContent> SampleEmail = unitOfWork11.SampleEmail.GetAll();
                    foreach (var x in SampleEmail)
                    {
                        Tbl_EmailContents ObjEmail = new Tbl_EmailContents();
                        ObjEmail.Company_ID = Convert.ToInt32(newCompany.Company_id);
                        ObjEmail.Email_Code = x.Email_Code;
                        ObjEmail.Subject = x.Subject;
                        ObjEmail.Reference = x.Reference;
                        ObjEmail.RMA = x.RMA;
                        ObjEmail.Date = x.Date;
                        ObjEmail.Dear = x.Dear;
                        ObjEmail.Email_text = x.Email_text;
                        ObjEmail.Footer = x.Footer;
                        ObjEmail.Signature = x.Signature;

                        IUnitOfWork unitOfWork12 = new UnitOfWork();
                        unitOfWork12.EmailContent.Add(ObjEmail);
                        unitOfWork12.Complete();
                    }



                    return Ok(newCompany);
                }

                else
                {
                    return Ok("Company already exists");
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
        [Route("DeleteCompany")]
        public IHttpActionResult DeleteCompany(object model) // api/_Company/DeleteCompany/1
        {
            try
            {
                var jsonString = model.ToString();
                tbl_Company Companydata = JsonConvert.DeserializeObject<tbl_Company>(jsonString);

                IUnitOfWork unitOfWork = new UnitOfWork();
                tbl_Company CompanyInDb = unitOfWork.Company.Get(Companydata.Company_id);
                if (CompanyInDb == null)
                {
                    return NotFound();
                }
                CompanyInDb.isActive = false;
                unitOfWork.Complete();

                IUnitOfWork unitOfWork1 = new UnitOfWork();
                IEnumerable< tbl_SequawareLogin >UsersInDb = unitOfWork1.Login.GetLoginViaCompany(Companydata.Company_id);
                foreach (var x in UsersInDb)
                {
                    x.isActive = false;
                }
                unitOfWork1.Complete();

                IUnitOfWork unitOfWork2 = new UnitOfWork();
                IEnumerable<tbl_customer_request> RequestInDb = unitOfWork2.CustomerRequest.GetCustomerRequestViaCompanyID(Companydata.Company_id);
                foreach (var x in RequestInDb)
                {
                    x.isDelete = true;
                }
                unitOfWork2.Complete();


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
        [Route("LicenseRenewal")]
        public IHttpActionResult LicenseRenewal(object model) // api/_Company/LicenseRenewal/1
        {
            try
            {
                var jsonString = model.ToString();
                CompanyLicenseVM Companydata = JsonConvert.DeserializeObject<CompanyLicenseVM>(jsonString);

                IUnitOfWork unitOfWork = new UnitOfWork();
                tbl_Company CompanyInDb = unitOfWork.Company.Get(Companydata.CompanyID);
                if (CompanyInDb == null)
                {
                    return NotFound();
                }
                CompanyInDb.LisceneExpiryDate = Companydata.LicenseDate;
                CompanyInDb.Liscense = Companydata.License;

                unitOfWork.Complete();

                //Archive old license
                if (Companydata.ToArchive == true)
                { 
                IUnitOfWork unitOfWork1 = new UnitOfWork();
                tbl_LicenseHistory oldLicesnse = new tbl_LicenseHistory();
                oldLicesnse.ExpiryDate = Companydata.OldLicenseDate;
                oldLicesnse.Liscense_Num = Companydata.OldLicense;
                oldLicesnse.companyId = Companydata.CompanyID;
                unitOfWork1.LicenseHistory.Add(oldLicesnse);
                unitOfWork1.Complete();                  
                }

               

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
        [Route("GetLicenseViacmpID")]
        public IHttpActionResult GetLicenseViacmpID(int companyID) // api/_Company/GetLicenseViacmpID/1
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
             IEnumerable<tbl_LicenseHistory> LiccenseData = unitOfWork.LicenseHistory.GetLicenseHistoryViaCompany(companyID);
            return Ok(LiccenseData);
        }


    }
}