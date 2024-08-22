
using Domain.Aggreagtes.ApplicantAggregate;
using Domain.Aggreagtes.CourseAggregate;
using Domain.Enums;
using Domain.Repositories;
using MediatR;


namespace Application.Commands
{
    public class RegisterSelectedCourseForApplicantCommand : IRequest<ApplicantEnrollmentResponse>
    {
        public Guid ApplicantId { get; init; }
        public Guid CourseId { get; init; }
        public Guid CourseAssessmentId { get; init; }
        public CourseMode CourseMode { get; init; }
        public AssessmentMode AssessmentMode { get; init; }
        public DateTime SubscriptionDate { get; init; }
    }
    public record ApplicantEnrollmentResponse(
        Guid Id, string applicantName, string RegisteredCourseName);

    public class Handler : IRequestHandler<RegisterSelectedCourseForApplicantCommand, ApplicantEnrollmentResponse>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IApplicantRepository _applicantRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(ICourseRepository courseRepository, IApplicantRepository applicantRepository, 
            IUnitOfWork unitOfWork)
        {
            _courseRepository = courseRepository;
            _applicantRepository = applicantRepository;
            _unitOfWork = unitOfWork;
        }
       
        public async Task<ApplicantEnrollmentResponse> Handle(RegisterSelectedCourseForApplicantCommand request,
            CancellationToken cancellationToken)
        {
            // fetch selected course 
            var course = await _courseRepository.GetByIdAsync(request.CourseId);

            //fetch logged-in applicant 
            var applicant = await _applicantRepository.GetApplicantAsync(a => a.Id == request.ApplicantId);

            var applicantEnrollment = new ApplicantEnrollment(request.ApplicantId, applicant,
                request.CourseId, course, request.SubscriptionDate,
                request.CourseMode, request.AssessmentMode, request.CourseAssessmentId, true
                );
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new ApplicantEnrollmentResponse(applicantEnrollment.Id, applicant.Fullname, 
                course.Name);

        }
    }
}
