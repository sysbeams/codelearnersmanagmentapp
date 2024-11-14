using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTest.Domain.Aggregate.ApplicantAggregateTest.UnitTestApplicant
{
    internal class ApplicantData
    {
        public static readonly string firstName = "Christy";
        public static readonly string lastName = "Patrick";
        public static readonly string middleName = "Noah"; 
        public static readonly string phonenumber = "090876543";
        public static readonly string emailAddress = "christy@yahoomail.com";
        public static readonly Guid userId = Guid.NewGuid();
        public static readonly int streetNo = 4589;
        public static readonly string streetName = "St paul";
        public static readonly string city = "Warry";
        public static readonly string state = "Lagos";
        public static readonly string country = "Nigeria";

    }
}

