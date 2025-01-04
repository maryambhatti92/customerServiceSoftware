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
    [RoutePrefix("api/_Issue")]
    public class _IssueController : ApiController
    {
        [HttpGet]
        [Route("GetAllIssues")]
        public IHttpActionResult GetAllIssues(int LanguageID) // api/_Issue/GetAllIssues?LanguageID=
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            IEnumerable<tbl_ProblemDescriptionIssue> IssueData = unitOfWork.Issue.GetIssueViaLanguage(LanguageID);
            return Ok(IssueData);
        }

    }
}