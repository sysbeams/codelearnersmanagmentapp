namespace Application.Dtos;

public record GetStudentResponse(string message, bool isSuccessful, CreateStudentResponse Data) : BaseResponse(message, isSuccessful);
