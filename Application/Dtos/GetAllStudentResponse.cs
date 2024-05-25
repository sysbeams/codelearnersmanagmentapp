namespace Application.Dtos;

public class GetAllStudentResponse(string Message, bool IsSuccessful, IEnumerable<CreateStudentResponse> Data)
    : BaseResponse(Message, IsSuccessful);
