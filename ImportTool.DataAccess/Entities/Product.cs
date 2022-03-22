using System.Collections.Generic;

namespace ImportTool.DataAccess.Entities
{
    public class Product
    {
        public string Name { get; set; }
        public Twitter Twitter { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
