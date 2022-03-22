using ImportTool.BusinessLogic.Validators.Interfaces;
using System;
using System.Linq;

namespace ImportTool.BusinessLogic.Validators
{
    public class CommandValidator : IValidator<string[]>
    {
        public bool Validate(string[] param)
        {
            if (param.Count() != 3)
            {
                Console.WriteLine("The command doesn't have the right format");
                return false;
            }

            if (!param[0].Equals("import"))
            {
                Console.WriteLine("The command action is not implemented");
                return false;
            }

             return true;
        }
    }
}
