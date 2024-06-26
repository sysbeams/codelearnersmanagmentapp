using System.Linq.Expressions;
using Domain.Aggreagtes.ApplicantAggregate;
using Domain.Aggreagtes.CourseAggregate;
using Domain.Aggreagtes.StudentAggregate;
using Domain.Exceptions;
using Domain.Repositories;



namespace Domain.Services
{
    public class ApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;
        public ApplicantService(IApplicantRepository applicantRepository) { 
            _applicantRepository = applicantRepository;
        }

        public async Task<Applicant> CreateApplicant(Applicant newApplicant)
        {
            ValidateApplicant(newApplicant);
            var existingApplicant = await _applicantRepository.GetApplicantAsync(a => a.EmailAddress == newApplicant.EmailAddress);
            if (existingApplicant != null)
            {
                throw new DuplicateApplicantException("An applicant with the same email already exists");
            }
            return new Applicant(newApplicant.Firstname,newApplicant.Lastname,newApplicant.EmailAddress);
        }

        private void ValidateApplicant(Applicant applicant)
        {
            if (applicant == null)
            {
                throw new ArgumentNullException(nameof(applicant), "New applicant cannot be null");
            }

            if (string.IsNullOrWhiteSpace(applicant.Firstname))
            {
                throw new ArgumentException("Applicant must have a first name");
            }

            if (string.IsNullOrWhiteSpace(applicant.Lastname))
            {
                throw new ArgumentException("Applicant must have a last name");
            }

            if (string.IsNullOrWhiteSpace(applicant.EmailAddress))
            {
                throw new EmailDuplicateException("Applicant must have an email");
            }
        }

            
        public async Task<Applicant> GetApplicantAsync(Expression<Func<Applicant, bool>> expression)
        {
            return await _applicantRepository.GetApplicantAsync(expression);
        }
         

    }
}
