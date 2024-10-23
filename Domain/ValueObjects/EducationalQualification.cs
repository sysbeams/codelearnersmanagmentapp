using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class EducationalQualification
    {
        public string InstitutionName { get; private set; } = default!;
        public string InstitutionType { get; private set; } = default!;
        public string FieldOfStudy { get; private set; } = default!;
        public string DegreeName { get; private set; } = default!;
        public string DegreeType { get; private set; } = default!;
        public double Grade { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        #region Constructor
        private EducationalQualification() { }
        internal EducationalQualification(string institutionName, string institutionType, string fieldOfStudy, string degreeName, string degreeType, double grade, DateTime startDate, DateTime endDate)
        {
            InstitutionName = institutionName;
            InstitutionType = institutionType;
            FieldOfStudy = fieldOfStudy;
            DegreeName = degreeName;
            DegreeType = degreeType;
            Grade = grade;
            StartDate = startDate;
            EndDate = endDate;
        }
        #endregion

        #region Behaviour
        public static EducationalQualification CreateEducationalQualification(string institutionName, string institutionType, string fieldOfStudy, string degreeName, string degreeType, double grade, DateTime startDate, DateTime endDate)
            => new EducationalQualification(institutionName, institutionType, fieldOfStudy, degreeName, degreeType, grade, startDate, endDate);
        public void UpdateInstitutionName(string institutionName) => InstitutionName = institutionName;
        public void UpdateInstitutionType(string institutionType) => InstitutionType = institutionType;
        public void UpdateFieldOfStudy(string  fieldName) => FieldOfStudy = fieldName;
        public void UpdateDegreeName( string degreeName) => DegreeName = degreeName;
        public void UpdateDegreeType( string degreeType) => DegreeType = degreeType;
        public void UpdateGrade(double grade) => Grade = grade;
        public void UpdateStartDate(DateTime startDate) => StartDate = startDate;
        public void UpdateEndDate(DateTime endDate) => EndDate = endDate;
        public override int GetHashCode() => HashCode.Combine(InstitutionName, InstitutionType, FieldOfStudy, DegreeName, DegreeType, Grade, StartDate, EndDate);
        public override bool Equals(object obj)
        {
            if (obj is not EducationalQualification other) return false;
            return InstitutionName == other.InstitutionName &&
                InstitutionType == other.InstitutionType &&
                FieldOfStudy == other.FieldOfStudy &&
                DegreeName == other.DegreeName &&
                DegreeType == other.DegreeType &&
                Grade == other.Grade &&
                StartDate == other.StartDate &&
                EndDate == other.EndDate;
        }
        #endregion
    }
}
