using ImportTool.DataAccess.Entities;
using ImportTool.DataAccess.Repositories.Interfaces;

namespace ImportTool.DataAccess.Repositories
{
    public class TwitterRepository : ITwitterRepository
    {
        public Twitter GetByName(string name)
        {
            return new Twitter
            {
                Name = name
            };
        }
    }
}
