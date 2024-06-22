using Application.Contracts.Services;
using Application.Dtos;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class LogInService : ILogInService
    {
        private readonly IUserRepository _userRepository;
        public LogInService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<LoginResponse> Login(LoginRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
