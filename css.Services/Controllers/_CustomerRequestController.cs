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
    [RoutePrefix("api/_CustomerRequest")]
    public class _CustomerRequestController : ApiController
    {

        string connectionString = ConfigurationManager.ConnectionStrings["CssDbConnection"].ConnectionString;
        // GET: _CustomerRequest
        [HttpGet]
        [Route("GetAllCustomerRequests")]
        public IHttpActionResult GetAllCustomerRequests() // api/_CustomerRequest/GetAllCustomerRequests
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            IEnumerable<tbl_customer_request> custRequest = unitOfWork.CustomerRequest.GetAll();
            return Ok(custRequest);
        }


        [HttpGet]
        [Route("GetMainRequest")]
        public IHttpActionResult GetMainRequest(int CompanyID) // api/_CustomerRequest/GetMainRequest
        {
            MainDataVM basicdatavm;
            List<MainDataVM> listmaindata = new List<MainDataVM>();
            tbl_contact_person contactOne = new tbl_contact_person();
            tbl_contact_person contactTwo = new tbl_contact_person();
            IUnitOfWork unitOfWork = new UnitOfWork();
            DataTable custRequest = unitOfWork.CustomerRequest.GetMainDatadb(connectionString, CompanyID);
            if (custRequest != null)
            {
                if (custRequest.Rows.Count > 0)
                {
                    foreach (DataRow dtRow in custRequest.Rows)
                    {
                        

                        basicdatavm = new MainDataVM();
                        basicdatavm.Case = dtRow["Case"].ToString();
                        basicdatavm.Prioritisation = dtRow["Priority"].ToString();
                        basicdatavm.Status = dtRow["Status"].ToString();
                        basicdatavm.Company = dtRow["Company"].ToString();
                        basicdatavm.ServiceReason = dtRow["Service Reason"].ToString();
                        basicdatavm.Date = dtRow["Date"].ToString();
                        basicdatavm.ID = Convert.ToInt32(dtRow["ID"].ToString());
                        basicdatavm.File = dtRow["File"].ToString();
                        basicdatavm.LastModified = dtRow["Last_Modified"].ToString();
                        basicdatavm.Request_id = Convert.ToInt32(dtRow["Request_id"]);
                        basicdatavm.Manager = dtRow["Manager"].ToString();
                        basicdatavm.Product = dtRow["product"].ToString();
                        basicdatavm.CreatedBy = dtRow["CreatedBy"].ToString();
                        listmaindata.Add(basicdatavm);

                    }


                }

            }

            return Ok(listmaindata);
        }

        [HttpGet]
        [Route("GetArchiveRequest")]
        public IHttpActionResult GetArchiveRequest(int companyID) // api/_CustomerRequest/GetArchiveRequest
        {
            sp_GetArchiveGriddata_Result basicdatavm;
            List<sp_GetArchiveGriddata_Result> listmaindata = new List<sp_GetArchiveGriddata_Result>();            
            IUnitOfWork unitOfWork = new UnitOfWork();
            DataTable ArchiveRequest = unitOfWork.CustomerRequest.GetArchiveDatadb(connectionString, companyID);
            if (ArchiveRequest != null)
            {
                if (ArchiveRequest.Rows.Count > 0)
                {
                    foreach (DataRow dtRow in ArchiveRequest.Rows)
                    {


                        basicdatavm = new sp_GetArchiveGriddata_Result();
                        basicdatavm.Case = Convert.ToInt32(dtRow["Case"]);
                        if (!(dtRow["Priority"] is DBNull))
                        {
                            basicdatavm.priority = dtRow["Priority"].ToString();
                        }
                        if (!(dtRow["Status"] is DBNull))
                        {
                            basicdatavm.Status = dtRow["Status"].ToString();
                        }
                        if (!(dtRow["Company"] is DBNull))
                        {
                            basicdatavm.Company = dtRow["Company"].ToString();
                        }
                        if (!(dtRow["Service Reason"] is DBNull))
                        {                            
                                basicdatavm.Service_Reason = dtRow["Service Reason"].ToString();                            
                        }
                        if (!(dtRow["Date"] is DBNull))
                        {
                            basicdatavm.Date = Convert.ToDateTime(dtRow["Date"]);
                        }

                        if (!(dtRow["ID"] is DBNull))
                        {
                            basicdatavm.ID = Convert.ToInt32(dtRow["ID"].ToString());
                        }
                        basicdatavm.File = dtRow["File"].ToString();
                        if (!(dtRow["Last_Modified"] is DBNull))
                        {
                            basicdatavm.Last_Modified = Convert.ToDateTime(dtRow["Last_Modified"]);
                        }
                        if (!(dtRow["Request_id"] is DBNull))
                        {
                            basicdatavm.Request_id = Convert.ToInt32(dtRow["Request_id"]);
                        }

                        if (!(dtRow["Company"] is DBNull))
                        {
                            basicdatavm.Company = dtRow["Company"].ToString();
                        }
                        if (!(dtRow["street"] is DBNull))
                        {
                            basicdatavm.street = dtRow["street"].ToString();
                        }
                        if (!(dtRow["Zipcode"] is DBNull))
                        {
                            basicdatavm.Zipcode = dtRow["Zipcode"].ToString();
                        }
                        if (!(dtRow["Country"] is DBNull))
                        {
                            basicdatavm.Country = dtRow["Country"].ToString();
                        }

                        var x = dtRow["Order_id"].ToString();
                        if (dtRow["Order_id"].ToString() != "")
                        {
                            basicdatavm.Order_id = Convert.ToInt32(dtRow["Order_id"]);
                            if (!(dtRow["Quantity"] is DBNull))                              
                            {
                                basicdatavm.Quantity = Convert.ToInt32(dtRow["Quantity"]);
                            }
                            if (!(dtRow["Orignal_Quantity"] is DBNull))
                            {
                                basicdatavm.Orignal_Quantity = Convert.ToInt32(dtRow["Orignal_Quantity"]);
                            }
                            if (!(dtRow["DeliveryDate"] is DBNull))
                            {
                                basicdatavm.DeliveryDate = Convert.ToDateTime(dtRow["DeliveryDate"]);
                            }
                        }
                        else
                        {
                            basicdatavm.Order_id = 0;
                            basicdatavm.Quantity = 0;
                            basicdatavm.Orignal_Quantity = 0;
                        }


                     //   var y = dtRow["Completion_id"].ToString();
                        if (dtRow["Completion_id"].ToString() != "")
                        {
                            if (!(dtRow["Availability"] is DBNull))
                            {
                                basicdatavm.Availability = Convert.ToInt32(dtRow["Availability"]);
                            }
                            if (!(dtRow["Professional_Competence"] is DBNull))
                            {
                                basicdatavm.Professional_Competence = Convert.ToInt32(dtRow["Professional_Competence"]);
                            }
                            if (!(dtRow["Kindness"] is DBNull))
                            {
                                basicdatavm.Kindness = dtRow["Kindness"].ToString();
                            }
                            if (!(dtRow["Reaction_Time"] is DBNull))
                            {
                                basicdatavm.Reaction_Time = Convert.ToInt16(dtRow["Reaction_Time"]);
                            }
                        }
                        else
                        {
                            basicdatavm.Availability = 0;
                            basicdatavm.Professional_Competence = 0;
                            basicdatavm.Kindness = "0";
                            basicdatavm.Reaction_Time = 0;
                        }


                        basicdatavm.OrginalOrderNumber = dtRow["OrginalOrderNumber"].ToString();
                        basicdatavm.Waranty = dtRow["Waranty"].ToString();
                        


                        basicdatavm.Dep_Name = dtRow["Dep_Name"].ToString();
                        basicdatavm.Operator = dtRow["Operator"].ToString();
                        basicdatavm.Complaint = dtRow["Complaint"].ToString();
                        basicdatavm.Categories = dtRow["Categories"].ToString();
                        basicdatavm.Reason1 = dtRow["Reason1"].ToString();
                        basicdatavm.Diagnosis1 = dtRow["Diagnosis1"].ToString();

                        listmaindata.Add(basicdatavm);

                    }


                }

            }

            return Ok(listmaindata);
        }

        [HttpPut]
        [Route("UpdateBasicManager")]
        public IHttpActionResult UpdateBasicManager(object model) // api/_CustomerRequest/UpdateBasicManager/1
        {
            var jsonString = model.ToString();
            tbl_customer_request custReq = JsonConvert.DeserializeObject<tbl_customer_request>(jsonString);

            IUnitOfWork unitOfWork = new UnitOfWork();
            tbl_customer_request RequestInDb = unitOfWork.CustomerRequest.Get(custReq.Request_id);
            if (RequestInDb == null)
            {
                return NotFound();
            }

            RequestInDb.worker = custReq.worker;
            RequestInDb.status = custReq.status;
            RequestInDb.priority = custReq.priority;
            unitOfWork.Complete();

            return Ok("Successful");
        }

        [HttpPut]
        [Route("UpdateBasicInformation")]
        public IHttpActionResult UpdateBasicInformation(object model) // api/_CustomerRequest/UpdateBasicManager/1
        {
            var jsonString = model.ToString();
            BasicInformation custReq = JsonConvert.DeserializeObject<BasicInformation>(jsonString);

            IUnitOfWork unitOfWork = new UnitOfWork();
            tbl_customer_request RequestInDb = unitOfWork.CustomerRequest.Get(custReq.request_id);
            if (RequestInDb == null)
            {
                return NotFound();
            }

            RequestInDb.worker = custReq.worker;
            RequestInDb.status = custReq.status;
            RequestInDb.priority = custReq.priority;
            unitOfWork.Complete();

            IUnitOfWork unitOfWork1 = new UnitOfWork();
            tbl_customer_request CustReqIndb = unitOfWork1.CustomerRequest.Get(custReq.request_id);                       
            CustReqIndb.Last_Modified = DateTime.Now;
            unitOfWork1.Complete();

            return Ok("Successful");
        }

        [HttpPut]
        [Route("ArchiveServiceCase")]
        public IHttpActionResult ArchiveServiceCase(object model) // api/_CustomerRequest/ArchiveServiceCase/1
        {
            var jsonString = model.ToString();
            tbl_customer_request custReq = JsonConvert.DeserializeObject<tbl_customer_request>(jsonString);

            IUnitOfWork unitOfWork = new UnitOfWork();
            tbl_customer_request RequestInDb = unitOfWork.CustomerRequest.Get(custReq.Request_id);
            if (RequestInDb == null)
            {
                return NotFound();
            }

            if (RequestInDb.isActive == true)
            {
                RequestInDb.isActive = false;
            }
            else
            {
                RequestInDb.isActive = true;
            }
            unitOfWork.Complete();

            return Ok("Successful");
        }


        [HttpPut]
        [Route("DeleteServiceCase")]
        public IHttpActionResult DeleteServiceCase(object model) // api/_CustomerRequest/DeleteServiceCase/1
        {
            var jsonString = model.ToString();
            tbl_customer_request custReq = JsonConvert.DeserializeObject<tbl_customer_request>(jsonString);

            IUnitOfWork unitOfWork = new UnitOfWork();
            tbl_customer_request RequestInDb = unitOfWork.CustomerRequest.Get(custReq.Request_id);
            if (RequestInDb == null)
            {
                return NotFound();
            }

            RequestInDb.isDelete = true;
            unitOfWork.Complete();

            return Ok("Successful");
        }

        [HttpPut]
        [Route("UpdateBasicProblem")]
        public IHttpActionResult UpdateBasicProblem(tbl_customer_request custReq) // api/_CustomerRequest/UpdateBasicProblem/1
        {

            IUnitOfWork unitOfWork = new UnitOfWork();
            tbl_customer_request RequestInDb = unitOfWork.CustomerRequest.Get(custReq.Request_id);
            if (RequestInDb == null)
            {
                return NotFound();
            }

            RequestInDb.issue = custReq.issue;
            RequestInDb.error_description = custReq.error_description;
            RequestInDb.Last_Modified = DateTime.Now;
            unitOfWork.Complete();

            return Ok(RequestInDb);
        }


    }
}