using System.Collections.Generic;

namespace ImportTool.BusinessLogic.Models
{
    public class ImportModel
    {
        public string TwitterName { get; set; }
        public string ProductName { get; set; }
        public IList<string> Tags { get; set; }
    }
}
