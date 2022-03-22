using ImportTool.DataAccess.Entities;

namespace ImportTool.DataAccess.Repositories.Interfaces
{
    public interface ITagRepository
    {
        Tag GetByName(string name);
    }
}
