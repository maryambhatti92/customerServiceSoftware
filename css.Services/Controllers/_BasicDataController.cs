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
    [RoutePrefix("api/_BasicData")]
    public class _BasicDataController : ApiController
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CssDbConnection"].ConnectionString;
        // GET: _CustomerRequest        

        [HttpGet]
        [Route("GetBasicRequest")]
        public IHttpActionResult GetBasicRequest(int custid) // api/_BasicData/GetBasicRequest
        {            
                BasicdataVM basicdatavm = new BasicdataVM();
                tbl_contact_person contactOne = new tbl_contact_person();
                tbl_contact_person contactTwo = new tbl_contact_person();
                IUnitOfWork unitOfWork = new UnitOfWork();
                DataTable custRequest = unitOfWork.BasicData.GetServiceFormData(connectionString, custid);
                if (custRequest != null)
                {
                    if (custRequest.Rows.Count > 1)
                    {

                    basicdatavm.Customer_id = custid;
                    basicdatavm.cname= custRequest.Rows[1]["cname"].ToString();
                    basicdatavm.address= custRequest.Rows[1]["address"].ToString();
                    basicdatavm.street = custRequest.Rows[1]["street"].ToString();
                    basicdatavm.zipcode_id = Convert.ToInt32(custRequest.Rows[1]["zipcode_id"].ToString());
                    basicdatavm.country_id = Convert.ToInt32(custRequest.Rows[1]["country_id"].ToString());
                    basicdatavm.company= custRequest.Rows[1]["company"].ToString();
                    basicdatavm.CustomerRefNo = custRequest.Rows[1]["CustomerRefNo"].ToString();
                    basicdatavm.Request_id = Convert.ToInt32(custRequest.Rows[1]["Request_id"].ToString());
                    basicdatavm.ref_num = Convert.ToInt32(custRequest.Rows[1]["ref_num"].ToString());
                    basicdatavm.issue= Convert.ToInt32(custRequest.Rows[1]["issue"]);
                    basicdatavm.customer_file = custRequest.Rows[1]["customer_file"].ToString();
                    basicdatavm.customer_id = custid;
                    basicdatavm.priority= Convert.ToInt32(custRequest.Rows[1]["priority"].ToString());
                    basicdatavm.status = Convert.ToInt32(custRequest.Rows[1]["status"].ToString());
                    basicdatavm.date_added= custRequest.Rows[1]["date_added"].ToString();
                    basicdatavm.error_description = custRequest.Rows[1]["error_description"].ToString();
                    basicdatavm.worker= custRequest.Rows[1]["worker"].ToString();
                    basicdatavm.zipCode_id = Convert.ToInt32(custRequest.Rows[1]["zipCode_id"].ToString());
                    basicdatavm.zipcode = custRequest.Rows[1]["zipcode"].ToString();
                    basicdatavm.count_id = Convert.ToInt32(custRequest.Rows[1]["count_id"].ToString());
                    basicdatavm.country = custRequest.Rows[1]["country"].ToString();                   


                    contactOne.name = custRequest.Rows[0]["name"].ToString();
                    contactOne.Contact_id = Convert.ToInt32(custRequest.Rows[0]["Contact_id"]);
                    contactOne.email= custRequest.Rows[0]["email"].ToString();
                    contactOne.phone= custRequest.Rows[0]["phone"].ToString();
                    contactOne.customer_id = Convert.ToInt32(custRequest.Rows[0]["customer_id"]);


                    contactTwo.name = custRequest.Rows[1]["name"].ToString();
                    contactTwo.Contact_id = Convert.ToInt32(custRequest.Rows[1]["Contact_id"]);
                    contactTwo.email = custRequest.Rows[1]["email"].ToString();
                    contactTwo.phone = custRequest.Rows[1]["phone"].ToString();
                    contactTwo.customer_id = Convert.ToInt32(custRequest.Rows[0]["customer_id"]);

                    basicdatavm.contactpersons = new List<tbl_contact_person>();
                    basicdatavm.contactpersons.Add(contactOne);
                    basicdatavm.contactpersons.Add(contactTwo);


                    }

                }

                return Ok(basicdatavm);
            }

        [HttpGet]
        [Route("GetStatusDropdown")]
        public IHttpActionResult GetStatusDropdown(string LangID) // api/_BasicData/GetStatusDropdown
        {
            int ID = Convert.ToInt32(LangID);
            IUnitOfWork unitOfWork = new UnitOfWork();
            IEnumerable<tbl_status> custRequest = unitOfWork.statusData.GetStatusViaLang(ID);
            return Ok(custRequest);
        }

        [HttpPut]
        [Route("UpdateBasicCustomer")]
        public IHttpActionResult UpdateBasicCustomer(object model) // api/_BasicData/UpdateBasicCustomer/1
        {
            try
            {
                var jsonString = model.ToString();
                BasicdataVM basicdata = JsonConvert.DeserializeObject<BasicdataVM>(jsonString);

                IUnitOfWork unitOfWork = new UnitOfWork();
                tbl_customer CustInDb = unitOfWork.BasicData.Get(basicdata.Customer_id);
                if (CustInDb == null)
                {
                    return NotFound();
                }

             //   CustInDb.cname = basicdata.cname;
              //  CustInDb.address = basicdata.address;
                CustInDb.company = basicdata.company;
                CustInDb.street = basicdata.street;
                CustInDb.CustomerRefNo = basicdata.CustomerRefNo;
                CustInDb.Zipcode = basicdata.zipcode;
                CustInDb.Country = basicdata.country;
                unitOfWork.Complete();
                IUnitOfWork unitOfWork1 = new UnitOfWork();

                tbl_customer_request CustReqIndb = unitOfWork1.CustomerRequest.Get(basicdata.Request_id ?? 0) ;
                CustReqIndb.issue =  basicdata.issue;
                CustReqIndb.error_description = basicdata.error_description;
                CustReqIndb.Last_Modified = DateTime.Now;
                unitOfWork1.Complete();



                if (basicdata.contactpersons.Count >= 2)
                {

                    IUnitOfWork unitOfWork2 = new UnitOfWork();
                    tbl_contact_person personIndb = unitOfWork2.ContactPerson.Get(basicdata.contactpersons[0].Contact_id);
                    personIndb.name = basicdata.contactpersons[0].name;
                    personIndb.email = basicdata.contactpersons[0].email;
                    personIndb.phone = basicdata.contactpersons[0].phone;
                    unitOfWork2.Complete();


                    IUnitOfWork unitOfWork3 = new UnitOfWork();
                    tbl_contact_person personIndb2 = unitOfWork3.ContactPerson.Get(basicdata.contactpersons[1].Contact_id);
                    personIndb2.name = basicdata.contactpersons[1].name;
                    personIndb2.email = basicdata.contactpersons[1].email;
                    personIndb2.phone = basicdata.contactpersons[1].phone;
                    unitOfWork3.Complete();
                }

                return Ok("Successful");
            }

            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx )
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
        [Route("UpdateBasicDetail")]
        public IHttpActionResult UpdateBasicDetail(object model) // api/_BasicData/UpdateBasicDetail/1
        {
            try
            {
                var jsonString = model.ToString();
                BasicDetailVM basicdata = JsonConvert.DeserializeObject<BasicDetailVM>(jsonString);

                IUnitOfWork unitOfWork = new UnitOfWork();
                tbl_customer CustInDb = unitOfWork.BasicData.Get(basicdata.Customer_id);
                if (CustInDb == null)
                {
                    return NotFound();
                }

                //   CustInDb.cname = basicdata.cname;
                //  CustInDb.address = basicdata.address;
                CustInDb.company = basicdata.company;
                CustInDb.street = basicdata.street;
                CustInDb.CustomerRefNo = basicdata.CustomerRefNo;
                CustInDb.Zipcode = basicdata.zipcode;
                CustInDb.Country = basicdata.country;
                unitOfWork.Complete();
                IUnitOfWork unitOfWork1 = new UnitOfWork();

                tbl_customer_request CustReqIndb = unitOfWork1.CustomerRequest.Get(basicdata.Request_id ?? 0);
                CustReqIndb.issue = basicdata.issue;
                CustReqIndb.FurtherInformatipn = basicdata.furtherInfo;
                CustReqIndb.error_description = basicdata.error_description;
                CustReqIndb.Last_Modified = DateTime.Now;
                unitOfWork1.Complete();

                
                    IUnitOfWork unitOfWork2 = new UnitOfWork();
                    tbl_contact_person personIndb = unitOfWork2.ContactPerson.Get(basicdata.Contact_id);
                    personIndb.name = basicdata.Contact_name;
                    personIndb.email = basicdata.email;
                    personIndb.phone = basicdata.phone;
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

        [HttpGet]
        [Route("GetServiceInfoData")]
        public IHttpActionResult GetServiceInfoData(int requestID) //api/_BasicData/GetServiceInfoData?requestID=1
        {
            ServiceInfoVM ServiceDatavm = new ServiceInfoVM();

            tbl_contact_person contactOne = new tbl_contact_person();
            tbl_contact_person contactTwo = new tbl_contact_person();
                        
            IUnitOfWork unitOfWork = new UnitOfWork();
            DataTable ServiceData = unitOfWork.BasicData.GetServiceInfoDatadb(connectionString, requestID);
            if (ServiceData != null)
            {
                if (ServiceData.Rows.Count > 1)
                {

                    ServiceDatavm.Request_id = requestID;
                    ServiceDatavm.ref_num = ServiceData.Rows[1]["ref_num"].ToString();
                    ServiceDatavm.issue = Convert.ToInt32(ServiceData.Rows[1]["issue"]);
                    ServiceDatavm.customer_file = ServiceData.Rows[1]["customer_file"].ToString();
                    ServiceDatavm.customer_id = Convert.ToInt32(ServiceData.Rows[1]["customer_id"]);
                    ServiceDatavm.priority = ServiceData.Rows[1]["priority"].ToString();
                    ServiceDatavm.status = ServiceData.Rows[1]["status"].ToString();
                    ServiceDatavm.date_added = Convert.ToDateTime(ServiceData.Rows[1]["date_added"]);
                    ServiceDatavm.Last_Modified = Convert.ToDateTime(ServiceData.Rows[1]["Last_Modified"]);
                    ServiceDatavm.Individual_FootNote = ServiceData.Rows[1]["Individual_FootNote"].ToString();
                    ServiceDatavm.FurtherInformatipn = ServiceData.Rows[1]["FurtherInformatipn"].ToString();
                    ServiceDatavm.error_description = ServiceData.Rows[1]["error_description"].ToString();
                    ServiceDatavm.worker = ServiceData.Rows[1]["worker"].ToString();
                    ServiceDatavm.isActive = Convert.ToBoolean(ServiceData.Rows[1]["isActive"]);
                    ServiceDatavm.isDelete = Convert.ToBoolean(ServiceData.Rows[1]["isDelete"]);
                                       
                    if (ServiceData.Rows[1]["Order_id"].ToString() != "")
                    {
                        ServiceDatavm.Order_id = Convert.ToInt32(ServiceData.Rows[1]["Order_id"]);
                        ServiceDatavm.Request_id1 = Convert.ToInt32(ServiceData.Rows[1]["Request_id"]);
                        ServiceDatavm.Email_Sent = Convert.ToInt32(ServiceData.Rows[1]["Email_Sent"]);
                        ServiceDatavm.Email_date = Convert.ToDateTime(ServiceData.Rows[1]["Email_date"]);
                        ServiceDatavm.Confirmation = ServiceData.Rows[1]["Confirmation"].ToString();
                        var x = ServiceData.Rows[1]["Quantity"].ToString();
                        if (ServiceData.Rows[1]["Quantity"].ToString() != "")
                        {
                            ServiceDatavm.Quantity = Convert.ToInt32(ServiceData.Rows[1]["Quantity"]);
                        }
                        ServiceDatavm.CustomerNumber_FrmSheet = ServiceData.Rows[1]["CustomerNumber_FrmSheet"].ToString();
                        ServiceDatavm.CustomerNumber_Org = ServiceData.Rows[1]["CustomerNumber_Org"].ToString();
                        ServiceDatavm.OrginalOrderNumber = ServiceData.Rows[1]["OrginalOrderNumber"].ToString();
                        ServiceDatavm.Waranty = ServiceData.Rows[1]["Waranty"].ToString();
                        ServiceDatavm.DeliveryDate = Convert.ToDateTime(ServiceData.Rows[1]["DeliveryDate"]);
                        if (ServiceData.Rows[1]["Orignal_Quantity"].ToString() != "")
                        {
                            ServiceDatavm.Orignal_Quantity = Convert.ToInt32(ServiceData.Rows[1]["Orignal_Quantity"]);
                        }
                    }

                    if (ServiceData.Rows[1]["InspectionID"].ToString() != "")
                    {
                        ServiceDatavm.InspectionID = Convert.ToInt32(ServiceData.Rows[1]["InspectionID"]);
                        ServiceDatavm.RequestId = Convert.ToInt32(ServiceData.Rows[1]["RequestId"]);
                        ServiceDatavm.OrderId = Convert.ToInt32(ServiceData.Rows[1]["OrderId"]);
                        ServiceDatavm.Department = Convert.ToInt32(ServiceData.Rows[1]["Department"]);
                        ServiceDatavm.Operator = ServiceData.Rows[1]["Operator"].ToString();
                        ServiceDatavm.Complaint = ServiceData.Rows[1]["Complaint"].ToString();
                        ServiceDatavm.ServiceTask = Convert.ToInt32(ServiceData.Rows[1]["ServiceTask"]);
                        ServiceDatavm.Diagnosis = Convert.ToInt32(ServiceData.Rows[1]["Diagnosis"]);
                        ServiceDatavm.Reason = Convert.ToInt32(ServiceData.Rows[1]["Reason"]);
                        ServiceDatavm.Description = ServiceData.Rows[1]["Description"].ToString();
                        ServiceDatavm.createRp = ServiceData.Rows[1]["createRp"].ToString();
                        ServiceDatavm.ReportDone = ServiceData.Rows[1]["ReportDone"].ToString();
                        ServiceDatavm.Create8DReport = ServiceData.Rows[1]["Create8DReport"].ToString();
                        ServiceDatavm.report8DDone = ServiceData.Rows[1]["report8DDone"].ToString();
                        ServiceDatavm.Email_Sent1 = Convert.ToInt32(ServiceData.Rows[1]["Email_Sent1"]);
                        ServiceDatavm.Email_date1 = Convert.ToDateTime(ServiceData.Rows[1]["Email_date1"]);
                    }

                    ServiceDatavm.Customer_id1 = Convert.ToInt32(ServiceData.Rows[1]["Customer_id1"]);
                    ServiceDatavm.cname = ServiceData.Rows[1]["cname"].ToString();
                    ServiceDatavm.address = ServiceData.Rows[1]["address"].ToString();
                    ServiceDatavm.street = ServiceData.Rows[1]["street"].ToString();
                    ServiceDatavm.Zipcode = ServiceData.Rows[1]["Zipcode"].ToString();
                    ServiceDatavm.Country = ServiceData.Rows[1]["Country"].ToString();
                    ServiceDatavm.company = ServiceData.Rows[1]["company"].ToString();
                    ServiceDatavm.CustomerRefNo = ServiceData.Rows[1]["CustomerRefNo"].ToString();


                    contactOne.name = ServiceData.Rows[0]["name"].ToString();
                    contactOne.Contact_id = Convert.ToInt32(ServiceData.Rows[0]["Contact_id"]);
                    contactOne.email = ServiceData.Rows[0]["email"].ToString();
                    contactOne.phone = ServiceData.Rows[0]["phone"].ToString();
                    contactOne.customer_id = Convert.ToInt32(ServiceData.Rows[0]["customer_id"]);


                    contactTwo.name = ServiceData.Rows[1]["name"].ToString();
                    contactTwo.Contact_id = Convert.ToInt32(ServiceData.Rows[1]["Contact_id"]);
                    contactTwo.email = ServiceData.Rows[1]["email"].ToString();
                    contactTwo.phone = ServiceData.Rows[1]["phone"].ToString();
                    contactTwo.customer_id = Convert.ToInt32(ServiceData.Rows[0]["customer_id"]);

                    ServiceDatavm.contactpersons = new List<tbl_contact_person>();
                    ServiceDatavm.contactpersons.Add(contactOne);
                    ServiceDatavm.contactpersons.Add(contactTwo);



                }

            }

            return Ok(ServiceDatavm);
        }

        [HttpGet]
        [Route("GetAllServiceInfoData")]
        public IHttpActionResult GetAllServiceInfoData(int requestID) //api/_BasicData/GetAllServiceInfoData?requestID=1
        {
            sp_GetServiceForm_Result ServiceDatavm = new sp_GetServiceForm_Result();


            IUnitOfWork unitOfWork = new UnitOfWork();
            DataTable ServiceData = unitOfWork.BasicData.GetServiceFormData(connectionString, requestID);
            if (ServiceData != null)
            {
                if (ServiceData.Rows.Count > 0)
                {

                    ServiceDatavm.Request_id = requestID;
                    ServiceDatavm.ref_num = ServiceData.Rows[1]["ref_num"].ToString();
                    ServiceDatavm.issue = Convert.ToInt32(ServiceData.Rows[1]["issue"]);
                    ServiceDatavm.customer_file = ServiceData.Rows[1]["customer_file"].ToString();
                    ServiceDatavm.customer_id = Convert.ToInt32(ServiceData.Rows[1]["customer_id"]);
                    ServiceDatavm.priority = ServiceData.Rows[1]["priority"].ToString();
                    ServiceDatavm.status = ServiceData.Rows[1]["status"].ToString();
                    ServiceDatavm.date_added = Convert.ToDateTime(ServiceData.Rows[1]["date_added"]);
                    ServiceDatavm.Last_Modified = Convert.ToDateTime(ServiceData.Rows[1]["Last_Modified"]);
                    ServiceDatavm.Individual_FootNote = ServiceData.Rows[1]["Individual_FootNote"].ToString();
                    ServiceDatavm.FurtherInformatipn = ServiceData.Rows[1]["FurtherInformatipn"].ToString();
                    ServiceDatavm.error_description = ServiceData.Rows[1]["error_description"].ToString();
                    ServiceDatavm.worker = ServiceData.Rows[1]["worker"].ToString();
                    ServiceDatavm.isActive = Convert.ToBoolean(ServiceData.Rows[1]["isActive"]);
                    ServiceDatavm.isDelete = Convert.ToBoolean(ServiceData.Rows[1]["isDelete"]);

                    if (ServiceData.Rows[0]["Order_id"].ToString() != "")
                    {
                        ServiceDatavm.Order_id = Convert.ToInt32(ServiceData.Rows[1]["Order_id"]);
                        ServiceDatavm.Request_id1 = Convert.ToInt32(ServiceData.Rows[1]["Request_id"]);
                        ServiceDatavm.Email_Sent = Convert.ToInt32(ServiceData.Rows[1]["Email_Sent"]);
                        ServiceDatavm.Email_date = Convert.ToDateTime(ServiceData.Rows[1]["Email_date"]);
                        ServiceDatavm.Confirmation = ServiceData.Rows[1]["Confirmation"].ToString();
                        var x = ServiceData.Rows[1]["Quantity"].ToString();
                        if (ServiceData.Rows[1]["Quantity"].ToString() != "")
                        {
                            ServiceDatavm.Quantity = Convert.ToInt32(ServiceData.Rows[1]["Quantity"]);
                        }
                        ServiceDatavm.CustomerNumber_FrmSheet = ServiceData.Rows[1]["CustomerNumber_FrmSheet"].ToString();
                        ServiceDatavm.CustomerNumber_Org = ServiceData.Rows[1]["CustomerNumber_Org"].ToString();
                        ServiceDatavm.OrginalOrderNumber = ServiceData.Rows[1]["OrginalOrderNumber"].ToString();
                        ServiceDatavm.Waranty = ServiceData.Rows[1]["Waranty"].ToString();
                        ServiceDatavm.DeliveryDate = Convert.ToDateTime(ServiceData.Rows[1]["DeliveryDate"]);
                        if (ServiceData.Rows[1]["Orignal_Quantity"].ToString() != "")
                        {
                            ServiceDatavm.Orignal_Quantity = Convert.ToInt32(ServiceData.Rows[1]["Orignal_Quantity"]);
                        }
                    }

                    if (ServiceData.Rows[0]["InspectionID"].ToString() != "")
                    {
                        ServiceDatavm.InspectionID = Convert.ToInt32(ServiceData.Rows[1]["InspectionID"]);
                        ServiceDatavm.RequestId = Convert.ToInt32(ServiceData.Rows[1]["RequestId"]);
                        ServiceDatavm.OrderId = Convert.ToInt32(ServiceData.Rows[1]["OrderId"]);
                        ServiceDatavm.Department = Convert.ToInt32(ServiceData.Rows[1]["Department"]);
                        ServiceDatavm.Operator = ServiceData.Rows[1]["Operator"].ToString();
                        ServiceDatavm.Complaint = ServiceData.Rows[1]["Complaint"].ToString();
                        ServiceDatavm.ServiceTask = Convert.ToInt32(ServiceData.Rows[1]["ServiceTask"]);
                        ServiceDatavm.Diagnosis = Convert.ToInt32(ServiceData.Rows[1]["Diagnosis"]);
                        ServiceDatavm.Reason = Convert.ToInt32(ServiceData.Rows[1]["Reason"]);
                        ServiceDatavm.Description = ServiceData.Rows[1]["Description"].ToString();
                        ServiceDatavm.createRp = ServiceData.Rows[1]["createRp"].ToString();
                        ServiceDatavm.ReportDone = ServiceData.Rows[1]["ReportDone"].ToString();
                        ServiceDatavm.Create8DReport = ServiceData.Rows[1]["Create8DReport"].ToString();
                        ServiceDatavm.report8DDone = ServiceData.Rows[1]["report8DDone"].ToString();
                        ServiceDatavm.Email_Sent1 = Convert.ToInt32(ServiceData.Rows[1]["Email_Sent1"]);
                        ServiceDatavm.Email_date1 = Convert.ToDateTime(ServiceData.Rows[1]["Email_date1"]);
                    }

                    if (ServiceData.Rows[0]["solution_id"].ToString() != "")
                    {
                        ServiceDatavm.solution_id = Convert.ToInt32(ServiceData.Rows[1]["solution_id"]);
                        ServiceDatavm.request_id2 = Convert.ToInt32(ServiceData.Rows[1]["request_id"]);
                        ServiceDatavm.statement =  ServiceData.Rows[1]["statement"].ToString();
                        ServiceDatavm.Notes = ServiceData.Rows[1]["Notes"].ToString();
                        ServiceDatavm.reminder1 = ServiceData.Rows[1]["reminder1"].ToString();
                        ServiceDatavm.reminder2 = ServiceData.Rows[1]["reminder2"].ToString();
                        ServiceDatavm.Email_Sent2 = Convert.ToInt32(ServiceData.Rows[1]["Email_Sent"]);
                        ServiceDatavm.Email_date2= Convert.ToDateTime(ServiceData.Rows[1]["Email_date"]);
                       
                    }

                    if (ServiceData.Rows[0]["Completion_id"].ToString() != "")
                    {
                        ServiceDatavm.Completion_id = Convert.ToInt32(ServiceData.Rows[1]["Completion_id"]);
                        ServiceDatavm.request_id3 = Convert.ToInt32(ServiceData.Rows[1]["RequestId"]);
                        ServiceDatavm.order_number = ServiceData.Rows[1]["order_number"].ToString();
                        ServiceDatavm.credite_note_number =ServiceData.Rows[1]["credite_note_number"].ToString();
                        ServiceDatavm.Disposal = ServiceData.Rows[1]["Disposal"].ToString();
                        ServiceDatavm.Evaluation_Request = Convert.ToBoolean(ServiceData.Rows[1]["Evaluation_Request"]);
                        ServiceDatavm.Availability = Convert.ToInt32(ServiceData.Rows[1]["Availability"]);
                        ServiceDatavm.Professional_Competence = Convert.ToInt32(ServiceData.Rows[1]["Professional_Competence"]);
                        ServiceDatavm.Reaction_Time = Convert.ToInt32(ServiceData.Rows[1]["Reaction_Time"]);
                        ServiceDatavm.Kindness = ServiceData.Rows[1]["Kindness"].ToString();
                        ServiceDatavm.Text =ServiceData.Rows[1]["Text"].ToString();
                    }

                }

            }

            return Ok(ServiceDatavm);
        }

        [HttpGet]
        [Route("GetAllServiceForm")]
        public IHttpActionResult GetAllServiceForm(int requestID, int companyID, string LangID) // api/_BasicData/GetAllServiceForm?requestID=1&companyID=2
        {
            int Language = Convert.ToInt32(LangID);
            ServiceFormVM servicedata = new ServiceFormVM();

            IUnitOfWork unitOfWork = new UnitOfWork();

            IEnumerable<tbl_Departments> DepData = unitOfWork.Departments.GetDepartViaCompany(companyID, Language);
            servicedata.departments = DepData;

            IEnumerable<tbl_Diagnosis> DiagnosisData = unitOfWork.Diagnosis.GetDiagnosisCompanyVise(companyID);
            servicedata.diagnosis = DiagnosisData;

            IEnumerable<tbl_Reason> ReasonData = unitOfWork.Reason.GetReasonViaLang(Language);
            servicedata.reason = ReasonData;

            IEnumerable<tbl_ServiceTask> ServicetaskData = unitOfWork.ServiceTask.GetStatusViaLang(Language);
            servicedata.serviceTask = ServicetaskData;

            tbl_customer_request custRequest = unitOfWork.CustomerRequest.GetCustomerRequestViaRequestID(requestID);


            if (custRequest != null)
            {
                if (custRequest.Company_ID == companyID || companyID == 1) // 21 owner id
                { 
                servicedata.customerRequest = custRequest;

                //// IUnitOfWork unitOfWork1 = new UnitOfWork();
                tbl_customer CustomerData = unitOfWork.Customer.GetCustomerViatblRequest(custRequest.customer_id);
                servicedata.Customer = CustomerData;


                // IUnitOfWork unitOfWork2 = new UnitOfWork();
                IEnumerable<tbl_contact_person> ContactData = unitOfWork.ContactPerson.GetContactViatblCustomer(CustomerData.Customer_id);
                servicedata.Contacts = ContactData;

                //   IUnitOfWork unitOfWork3 = new UnitOfWork();
                tbl_OrderData orderData = unitOfWork.OrderData.GetOrderViaRequest(requestID);
                servicedata.orderData = orderData;

                //    IUnitOfWork unitOfWork4 = new UnitOfWork();
                tbl_Inspection inspection = unitOfWork.Inspection.GetInspectionViaRequest(requestID);
                servicedata.inspectionData = inspection;

                SolutionVM solutiondata = new SolutionVM();
                // IUnitOfWork unitOfWork = new UnitOfWork();
                solutiondata.solution = unitOfWork.Solution.GetSolutionViaRequest(requestID);
                solutiondata.options = unitOfWork.SolutionOptions.GetSolutionOptionsViaRequest(requestID);
                servicedata.solutionData = solutiondata;

                //    IUnitOfWork unitOfWork5 = new UnitOfWork();
                tbl_Completion completion = unitOfWork.Completion.GetCompletionViaRequest(requestID);
                servicedata.completionData = completion;


            }
            }            
            return Ok(servicedata);

        }

        [HttpGet]
        [Route("GetContactDetail")]
        public IHttpActionResult GetContactDetail(int requestID) // api/_BasicData/GetContactDetail?requestID=1
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            tbl_customer_request CR= unitOfWork.CustomerRequest.Get(requestID);
            tbl_contact_person ContactData = unitOfWork.ContactPerson.GetSingleContactViatblCustomer(CR.customer_id);
            return Ok(ContactData);
        }

    }
}

