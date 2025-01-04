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
    [RoutePrefix("api/_Email")]
    public class _EmailController : ApiController
    {
        [HttpGet]
        [Route("GetEmailContent")]
        public IHttpActionResult GetEmailContent(string Code, int companyID, int LangID) // api/_Email/GetEmailContent
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            Tbl_EmailContents EmailData = unitOfWork.EmailContent.GetEmailwithCode(Code, companyID,  LangID);
            return Ok(EmailData);
        }

        [HttpPut]
        [Route("UpdateEmailContent")]
        public IHttpActionResult UpdateEmailContent(object model) // api/_Email/UpdateEmailContent/1
        {
            try
            {
                var jsonString = model.ToString();
                Tbl_EmailContents EmailData = JsonConvert.DeserializeObject<Tbl_EmailContents>(jsonString);
                
                IUnitOfWork unitOfWork = new UnitOfWork();
                Tbl_EmailContents EmailInDb = unitOfWork.EmailContent.GetEmailwithCode(EmailData.Email_Code, EmailData.Company_ID ?? 0, EmailData.LanguageID ?? 1);
                
                if (EmailInDb == null)
                {
                    return NotFound();
                }

               // EmailInDb.Date = EmailData.Date;
               // EmailInDb.Dear = EmailData.Dear;
                EmailInDb.Email_text = EmailData.Email_text;
                EmailInDb.Footer = EmailData.Footer;
               // EmailInDb.Reference = EmailData.Reference;
               // EmailInDb.RMA = EmailData.RMA;
                EmailInDb.Signature = EmailData.Signature;
                

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