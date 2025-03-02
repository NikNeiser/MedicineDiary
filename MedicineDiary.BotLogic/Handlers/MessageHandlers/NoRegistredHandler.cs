using MedicineDiary.BotLogic.Abstractions;
using MedicineDiary.Data.Abstraction;
using MedicineDiary.Models.Dto.Input;
using MedicineDiary.Models.Dto.Output;
using MedicineDiary.Models.Enums;
using System.Globalization;

namespace MedicineDiary.BotLogic.Handlers.MessageHandlers
{
    internal class NoRegistredHandler : HandlerBase, IHandler
    {
        public async Task<HandlerOutput> HandleAsync(HandlerInput input)
        {
            var culture = input.Language == "ru" ?
                CultureInfo.CurrentCulture :
                new CultureInfo(input.Language);

            await _repository.SetChatState(input.ChatId, ChatStateEnum.AddChatTime);

            var output = new HandlerOutput {
                Message = Resources.Resource.ResourceManager.GetString("GetTimeMessage", culture)
            };

            return output;
        }
        public NoRegistredHandler(IDiaryRepository repository) : base(repository) { }
    }
}
