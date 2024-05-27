using System.Net;

namespace Application.Exceptions;
public class UnauthorizedException(string message) : Exception(message);
