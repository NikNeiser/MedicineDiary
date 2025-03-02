using MedicineDiary.BotLogic.Abstractions;
using MedicineDiary.Data.Abstraction;
using MedicineDiary.Models.Dto.Input;
using MedicineDiary.Models.Dto.Output;
using MedicineDiary.Models.Enums;
using System.Globalization;

namespace MedicineDiary.BotLogic.Handlers.ComandHandlers
{
    internal class StartComandHandler : HandlerBase, IHandler
    {
        public async Task<HandlerOutput> HandleAsync(HandlerInput input)
        {
            return null;
        }
        public StartComandHandler(IDiaryRepository repository) : base(repository) { }
    }
}
