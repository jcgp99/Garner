using ImportTool.BusinessLogic.Validators;
using System.Collections.Generic;
using Xunit;

namespace ImportTool.UnitTest.Validators
{
    public class CommandValidatorTests
    {
        public CommandValidator CommandValidator;

        public CommandValidatorTests()
        {
            CommandValidator = new CommandValidator();
        }

        [Fact]
        public void GivenArray_Empty_InvalidCommand()
        {
            var param = new List<string>
            {
                "Import",
                "Url"
            }.ToArray();

            var result = CommandValidator.Validate(param);

            Assert.False(result);
        }

        [Fact]
        public void GivenArray_MissingCommandPArt_InvalidCommand()
        {
            var param = new List<string>().ToArray();

            var result = CommandValidator.Validate(param);

            Assert.False(result);
        }

        [Fact]
        public void GivenArray_WrongCommandName_InvalidCommand()
        {
            var param = new List<string>
            {
                "Export",
                "Value",
                "Url"
            }.ToArray();

            var result = CommandValidator.Validate(param);

            Assert.False(result);
        }

        [Fact]
        public void GivenArray_RightFormatAndCommandName_InvalidCommand()
        {
            var param = new List<string>
            {
                "Import",
                "Value",
                "Url"
            }.ToArray();

            var result = CommandValidator.Validate(param);

            Assert.False(result);
        }

    }
}
