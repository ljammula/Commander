using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Context;

namespace Commander.Repository
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;
        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        IEnumerable<Command> ICommanderRepo.GetAllCommands()
        {
           return _context.Commands.ToList();
        }

        Command ICommanderRepo.GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(cmd => cmd.Id == id);
        }

        void ICommanderRepo.CreateCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Add(cmd);
        }

        bool ICommanderRepo.SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        void ICommanderRepo.UpdateCommand(Command cmd)
        {
            //Nothing here as SaveChanges() takes care of persistence
        }

        void ICommanderRepo.DeleteCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Commands.Remove(cmd);
        }
    }
}
