using MedicineDiary.BotLogic.Abstractions;
using MedicineDiary.Data.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineDiary.BotLogic.Handlers.MessageHandlers
{
    internal class RegistredHandler : HandlerBase, IHandler
    {
        public Task<string> HandleAsync(long chatId, string message)
        {
            throw new NotImplementedException();
        }

        public RegistredHandler(IDiaryRepository repository) : base(repository) { }
    }
}
