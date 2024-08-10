using System.Net;

namespace Application.Exceptions;
public class DuplicateException(string message) : Exception(message);