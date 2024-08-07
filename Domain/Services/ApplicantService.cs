using Domain.Aggreagtes.ApplicantAggregate;
using Domain.Exceptions;
using Domain.Repositories;

namespace Domain.Services;
public class ApplicantService
    {
        private readonly IApplicantRepository _applicant;
        public ApplicantService(IApplicantRepository applicant) => _applicant = applicant;

        public Applicant CreateApplicant(string firstName, string lastName, string emailAddress, Guid userId)
        {
           if(_applicant.IsExitByEmail(emailAddress))
            {
                 throw new EmailDuplicateException($"This email {emailAddress} already exist in our system");
            }

            return new Applicant(firstName, lastName, emailAddress, userId);
        }
    }
