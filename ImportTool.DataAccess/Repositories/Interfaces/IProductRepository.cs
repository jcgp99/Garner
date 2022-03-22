using ImportTool.DataAccess.Entities;

namespace ImportTool.DataAccess.Repositories.Interfaces
{
    public interface IProductRepository
    {
        void Save(Product product);
    }
}
