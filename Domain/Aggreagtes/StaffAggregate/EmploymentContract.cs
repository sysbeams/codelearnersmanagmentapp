namespace Domain.Aggreagtes.StaffAggregate
{
    public class EmploymentContract
    {
        public Guid ContractId { get; private set; }
        public Guid StaffId { get; private set; }
        public Guid OrganizationId { get; private set; }
        public decimal Salary { get; private set; }
        public string Benefits { get; private set; }
        public string Deductions { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }

        #region Constructor
        public EmploymentContract(Guid organizationId, decimal salary, string benefits, string deductions, DateTime startDate)
        {

            if (organizationId == Guid.Empty)
            {
                throw new ArgumentException("OrganizationId must be a valid GUID.", nameof(organizationId));
            }

            if (salary <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(salary), "Salary must be greater than zero.");
            }

            if (startDate == default)
            {
                throw new ArgumentException("StartDate must be a valid date.", nameof(startDate));
            }

            ContractId = Guid.NewGuid();
            OrganizationId = organizationId;
            Salary = salary;
            Benefits = benefits;
            Deductions = deductions;
            StartDate = startDate;
            IsActive = true;
        }
        #endregion

        #region Methods

        public void EndContract(DateTime endDate)
        {
            if (endDate < StartDate)
                throw new ArgumentException("End date cannot be earlier than start date.");

            EndDate = endDate;
            IsActive = false;
        }

        public void UpdateContractDetails(decimal salary, string benefits, string deductions)
        {
            if (!IsActive)
                throw new InvalidOperationException("Cannot update details of an inactive contract.");

            Salary = salary;
            Benefits = benefits;
            Deductions = deductions;
        }

        public bool IsContractActive()
        {
            return IsActive && (EndDate == null || EndDate > DateTime.Now);
        }

        #endregion
    }
}


