using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Models;

namespace Commander.Repository
{
    public interface ICommanderRepo
    {
        IEnumerable<Models.Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command cmd);
        bool SaveChanges();
        void UpdateCommand(Command cmd);
        void DeleteCommand(Command cmd);
    }
}
