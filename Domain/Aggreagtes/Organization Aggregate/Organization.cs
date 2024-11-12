using Domain.Common.Contracts;

namespace Domain.Aggreagtes.Organization_Aggregate;
public class Organization : AuditableEntity, IAggregateRoot
{
    public required string Name { get; set; }
    public ICollection<Department> Departments { get; set; } = new HashSet<Department>();


    #region Business Rules 
    public void UpdateDepartment(string newName, Guid newHeadOfStaffId, Guid departmentId)
    {
        var department = Departments.FirstOrDefault(d => d.Id == departmentId);
        if (department == null)
            throw new InvalidOperationException($"Department with ID {departmentId} not found.");

        if (Departments.Any(d => d.Name == newName && d.Id != departmentId))
            throw new InvalidOperationException($"A department with the name '{newName}' already exists in this organization.");

        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentNullException(nameof(newName), "Department name cannot be null or empty.");

        if (newHeadOfStaffId == Guid.Empty)
            throw new ArgumentException("HeadOfStaffId must be a valid non-empty GUID.", nameof(newHeadOfStaffId));

        department.UpdateDetails(newName, newHeadOfStaffId);
    }

    #endregion
}

