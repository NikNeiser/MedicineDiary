using MedicineDiary.BotLogic.Abstractions;
using MedicineDiary.Data.Abstraction;
using MedicineDiary.Models.Enums;
using System.Globalization;

namespace MedicineDiary.BotLogic.Handlers.ComandHandlers
{
    internal class ChangeLanguageComandHandler : HandlerBase, IHandler
    {
        public async Task<string> HandleAsync(long chatId, string message)
        {
            return null;
        }
        public ChangeLanguageComandHandler(IDiaryRepository repository) : base(repository) { }
    }
}
