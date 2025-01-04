using css.Data;
using css.Data.Models;
using css.Repository.Interfaces;
using css.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace css.Repository
{

    // Class
    public class UnitOfWork : IUnitOfWork
    {
        private readonly cssDbContext _context;

        public ICustomerRequestRepository CustomerRequest { get; private set; }
        public IBasicDataRepository BasicData { get; private set; }
        public IstatusRepository statusData { get; private set; }
        public IContactPersonRepository ContactPerson { get; private set; }
        public IOrderDataRepository OrderData { get; private set; }
        public IEmailRepository EmailContent { get; private set; }
        public ICompanyRepository Company { get; private set; }
        public IDepartmentRepository Departments { get; private set; }
        public IInspectionRepository Inspection { get; private set; }
        public IReasonRepository Reason { get; private set; }
        public IDiagnosisRepository Diagnosis { get; private set; }
        public IServiceTaskRepository ServiceTask { get; private set; }
        public IissueRepository Issue { get; private set; }
        public ICustomerRepository Customer { get; private set; }
        public ISolutionRepository Solution { get; private set; }
        public ISolutionOptionsRepository SolutionOptions { get; private set; }
        public ILoginRepository Login { get; private set; }
        public ICompletionRepository Completion { get; private set; }
        public ISampleEmailContentsRepository SampleEmail { get; private set; }
        public ILicenseHistoryRepository LicenseHistory { get; private set; }
        public ILanguageRepository  Language { get; private set; }
        public ISampleDEpartmentRepository SampleDepartment { get; private set; }
        

        public UnitOfWork()
        {
        
            //_context = context;
            _context = new cssDbContext();

            CustomerRequest = new CustomerRequestRepository(_context);
            BasicData = new BasicDataRepository(_context);
            statusData = new StatusRepository(_context);
            ContactPerson = new ContactPersonRepository(_context);
            OrderData = new OrderDataRepository(_context);
            EmailContent = new EmailRepository(_context);
            Company = new CompanyRepository(_context);
            Departments = new DepartmentRepository(_context);
            Inspection = new InspectionRepository(_context);
            Reason = new ReasonRepository(_context);
            Diagnosis = new DiagnosisRepository(_context);
            ServiceTask = new ServiceTaskRepository(_context);
            Issue = new IssueRepository(_context);
            Customer = new CustomerRepository(_context);
            Solution = new SolutionRepository(_context);
            SolutionOptions = new SolutionOptionRepository(_context);
            Login = new LoginRepository(_context);
            Completion = new CompletionRepository(_context);
            SampleEmail = new SampleEmailContentsRepository(_context);
            LicenseHistory = new LicenseHistoryRepository(_context);
            Language = new LanguageRepository(_context);
            SampleDepartment = new SampleDepartmentContentsRepository(_context);

        }

        public int Complete()
        {
            return _context.SaveChanges();

        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
    
}

