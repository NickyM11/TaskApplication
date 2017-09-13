using TaskApplication.DataAccessLayer;

namespace TaskApplication.Services
{
    public interface IService
    {
        void Save(TaskDbContext db);
    }
}
