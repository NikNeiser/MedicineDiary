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
            CultureInfo culture;
            //Если поступил текущий язык
            if (input.Language == input.Message)
            {
                culture = input.Language == LanguageEnum.ru.ToString() ?
                    CultureInfo.CurrentCulture :
                    new CultureInfo(input.Language);

                var answer = new HandlerOutput
                {
                    Message = string.Format(
                        Resources.Resource.ResourceManager.GetString("LanguageSet_NotRequired", culture),
                        input.Language)
                };

                return answer;
            }

            //Если поступил непотдерживаемый язык
            if (!Enum.TryParse<LanguageEnum>(input.Message.ToLower(), out var language))
            {
                var erroranswer = new HandlerOutput
                {
                    AnswerVariants = Enum.GetNames(typeof(LanguageEnum)).ToList<string>(),
                    Message = string.Format(
                        Resources.Resource.LanguageSet_WrongLanguage,
                        string.Join(", ",Enum.GetNames(typeof(LanguageEnum))))                        
                };

                return erroranswer;
            }

            var newLang =  await _repository.SetChatLanguage(input.ChatId, language);

            culture = newLang == LanguageEnum.ru ?
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
