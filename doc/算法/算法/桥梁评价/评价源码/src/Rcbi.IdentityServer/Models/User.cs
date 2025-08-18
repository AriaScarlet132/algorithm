using Rcbi.Domain.Models;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.IdentityServer.Models
{
    public class User : DomainEntity<int>
    {
        public string Username { get; private set; }
        public string Email { get; private set; }
        public Instant Created { get; private set; }
        public bool IsActive { get; private set; }

        public User(int id, string username, string email)
            : this(id, username, email, SystemClock.Instance.GetCurrentInstant(), true)
        {

        }

        private User(int id, string username, string email, Instant created, bool isActive)
            : base(id)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException($"The username [{nameof(username)}] is either null or empty.");
            }
            if (username.Length < 3)
            {
                throw new ArgumentException($"The username [{nameof(username)}] is too short.");
            }
            if (username.Length > 16)
            {
                throw new ArgumentException($"The username [{nameof(username)}] is too long.");
            }         
          

            Username = username;
            Email = email;
            Created = created;
            IsActive = isActive;
        }

        public static User Hydrate(int id, string username, string email, Instant created, bool isActive)
        {
            return new User(id, username, email, created, isActive);
        }
    }
}
