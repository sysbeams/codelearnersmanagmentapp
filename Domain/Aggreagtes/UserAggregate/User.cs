using Domain.Common.Contracts;

namespace Domain.Aggreagtes.UserAggregate;
    public class User : AuditableEntity, IAggregateRoot
    {
        public string UserName { get; private set; } = default!;
        public string EmailAddress { get; private set; } = default!;
        public string PasswordHash { get; private set; } = default!;
        public string PasswordSalt { get; private set; } = default!;

        #region Constructor
        private User () { }

        internal User(string userName, string emailAddress,string passwordHash, string passwordSalt) 
        {
            UserName = userName;
            EmailAddress = emailAddress;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
        #endregion

    }

