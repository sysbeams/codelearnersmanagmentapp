using Domain.Aggreagtes.UserAggregate;
using Domain.Exceptions;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }
        public User CreateUser(string userName,string emailAddress,string passwordHash,string passwordSalt)
        {
            if (_userRepository.IsExitByEmail(emailAddress))
            {
                throw new EmailDuplicateException($"This email {emailAddress} already exist in our system");
            }
            return new User(userName,emailAddress,passwordHash,passwordSalt);
        }

    }
}
