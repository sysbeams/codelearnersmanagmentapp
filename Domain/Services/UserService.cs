using BCrypt.Net;
using Domain.Aggreagtes.UserAggregate;
using Domain.Exceptions;
using Domain.Repositories;
using System;

namespace Domain.Services;
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User CreateUser(string userName, string emailAddress, string password)
        {
            if (_userRepository.IsExitByEmail(emailAddress))
            {
                throw new EmailDuplicateException($"This email {emailAddress} already exists in our system");
            }

            string passwordSalt = BCrypt.Net.BCrypt.GenerateSalt();

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password + passwordSalt);

            return new User(userName, emailAddress, passwordHash, passwordSalt);
        }
    }
