using Rcbi.IdentityServer.Interfaces.Repositories;
using Rcbi.IdentityServer.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

using Rcbi.Business;

namespace Rcbi.IdentityServer.Repositories.UserAggregate.InDatabase
{
    public class UserInDatabaseRepository : IUserRepository
    {
        Task IUserRepository.AddAsync(User entity, string password)
        {
            throw new NotImplementedException();
        }

        Task IUserRepository.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<User> IUserRepository.GetAsync(string username)
        {
            var user = UserBll.GetUser(username);

            return Task.FromResult(new User(user.UserId, user.UserName, user.Email));
        }

        Task<User> IUserRepository.GetAsync(string username, string password)
        {
            var user = UserBll.GetUser(username, password);

            return Task.FromResult(new User(user.UserId, user.UserName, user.Email));
        }

        Task<User> IUserRepository.GetAsync(int id)
        {
            var user = UserBll.GetUser(id);

            return Task.FromResult(new User(user.UserId, user.UserName, user.Email));
        }

        Task IUserRepository.UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
