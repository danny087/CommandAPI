using System;
using CommandAPI.Models;
using Xunit;

namespace CommandAPI.Tests
{
    public class CommandTests : IDisposable
    {
        Command testCommand;

        public CommandTests()
        {
            testCommand = new Command
            {
                HowTo = "Do somthing",
                Platform = "xUnit",
                CommandLine = "dotnet test"
            };
        }

        public void Dispose()
        {
            testCommand = null;
        }

        [Fact]
        public void CanChangeHowTo()
        {

            testCommand.HowTo = "i have changed";

            Assert.Equal("i have changed", testCommand.HowTo);
        }

        [Fact]
        public void CanChangePlatform()
        {

            testCommand.Platform = "i have changed";

            Assert.Equal("i have changed", testCommand.Platform);
        }

        [Fact]
        public void CanChangeCommandLine()
        {

            testCommand.CommandLine = "i have changed";

            Assert.Equal("i have changed", testCommand.CommandLine);
        }
    }
}