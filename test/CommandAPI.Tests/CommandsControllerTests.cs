using System;
using System.Linq;
using CommandAPI.controllers;
using CommandAPI.DBContext;
using CommandAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CommandAPI.Tests
{
    public class CommandsControllerTests : IDisposable
    {
        DbContextOptionsBuilder<CommandContext> optionsBuilder;
        CommandContext dbContext;
        CommandsController controller;

        public CommandsControllerTests() {
            optionsBuilder = new DbContextOptionsBuilder<CommandContext>();
            optionsBuilder.UseInMemoryDatabase("UnitTestInMemBD");
            dbContext = new CommandContext(optionsBuilder.Options);
            controller = new CommandsController(dbContext);
        }

        public void Dispose() {
            optionsBuilder = null;
            foreach(var cmd in dbContext.CommandItems)
            {
                dbContext.CommandItems.Remove(cmd);
            }
            dbContext.SaveChanges();
            dbContext.Dispose();
            controller = null;
        }

        [Fact]
        public void GetCommandItems_ReturnsZeroItems_WhenDbIsEmpty() {
            
            var result = controller.Get();

            Assert.Empty(result.Value);
        }

        [Fact]
        public void GetCommandItemsReturnsOneItemWhenDBHasOneObject() 
        {
            var command = new Command{
                HowTo = "test",
                Platform = "test",
                CommandLine = "test"
            };
            dbContext.CommandItems.Add(command);
            dbContext.SaveChanges();

            var result = controller.Get();

            Assert.Single(result.Value);
        }

        [Fact]
        public void GetCommandItemsReturnsNItemsWhenDBHasNoObject() 
        {
            var command = new Command{
                HowTo = "test",
                Platform = "test",
                CommandLine = "test"
            };

            var command1 = new Command{
                HowTo = "test1",
                Platform = "test1",
                CommandLine = "test1"
            };
            dbContext.CommandItems.Add(command);
            dbContext.CommandItems.Add(command1);
            dbContext.SaveChanges();

            var result = controller.Get();

            Assert.Equal(2,result.Value.Count());
        }

        [Fact]
        public void GetByIdReturnsNullWhenInvaildId() 
        {
            var result = controller.GetById(new Guid("cb74f5be-a032-4047-80f0-99c5edda037e"));

            Assert.Null(result.Value);
        }

        [Fact]
        public void GetByIdReturns404NotFoundWhenInvaildId() 
        {
            var result = controller.GetById(new Guid("cb74f5be-a032-4047-80f0-99c5edda037d"));

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void GetByIdReturnsCorrectType() 
        {

            var command = new Command{
                HowTo = "test",
                Platform = "test",
                CommandLine = "test"
            };
            dbContext.CommandItems.Add(command);
            dbContext.SaveChanges();
            var commandId = command.CommandId;
            var result = controller.GetById(commandId);

            Assert.IsType<ActionResult<Command>>(result);
        }
    }
}