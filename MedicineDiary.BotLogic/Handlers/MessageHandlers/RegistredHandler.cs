using MedicineDiary.BotLogic.Abstractions;
using MedicineDiary.Data.Abstraction;
using MedicineDiary.Models.Dto.Input;
using MedicineDiary.Models.Dto.Output;

namespace MedicineDiary.BotLogic.Handlers.MessageHandlers
{
    internal class RegistredHandler : HandlerBase, IHandler
    {
        public Task<HandlerOutput> HandleAsync(HandlerInput input)
        {
            throw new NotImplementedException();
        }

        public RegistredHandler(IDiaryRepository repository) : base(repository) { }
    }
}
