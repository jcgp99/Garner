using ImportTool.BusinessLogic.Services.Interfaces;
using System;
using System.IO;

namespace ImportTool.BusinessLogic.Services
{
    public class FileService : IFileService
    {
        public string GetFile(string uri)
        {
            try
            {
                return File.ReadAllText(uri);
            }
            catch (System.Exception)
            {
                Console.WriteLine("Not File Found");
                return null;
            }
        }
    }
}
