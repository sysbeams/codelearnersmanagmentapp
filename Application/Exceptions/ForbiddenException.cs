using System.Net;

namespace Application.Exceptions;
public class ForbiddenException(string message) : Exception(message);