namespace Application.Dtos;

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
