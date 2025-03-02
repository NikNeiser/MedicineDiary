using MedicineDiary.Models.Dto.Input;

namespace MedicineDiary.BotLogic.Abstractions
{
    public interface IHandler
    {
        Task<string> HandleAsync(HandlerInput input);
    }
}
