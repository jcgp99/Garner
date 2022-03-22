using ImportTool.BusinessLogic.Models;
using ImportTool.BusinessLogic.Services.Interfaces;
using ImportTool.DataAccess.Entities;
using ImportTool.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;

namespace ImportTool.BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        public readonly ITwitterRepository _twitterRepository;
        public readonly ITagRepository _tagRepository;
        public readonly IProductRepository _productRepository;

        public ProductService(ITwitterRepository twitterRepository, ITagRepository tagRepository, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _tagRepository = tagRepository;
            _twitterRepository = twitterRepository;
        }

        public void Save(ImportModel model)
        {
            var twitter = _twitterRepository.GetByName(model.TwitterName);
            var tags = new List<Tag>();
            foreach(var tag in model.Tags)
            {
                tags.Add(_tagRepository.GetByName(tag));
            }

            _productRepository.Save(new Product
            {
                Tags = tags,
                Twitter = twitter,
                Name = model.ProductName
            });
        }
    }
}
