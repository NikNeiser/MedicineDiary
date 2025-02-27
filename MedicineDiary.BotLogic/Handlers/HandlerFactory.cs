using MedicineDiary.BotLogic.Abstractions;
using MedicineDiary.Data.Abstraction;
using MedicineDiary.Models.Enums;

namespace MedicineDiary.BotLogic.Handlers
{
    public static class HandlerFactory
    {
        public static Dictionary<ChatStateEnum, IHandler> GetHandlers( IDiaryRepository repository) =>
            new Dictionary<ChatStateEnum, IHandler> {
                { ChatStateEnum.NoRegistred, new NoRegistredHandler(repository) },
                { ChatStateEnum.Registred, new RegistredHandler(repository) }
            };
    }
}
