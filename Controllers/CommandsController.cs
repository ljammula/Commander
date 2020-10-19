using System.Collections.Generic;
using Commander.Models;
using Commander.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("/api/commands/v1")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;

        public CommandsController(ICommanderRepo commaderRepo)
        {
            _repository = commaderRepo;
        }


        //Get /v1/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commands = _repository.GetAllCommands();
            return Ok(commands);
        }

        //Get /v1/commands/{id}
        [HttpGet("{Id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            return Ok(_repository.GetCommandById(id));
        }
    }
}
