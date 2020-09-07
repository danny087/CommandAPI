using System.Collections.Generic;
using CommandAPI.DBContext;
using CommandAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommandAPI.controllers {
    
    [Route("api/commands")]
    [ApiController]
    public class CommandsController: ControllerBase
    {
        private readonly CommandContext _context;
        
         public CommandsController(CommandContext context) => _context = context;

        [HttpGet]
        public ActionResult<IEnumerable<Command>> Get() 
        {
            return _context.CommandItems;
        }
    }
}