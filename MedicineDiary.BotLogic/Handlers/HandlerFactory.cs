using MedicineDiary.BotLogic.Abstractions;
using MedicineDiary.Models.Enums;

namespace MedicineDiary.BotLogic.Handlers
{
    internal class HandlerFactory
    {
        private readonly Dictionary<ChatStateEnum, IHandler> _handlers;
        public HandlerFactory()
        {
            _handlers = new Dictionary<ChatStateEnum, IHandler> {
                { ChatStateEnum.NoRegistred, new NoRegistredHandler() },
                { ChatStateEnum.Registred, new RegistredHandler() }
            };
        }
    }
}
