using ImportTool.BusinessLogic.Models;
using ImportTool.BusinessLogic.Services.Interfaces;
using Newtonsoft.Json;
using System;

namespace ImportTool.BusinessLogic.Services
{
    public class SofwareAdviceProviderService : IProviderService
    {
        public readonly IFileService _fileService;
        public readonly IProductService _productService;

        public SofwareAdviceProviderService(IFileService fileService, IProductService productService)
        {
            _fileService = fileService;
            _productService = productService;
        }

        public void Import(string uri)
        {
            var file = _fileService.GetFile(uri);
            if (file is null)
                return;

            SofwareAdviceJsonModel json = null;
            try
            {
                json = JsonConvert.DeserializeObject<SofwareAdviceJsonModel>(file);
            }
            catch (System.Exception)
            {
                Console.WriteLine("Error in json");
                return;
            }
            
            foreach (var product in json.Products)
            {
                _productService.Save(new ImportModel
                {
                    ProductName = product.Title,
                    TwitterName = product.Twitter,
                    Tags = product.Categories
                });
            }
        }
    }
}
