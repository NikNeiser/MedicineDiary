using MedicineDiary.BotLogic.Abstractions;
using MedicineDiary.BotLogic.Handlers.ComandHandlers;
using MedicineDiary.BotLogic.Handlers.MessageHandlers;
using MedicineDiary.Data.Abstraction;
using MedicineDiary.Models.Enums;

namespace MedicineDiary.BotLogic.Handlers
{
    public static class HandlerFactory
    {
        public static Dictionary<ChatStateEnum, IHandler> GetMessageHandlers( IDiaryRepository repository) =>
            new Dictionary<ChatStateEnum, IHandler> {
                { ChatStateEnum.NoRegistred, new NoRegistredHandler(repository) },
                { ChatStateEnum.Registred, new RegistredHandler(repository) }
            };

        public static Dictionary<BotComandsEnum, IHandler> GetComandsHandlers(IDiaryRepository repository) =>
            new Dictionary<BotComandsEnum, IHandler> {
                { BotComandsEnum.changeLanguage, new ChangeLanguageComandHandler(repository) },
                { BotComandsEnum.start, new StartComandHandler(repository) }
    };
    }
}
