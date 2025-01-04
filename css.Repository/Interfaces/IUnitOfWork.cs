using css.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace css.Repository.Interfaces
{
    // Interface
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRequestRepository CustomerRequest { get; }
        IBasicDataRepository BasicData { get; }
        IstatusRepository statusData { get; }
        IContactPersonRepository ContactPerson { get; }
        IOrderDataRepository OrderData { get; }
        ICompanyRepository Company { get; }
        IEmailRepository EmailContent { get; }
        IDepartmentRepository Departments { get;  }
        IInspectionRepository Inspection { get; }
        IReasonRepository Reason { get; }
        IDiagnosisRepository Diagnosis { get; }
        IServiceTaskRepository ServiceTask { get; }
        IissueRepository Issue { get; }
        ICustomerRepository Customer { get; }
        ISolutionRepository Solution { get; }
        ISolutionOptionsRepository SolutionOptions { get; }
        ILoginRepository Login { get; }
        ICompletionRepository Completion { get; }
        ISampleEmailContentsRepository SampleEmail { get; }
        ILicenseHistoryRepository LicenseHistory { get; }
        ILanguageRepository  Language { get; }
        ISampleDEpartmentRepository SampleDepartment { get; }
        int Complete();
    }
}

