﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace css.Data.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class cssDbContext : DbContext
    {
        public cssDbContext()
            : base("name=cssDbContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_Company> tbl_Company { get; set; }
        public virtual DbSet<tbl_Completion> tbl_Completion { get; set; }
        public virtual DbSet<tbl_contact_person> tbl_contact_person { get; set; }
        public virtual DbSet<tbl_country> tbl_country { get; set; }
        public virtual DbSet<tbl_customer> tbl_customer { get; set; }
        public virtual DbSet<tbl_customer_request> tbl_customer_request { get; set; }
        public virtual DbSet<tbl_Departments> tbl_Departments { get; set; }
        public virtual DbSet<tbl_Diagnosis> tbl_Diagnosis { get; set; }
        public virtual DbSet<Tbl_EmailContents> Tbl_EmailContents { get; set; }
        public virtual DbSet<tbl_Inspection> tbl_Inspection { get; set; }
        public virtual DbSet<tbl_language> tbl_language { get; set; }
        public virtual DbSet<tbl_LicenseHistory> tbl_LicenseHistory { get; set; }
        public virtual DbSet<tbl_OrderData> tbl_OrderData { get; set; }
        public virtual DbSet<tbl_priority> tbl_priority { get; set; }
        public virtual DbSet<tbl_ProblemDescriptionIssue> tbl_ProblemDescriptionIssue { get; set; }
        public virtual DbSet<tbl_Reason> tbl_Reason { get; set; }
        public virtual DbSet<tbl_register> tbl_register { get; set; }
        public virtual DbSet<tbl_SequawareLogin> tbl_SequawareLogin { get; set; }
        public virtual DbSet<tbl_ServiceTask> tbl_ServiceTask { get; set; }
        public virtual DbSet<tbl_Solution> tbl_Solution { get; set; }
        public virtual DbSet<tbl_SolutionOptions> tbl_SolutionOptions { get; set; }
        public virtual DbSet<tbl_status> tbl_status { get; set; }
        public virtual DbSet<tbl_zipcodes> tbl_zipcodes { get; set; }
        public virtual DbSet<SampleEmailContent> SampleEmailContents { get; set; }
        public virtual DbSet<tbl_SampleDepartments> tbl_SampleDepartments { get; set; }
    
        public virtual ObjectResult<sp_GetBasicdata_Result> sp_GetBasicdata(Nullable<int> customerId)
        {
            var customerIdParameter = customerId.HasValue ?
                new ObjectParameter("CustomerId", customerId) :
                new ObjectParameter("CustomerId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetBasicdata_Result>("sp_GetBasicdata", customerIdParameter);
        }
    
        public virtual ObjectResult<sp_GetMainGriddata_Result> sp_GetMainGriddata(Nullable<int> company_id)
        {
            var company_idParameter = company_id.HasValue ?
                new ObjectParameter("Company_id", company_id) :
                new ObjectParameter("Company_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetMainGriddata_Result>("sp_GetMainGriddata", company_idParameter);
        }
    
        public virtual ObjectResult<sp_GetServiceInfodata_Result> sp_GetServiceInfodata(Nullable<int> requestID)
        {
            var requestIDParameter = requestID.HasValue ?
                new ObjectParameter("RequestID", requestID) :
                new ObjectParameter("RequestID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetServiceInfodata_Result>("sp_GetServiceInfodata", requestIDParameter);
        }
    
        public virtual ObjectResult<sp_GetServiceForm_Result> sp_GetServiceForm(Nullable<int> requestId)
        {
            var requestIdParameter = requestId.HasValue ?
                new ObjectParameter("RequestId", requestId) :
                new ObjectParameter("RequestId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetServiceForm_Result>("sp_GetServiceForm", requestIdParameter);
        }
    
        public virtual ObjectResult<sp_GetArchiveGriddata_Result1> sp_GetArchiveGriddata(Nullable<int> company_id)
        {
            var company_idParameter = company_id.HasValue ?
                new ObjectParameter("Company_id", company_id) :
                new ObjectParameter("Company_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetArchiveGriddata_Result1>("sp_GetArchiveGriddata", company_idParameter);
        }
    
        public virtual int sp_GetMainGriddata1(Nullable<int> company_id)
        {
            var company_idParameter = company_id.HasValue ?
                new ObjectParameter("Company_id", company_id) :
                new ObjectParameter("Company_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_GetMainGriddata1", company_idParameter);
        }
    }
}
