using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Certification
    {
        public string CertificationName { get; private set; } = default!;
        public string Issuer { get; private set; } = default!;
        public DateTime IssueDate { get; private set; }
        public DateTime ExpiryDate { get; private set; }

        #region Constructor
        private Certification() { }
        internal Certification(string certificationName, string issuer, DateTime issueDate, DateTime expiryDate)
        {
            CertificationName = certificationName;
            Issuer = issuer;
            IssueDate = issueDate;
            ExpiryDate = expiryDate;
        }
        #endregion

        #region Behaviour
        public static Certification CreateCertification(string certificationName, string issuer, DateTime issueDate, DateTime expiryDate)
            => new Certification(certificationName, issuer, issueDate, expiryDate);
        public void UpdateCertificationName(string certificationName) => CertificationName = certificationName;
        public void UpdateIssuer(string  issuer) => Issuer = issuer;
        public void UpdateIssueDate(DateTime issueDate) => IssueDate = issueDate;
        public void UpdateExpiryDate(DateTime expiryDate) => ExpiryDate = expiryDate;
        public override int GetHashCode() => HashCode.Combine(CertificationName, Issuer, IssueDate, ExpiryDate);
        public override bool Equals(object obj)
        {
            if (obj is not Certification other) return false;
            return CertificationName == other.CertificationName && 
                Issuer == other.Issuer &&
                IssueDate == other.IssueDate &&
                ExpiryDate == other.ExpiryDate;
        }
        #endregion
    }
}
