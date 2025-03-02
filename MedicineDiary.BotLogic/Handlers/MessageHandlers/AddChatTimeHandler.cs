using MedicineDiary.BotLogic.Abstractions;
using MedicineDiary.Data.Abstraction;
using MedicineDiary.Models.Dto.Input;
using MedicineDiary.Models.Dto.Output;
using MedicineDiary.Models.Enums;

namespace MedicineDiary.BotLogic.Handlers.MessageHandlers
{
    internal class AddChatTimeHandler : HandlerBase, IHandler
    {
        public async Task<HandlerOutput> HandleAsync(HandlerInput input)
        {
            var output = new HandlerOutput();
            return output;
        }
        public AddChatTimeHandler(IDiaryRepository repository) : base(repository) { }
    }
}
