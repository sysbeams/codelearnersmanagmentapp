using Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.StaffAggregate
{
    public class EmployeeContract : AuditableEntity
    {
        public required DateOnly EmploymentDate { get;  set; }
        public DateOnly? TerminatedDate { get; private set; } = default!;
        public  DateOnly AcceptedOfferedDate { get;  private set; } = default!;
        public decimal Rate { get; private set; } = default!;
        public ContractType ContractType { get; private set; } = default!;
        public RateType RateType { get; private set; } = default!;
        public required  Organization Organization { get;  set; }
        public ContractStatus ContractStatus { get; private set; } = default!;
        public Staff Staff { get; private set; } = default!;

        private readonly List<Benefit> _benefits = [];
        public IReadOnlyList<Benefit> Benefits => _benefits.AsReadOnly();

        private readonly List<Deduction> _deductions = [];
        public IReadOnlyList<Deduction> Deductions => _deductions.AsReadOnly();
        private readonly List<Guarantor> _guarantors = [];
        public IReadOnlyList<Guarantor> Guarantors => _guarantors.AsReadOnly();

        #region Constructor
        private EmployeeContract() { }
        internal EmployeeContract(DateOnly employmentDate, Organization organization, List<Benefit> benefits)
        {
            EmploymentDate = employmentDate;
            Organization = organization;
            _benefits = benefits;
        }
        #endregion
    }
}
