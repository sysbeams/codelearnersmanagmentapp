namespace Application.Dtos;

public class GetStudentResponse(string message, bool isSuccessful, CreateStudentResponse Data) : BaseResponse(message, isSuccessful);
