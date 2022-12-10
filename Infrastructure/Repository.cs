using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext DbContext { get; private set; }

        public Repository(DbContext dbContext)
        {
            DbContext = dbContext;
        }


    }
}
