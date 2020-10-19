using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Models;

namespace Commander.Repository
{
    public interface ICommanderRepo
    {
        public IEnumerable<Models.Command> GetAllCommands();
        public Command GetCommandById(int id);
    }
}
