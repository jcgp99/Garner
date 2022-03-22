using ImportTool.BusinessLogic.Services;
using ImportTool.BusinessLogic.Services.Interfaces;
using ImportTool.BusinessLogic.Validators;
using ImportTool.DataAccess.Repositories;
using System;
namespace ImportTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("write your import command");
            var commandValidator = new CommandValidator();
            while (true)
            {
                var command = Console.ReadLine();
                var commandParts = command.Split(' ');
                if (commandValidator.Validate(commandParts))
                {
                    var provider = GetProvider(commandParts[1]);
                    if (provider == null)
                    {
                        Console.WriteLine("not provider found");
                        continue;
                    }
                    
                    provider.Import(commandParts[2]);
                }
            }
        }

        private static IProviderService GetProvider(string providerName)
        {
            var twitterRepository = new TwitterRepository();
            var tagRepository = new TagRepository();
            var productRepository = new ProductRepository();
            var productService = new ProductService(twitterRepository, tagRepository, productRepository);
            var fileService = new FileService();
            switch (providerName)
            {
                case "capterra":
                    return new CapterraProviderService(fileService, productService);
                case "softwareadvice":
                    return new SofwareAdviceProviderService(fileService, productService);
                default:
                    return null;
            };
        }
    }
}
