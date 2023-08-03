using Application.Interfaces;
using Domain.Entities;
using Persistance.Context;

namespace Persistance.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
