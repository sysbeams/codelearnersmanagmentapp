namespace Application.Dtos;

public record GetStudentsResponse(string Message, bool IsSuccessful, IEnumerable<StudentResponse> Data)
    : BaseResponse(Message, IsSuccessful);
