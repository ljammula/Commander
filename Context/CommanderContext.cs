﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Context
{
    public class CommanderContext: DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        {

        }

        public DbSet<Command> Commands { get; set; }
    }
}
