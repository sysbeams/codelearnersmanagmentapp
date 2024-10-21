using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Common.Contracts;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Aggreagtes.Organization_Aggregate;
using Domain.Aggreagtes.UserAggregate;

namespace Domain.Aggreagtes.StaffAggregate
{
    public class Staff : AuditableEntity, IAggregateRoot
    {
        public string StaffNo { get; private set; } = default!;
        public string Firstname { get; private set; } = default!;
        public string Lastname { get; private set; } = default!;
        public Gender Gender { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string EmailAddress { get; private set; } = default!;
        public string Phonenumber { get; private set; } = default!;
        public ContactInformation ContactInfo { get; private set; } = default!;
        public NextOfKin NextOfKin { get; private set; } = default!;
        public BankDetails BankDetails { get; private set; } = default!;
        public Department PrimaryDepartment { get; private set; } = default!;
        public List<Department> AdjunctDepartments { get; private set; } = new List<Department>();

        private List<EmploymentContract> _employmentContracts = new List<EmploymentContract>();
        public IReadOnlyCollection<EmploymentContract> EmploymentContracts => _employmentContracts.AsReadOnly();

        #region Constructor
        private Staff() { }  // Private constructor for ORM

        public Staff(string staffNo, string firstname, string lastname, Gender gender, DateTime dateOfBirth,
                        string emailAddress, string phonenumber, ContactInformation contactInfo, NextOfKin nextOfKin,
                        BankDetails bankDetails, Department primaryDepartment)
        {
            if (string.IsNullOrWhiteSpace(staffNo))
                throw new ArgumentNullException(nameof(staffNo), "Staff number cannot be empty.");
            if (string.IsNullOrWhiteSpace(firstname))
                throw new ArgumentNullException(nameof(firstname), "Firstname cannot be empty.");
            if (string.IsNullOrWhiteSpace(lastname))
                throw new ArgumentNullException(nameof(lastname), "Lastname cannot be empty.");
            if (contactInfo == null)
                throw new ArgumentNullException(nameof(contactInfo), "Contact information is required.");
            if (nextOfKin == null)
                throw new ArgumentNullException(nameof(nextOfKin), "Next of kin information is required.");
            if (bankDetails == null)
                throw new ArgumentNullException(nameof(bankDetails), "Bank details are required.");
            if (primaryDepartment == null)
                throw new ArgumentNullException(nameof(primaryDepartment), "Primary department is required.");

            StaffNo = staffNo;
            Firstname = firstname;
            Lastname = lastname;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            EmailAddress = emailAddress;
            Phonenumber = phonenumber;
            ContactInfo = contactInfo;
            NextOfKin = nextOfKin;
            BankDetails = bankDetails;
            PrimaryDepartment = primaryDepartment;
        }
        #endregion

        #region Business Rules Enforcement

        public void AddEmploymentContract(EmploymentContract contract)
        {
            if (contract == null)
                throw new ArgumentNullException(nameof(contract), "Employment contract cannot be null.");

            // Ensure only one active contract per organization
            if (_employmentContracts.Any(c => c.OrganizationId == contract.OrganizationId && c.IsActive))
                throw new InvalidOperationException("Staff cannot have more than one active contract for an organization.");

            _employmentContracts.Add(contract);
        }
        public void ValidateEmploymentContracts()
        {
            // Ensure that staff has at least one contract
            if (!_employmentContracts.Any())
                throw new InvalidOperationException("Every staff must have at least one employment contract.");
        }

        public void UpdateBiodata(string firstname, string lastname, Gender gender, DateTime dateOfBirth)
        {
            if (!_employmentContracts.Any(c => c.IsActive))
                throw new InvalidOperationException("Biodata cannot be updated without an active contract.");

            Firstname = firstname ?? throw new ArgumentNullException(nameof(firstname));
            Lastname = lastname ?? throw new ArgumentNullException(nameof(lastname));
            Gender = gender;
            DateOfBirth = dateOfBirth;
        }

        public EmploymentContract GetActiveContract()
        {
            return _employmentContracts.FirstOrDefault(c => c.IsActive)
                   ?? throw new InvalidOperationException("No active contract found for the staff.");
        }
        #endregion

        #region Helper Methods
        public void AddAdjunctDepartment(Department department)
        {
            if (department == null)
                throw new ArgumentNullException(nameof(department), "Department cannot be null.");

            if (!AdjunctDepartments.Contains(department))
                AdjunctDepartments.Add(department);
        }

        public void RemoveAdjunctDepartment(Department department)
        {
            if (department == null)
                throw new ArgumentNullException(nameof(department), "Department cannot be null.");

            if (AdjunctDepartments.Contains(department))
                AdjunctDepartments.Remove(department);
        }
        #endregion
    }

}
