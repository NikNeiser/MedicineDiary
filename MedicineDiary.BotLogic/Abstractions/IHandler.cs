using MedicineDiary.Models.Dto.Input;
using MedicineDiary.Models.Dto.Output;

namespace MedicineDiary.BotLogic.Abstractions
{
    public interface IHandler
    {
        Task<HandlerOutput> HandleAsync(HandlerInput input);
    }
}
