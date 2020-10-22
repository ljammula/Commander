using System.Collections.Generic;
using AutoMapper;
using Commander.Dto;
using Commander.Models;
using Commander.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("/api/commands/v1")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo commanderRepo, IMapper mapper)
        {
            _repository = commanderRepo;
            _mapper = mapper;
        }


        //Get /v1/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandResponseDto>> GetAllCommands()
        {
            var commands = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandResponseDto>>(commands));
        }

        //Get /v1/commands/{id}
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandResponseDto> GetCommandById(int id)
        {
            var command = _repository.GetCommandById(id);
            if(command != null)
            {
                return Ok(_mapper.Map<CommandResponseDto>(command));
            }

            return NotFound();
        }

        //Post /v1/commands
        [HttpPost]
        public ActionResult<CommandResponseDto> CreateCommand(CommandRequestDto request)
        {
            var commandModel = _mapper.Map<Command>(request);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();
            var commandResponse = _mapper.Map<CommandResponseDto>(commandModel);
            return CreatedAtRoute(nameof(GetCommandById), new {commandResponse.Id}, commandResponse);
        }

        //Put /v1/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandRequestDto request)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }
            //existing object mapping. source -> destination
            _mapper.Map(request, commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        //Patch /v1/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandRequestDto> patchDocument)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandRequestDto>(commandModelFromRepo);
            patchDocument.ApplyTo(commandToPatch, ModelState);
            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        //Get /v1/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommandById(int id)
        {
            var command = _repository.GetCommandById(id);
            if (command == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(command);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}
