using CI.Data.Models;
namespace CI.Data.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        internal UserRepository(CIContext context, UnitOfWork unitOfWork) : base(context, unitOfWork) { }
    }
}