using System.Collections.Generic;

namespace ImportTool.DataAccess.Entities
{
    public class Tag
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
