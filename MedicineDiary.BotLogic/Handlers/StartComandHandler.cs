using MedicineDiary.BotLogic.Abstractions;
using MedicineDiary.Data.Abstraction;
using MedicineDiary.Models.Enums;
using System.Globalization;

namespace MedicineDiary.BotLogic.Handlers
{
    internal class StartComandHandler : HandlerBase, IHandler
    {
        public async Task<string> HandleAsync(long chatId, string message)
        {
            return null;
        }
        public StartComandHandler(IDiaryRepository repository): base(repository) { }
    }
}
