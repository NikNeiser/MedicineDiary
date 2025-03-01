using MedicineDiary.BotLogic.Abstractions;
using MedicineDiary.Data.Abstraction;
using MedicineDiary.Models.Enums;

namespace MedicineDiary.BotLogic.Handlers.MessageHandlers
{
    internal class AddChatTimeHandler : HandlerBase, IHandler
    {
        public async Task<string> HandleAsync(long chatId, string message)
        {
            await _repository.SetChatState(chatId, ChatStateEnum.AddChatTime);
            return Resources.Resource.TimeSet_Success;
            //return "TimeSet_WrongTimeFormat";
            //return "TimeSet_WrongTimeRange";
        }
        public AddChatTimeHandler(IDiaryRepository repository) : base(repository) { }
    }
}
