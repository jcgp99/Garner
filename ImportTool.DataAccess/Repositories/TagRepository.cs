using ImportTool.DataAccess.Entities;
using ImportTool.DataAccess.Repositories.Interfaces;

namespace ImportTool.DataAccess.Repositories
{
    public class TagRepository : ITagRepository
    {
        public Tag GetByName(string name)
        {
            return new Tag
            {
                Name = name
            };
        }
    }
}
