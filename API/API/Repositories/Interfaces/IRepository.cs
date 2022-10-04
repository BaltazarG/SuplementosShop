namespace API.Repositories.Interfaces
{
    public interface IRepository
    {
        public Task<bool> SaveChanges();

    }
}
