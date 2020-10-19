using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Repository
{
    public class MockCommanderRepo : ICommanderRepo
    {
        IEnumerable<Command> ICommanderRepo.GetAllCommands()
        {
            var commands = new List<Command>();
            Command c1 = new Command
                {Id = 0, HowTo = "Make Tea", Line = "Boil Milk, Add Sugar, Add Tea powder", Platform = "Stove"};
            commands.Add(c1);
            Command c2 = new Command {Id = 1, HowTo = "Make Coffee", Line = "Add Coffee Powder", Platform = "Stove"};
            commands.Add(c2);

            // var commands = new List<Command>
            // {
            //     new Command
            //     {
            //         Id = 0, HowTo = "Make Tea", Line = "Boil Milk, Add Sugar, Add Tea powder", Platform = "Stove"
            //     },
            //     new Command {Id = 1, HowTo = "Make Coffee", Line = "Add Coffee Powder", Platform = "Stove"};
            // }

            return commands;
        }

        Command ICommanderRepo.GetCommandById(int id)
        {
            return new Command
                {Id = 0, HowTo = "Make Tea", Line = "Boil Milk, Add Sugar, Add Tea powder", Platform = "Stove"};
        }
    }
}