using MedicineDiary.BotLogic.Abstractions;
using MedicineDiary.Data.Abstraction;
using MedicineDiary.Models.Dto.Input;
using MedicineDiary.Models.Dto.Output;
using MedicineDiary.Models.Enums;
using System.Globalization;

namespace MedicineDiary.BotLogic.Handlers.MessageHandlers
{
    internal class ChangeLanguageHandler : HandlerBase, IHandler
    {
        public async Task<HandlerOutput> HandleAsync(HandlerInput input)
        { 
            //Если поступил непотдерживаемый язык
            if (Enum.TryParse<LanguageEnum>(input.Language.ToLower(), out var language))
            {
                var erroranswer = new HandlerOutput
                {
                    AnswerVariants = Enum.GetValues(typeof(LanguageEnum)).Cast<string>().ToList(),
                    Message = string.Format(
                        Resources.Resource.LanguageSet_WrongLanguage,
                        string.Join(", ",Enum.GetNames(typeof(LanguageEnum))))                        
                };

                return erroranswer;
            }

            var newLang =  await _repository.SetChatLanguage(input.ChatId, language);

            var culture = newLang.ToString() == LanguageEnum.ru.ToString() ?
            CultureInfo.CurrentCulture :
            new CultureInfo(newLang.ToString());

            var output = new HandlerOutput {
                Message = Resources.Resource.ResourceManager.GetString("LanguageSet_Success", culture)
            };

            return output;
        }
        public ChangeLanguageHandler(IDiaryRepository repository) : base(repository) { }
    }
}
