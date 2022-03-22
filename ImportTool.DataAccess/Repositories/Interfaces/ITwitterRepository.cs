using ImportTool.DataAccess.Entities;

namespace ImportTool.DataAccess.Repositories.Interfaces
{
    public interface ITwitterRepository
    {
        Twitter GetByName(string name);
    }
}
