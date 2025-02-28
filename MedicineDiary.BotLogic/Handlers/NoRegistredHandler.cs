using MedicineDiary.BotLogic.Abstractions;
using MedicineDiary.Data.Abstraction;
using MedicineDiary.Models.Enums;

namespace MedicineDiary.BotLogic.Handlers
{
    internal class NoRegistredHandler : HandlerBase, IHandler
    {
        public async Task<string> HandleAsync(long chatId, string message)
        {
            await base._repository.SetChatState(chatId,ChatStateEnum.AddChatTime);
            return Resources.Resource.GetTimeMessage;
        }
        public NoRegistredHandler(IDiaryRepository repository): base(repository) { }
    }
}
