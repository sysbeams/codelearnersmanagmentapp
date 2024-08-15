using Application.Dtos;
using Application.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.Queries
{
    public class GetStudentEmail
    {

        public record Query : IRequest<StudentResponse>
        {
            public string? EmailAddress { get; set; }
        }

        public record StudentResponse(
            string StudentNumber,
            string FirstName,
            string LastName,
            string PhoneNumber,
            string EmailAddress,
            string Address,
            string SponsorName,
            string Message,
            bool IsSuccessful
            ) : BaseResponse(Message, IsSuccessful);
        public class Handler : IRequestHandler<Query, StudentResponse>
        {
            private readonly IStudentRepository _studentRepository;

            public Handler(IStudentRepository studentRepository)
            {
                _studentRepository = studentRepository;
            }

            public async Task<StudentResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                var student = await _studentRepository.GetStudentByAsync(s => s.EmailAddress == request.EmailAddress) ?? throw new NotFoundException("Student not found");
                var message = "Retrieved successfully";
                var address = $"Street: {student.Address.Street}, City: {student.Address.City}, State: {student.Address.State}, Country: {student.Address.Country}";

                return new StudentResponse(student.StudentNumber, student.Firstname, student.Lastname, student.PhoneNumber, student.EmailAddress, address, student.Sponsor?.Name, message, true);
            }
        }
    }
}
