using Domain.Aggreagtes.CourseAggregate;
using Domain.Aggreagtes.StudentAggregate;
using Domain.Aggreagtes.UserAggregate;
using Domain.Common.Contracts;
using Domain.Enums;
using Domain.Exceptions;
using System.Reflection;

namespace Domain.Aggreagtes.StaffAggregate;

public class Staff : AuditableEntity, IAggregateRoot
{
    public required string StaffNumber { get; set; } 
    public  string FirstName { get; private set; } = default!;
    public  string LastName { get; private set; } = default!;
    public  Gender Gender { get; private set; } = default!;
    public  DateOnly DOB { get; private set; } = default!;
    public required ContactInformation ContactInformation { get;  set; } 
    public EducationalQualification EducationalQualification { get; private set; } = default!;
    public Certifications Certifications { get; private set; } = default!;
    public required BankDetails BankDetails { get; set; }
    public NextOfKinDetails NextOfKinDetails { get; private set; } = default!;
    public Department Department { get; private set; } = default!;
    private readonly List<EmployeeContract> _employeeContracts = [];
    public IReadOnlyList<EmployeeContract> EmployeeContracts => _employeeContracts.AsReadOnly();
    private readonly  List<AreaOfSpecialization> _areaOfSpecializations = [];
    public IReadOnlyList<AreaOfSpecialization> AreaOfSpecializations => _areaOfSpecializations.AsReadOnly();




    #region Constructor
    private Staff() { }

    internal Staff(string staffNumber,ContactInformation contactInformation, BankDetails bankDetails, List<AreaOfSpecialization> areaOfSpecializations)
    {
        StaffNumber = staffNumber;
        ContactInformation = contactInformation;
        BankDetails = bankDetails;
        _areaOfSpecializations = areaOfSpecializations;
    }
    #endregion

    #region 

    #endregion
}

