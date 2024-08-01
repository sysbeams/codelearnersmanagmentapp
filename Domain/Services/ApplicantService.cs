using Domain.Aggreagtes.ApplicantAggregate;
using Domain.Exceptions;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services;
    public class ApplicantService
    {
        private readonly IApplicantRepository _applicant;
        public ApplicantService(IApplicantRepository applicant) => _applicant = applicant;

        public Applicant CreateApplicant(string firstName, string lastName, string emailAddress)
        {
           if(_applicant.IsExitByEmail(emailAddress))
            {
                 throw new EmailDuplicateException($"This email {emailAddress} already exist in our system");
            }

            return new Applicant(firstName, lastName, emailAddress);
        }
    }
