namespace Application.Dtos;

public record GetAllStudentResponse(string Message, bool IsSuccessful, IEnumerable<CreateStudentResponse> Data)
    : BaseResponse(Message, IsSuccessful);
