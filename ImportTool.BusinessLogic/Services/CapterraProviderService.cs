using ImportTool.BusinessLogic.Models;
using ImportTool.BusinessLogic.Services.Interfaces;
using System;
using System.Linq;

namespace ImportTool.BusinessLogic.Services
{
    public class CapterraProviderService : IProviderService
    {
        public readonly IFileService _fileService;
        public readonly IProductService _productService;

        public CapterraProviderService(IFileService fileService, IProductService productService)
        {
            _fileService = fileService;
            _productService = productService;
        }

        public void Import(string uri)
        {
            var file = _fileService.GetFile(uri);
            if (file is null)
                return;

            string[] productObjects = file.Split('-');
            if (productObjects.Count() <= 4)
            {
                Console.WriteLine("There are not objects to import");
                return;
            }

            foreach(var productObject in productObjects.Skip(4))
            {
                var lines = productObject.Split(
                    new string[] { "\r\n", "\r", "\n" },
                    StringSplitOptions.None
                );
                if (lines.Count() <= 4)
                {
                    Console.WriteLine("The object format in file is wrong");
                    return;
                }

                lines = lines.Skip(1).ToArray();
                if (!ValidateLine("twitter: ", lines[2]) || !ValidateLine("name: ", lines[1]) || !ValidateLine("tags: ", lines[0]))
                {
                    Console.WriteLine("The object format in file is wrong");
                    return;
                }

                _productService.Save(new ImportModel
                {
                    ProductName = GetValue("name:", lines[1]),
                    TwitterName = GetValue("twitter:", lines[2]),
                    Tags = GetValue("tags: ", lines[0]).Split(',')
                });
            }
        }

        private string GetValue(string property, string line)
        {
            return line.Trim().Replace("\"", "").Remove(0, property.Count() + 1);
        }

        private bool ValidateLine(string property, string line)
        {
            return line.TrimStart().StartsWith(property);
        }
    }
}
