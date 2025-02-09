using MedicineDiary.BotLogic.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineDiary.BotLogic.Handlers
{
    internal class NoRegistredHandler : IHandler
    {
        public Task HandleAsync(string message)
        {
            throw new NotImplementedException();
        }
    }
}
