using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Biodata
    {
        public string FirstName { get; private set; } = default!;
        public string MiddleName { get; private set; } = default!;
        public string LastName { get; private set; } = default!;
        public Gender Gender { get; private set; }
        public DateOnly DateOfBirth { get; private set; }

        #region Constructor
        private Biodata() { }
        internal Biodata(string firstName, string middleName, string lastName, Gender gender, DateOnly dateOfBirth)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
        }
        #endregion

        #region Behaviour
        public static Biodata CreateBiodata(string firstName, string middleName, string lastName, Gender gender, DateOnly dateOfBirth)
            => new Biodata(firstName, middleName, lastName, gender, dateOfBirth);
        public void UpdateFirstName(string firstName) => FirstName = firstName;
        public void UpdateLastName(string lastName) => LastName = lastName;
        public void UpdateGender(Gender gender) => Gender = gender;
        public void UpdateDateOfBirth(DateOnly dateOfBirth) => DateOfBirth = dateOfBirth;
        public override int GetHashCode() => HashCode.Combine(FirstName, MiddleName, LastName, Gender, DateOfBirth);
        public override bool Equals(object obj)
        {
            if (obj is not Biodata other) return false;
            return FirstName == other.FirstName &&
                MiddleName == other.MiddleName &&
                LastName == other.LastName &&
                Gender == other.Gender &&
                DateOfBirth == other.DateOfBirth;
        }
        #endregion
    }
}
