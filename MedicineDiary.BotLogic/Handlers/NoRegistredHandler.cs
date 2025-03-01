using MedicineDiary.BotLogic.Abstractions;
using MedicineDiary.Data.Abstraction;
using MedicineDiary.Models.Enums;
using System.Globalization;

namespace MedicineDiary.BotLogic.Handlers
{
    internal class NoRegistredHandler : HandlerBase, IHandler
    {
        public async Task<string> HandleAsync(long chatId, string message)
        {
            var culture = new CultureInfo("en");
            await base._repository.SetChatState(chatId,ChatStateEnum.AddChatTime);
            return Resources.Resource.ResourceManager.GetString("GetTimeMessage", culture);
        }
        public NoRegistredHandler(IDiaryRepository repository): base(repository) { }
    }
}
