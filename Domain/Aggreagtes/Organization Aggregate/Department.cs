using Domain.Aggreagtes.Organization_Aggregate;
using Domain.Aggreagtes.StaffAggregate;
using Domain.Common.Contracts;

public class Department : AuditableEntity<Guid>
{
    public required string Name { get; set; }
    public required Organization Organization { get; set; }
    public required Guid HeadOfStaffId { get; set; }
    public ICollection<Staff> Staffs { get; set; } = new HashSet<Staff>();
    public ICollection<AdjuncStaff> AdjuncStaffs { get; set; } = new HashSet<AdjuncStaff>();

    public Department(string name, Organization organization, Guid headOfStaffId)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name), "Department name cannot be null or empty.");
        }

        if (organization == null)
        {
            throw new ArgumentNullException(nameof(organization), "Organization cannot be null.");
        }

        if (headOfStaffId == Guid.Empty)
        {
            throw new ArgumentException("HeadOfStaffId must be a valid non-empty GUID.", nameof(headOfStaffId));
        }

        Name = name;
        Organization = organization;
        HeadOfStaffId = headOfStaffId;
    }

    #region Business Rules
    public void UpdateDetails(string newName, Guid newHeadOfStaffId)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentNullException(nameof(newName), "Department name cannot be null or empty.");

        if (newHeadOfStaffId == Guid.Empty)
            throw new ArgumentException("HeadOfStaffId must be a valid non Empty GUID.", nameof(newHeadOfStaffId));

        Name = newName;
        HeadOfStaffId = newHeadOfStaffId;
    }

    #endregion

    #region Helper Method

    public void AddAdjunctStaff(AdjuncStaff adjuncStaff)
    {
        if (adjuncStaff == null)
            throw new ArgumentNullException(nameof(adjuncStaff), "AdjuncStaff cannot be null.");

        if (!AdjuncStaffs.Contains(adjuncStaff))
            AdjuncStaffs.Add(adjuncStaff);
    }

    public void RemoveAdjunctStaff(AdjuncStaff adjuncStaff)
    {
        if (adjuncStaff == null)
            throw new ArgumentNullException(nameof(adjuncStaff), "AdjuncStaff cannot be null.");

        if (AdjuncStaffs.Contains(adjuncStaff))
            AdjuncStaffs.Remove(adjuncStaff);
    }
    #endregion
}
