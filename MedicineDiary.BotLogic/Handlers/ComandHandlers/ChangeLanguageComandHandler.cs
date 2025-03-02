using MedicineDiary.BotLogic.Abstractions;
using MedicineDiary.Data.Abstraction;
using MedicineDiary.Models.Dto.Input;
using MedicineDiary.Models.Dto.Output;
using MedicineDiary.Models.Enums;
using System.Globalization;

namespace MedicineDiary.BotLogic.Handlers.ComandHandlers
{
    internal class ChangeLanguageComandHandler : HandlerBase, IHandler
    {

        async Task<HandlerOutput> IHandler.HandleAsync(HandlerInput input)
        {
            await _repository.SetChatState(input.ChatId, ChatStateEnum.ChangeLanguage);

            var output = new HandlerOutput {
                AnswerVariants = Enum.GetValues(typeof(LanguageEnum)).Cast<string>().ToList(),
                Message = Resources.Resource.Change_Language
            };
            return output;
        }

        public ChangeLanguageComandHandler(IDiaryRepository repository) : base(repository) { }
    }
}
