using System.Collections.Generic;

namespace ImportTool.BusinessLogic.Models
{
    public class ProductJsonModel
    {
        public string Twitter { get; set; }
        public string Title { get; set; }
        public IList<string> Categories { get; set; }
    }
}
