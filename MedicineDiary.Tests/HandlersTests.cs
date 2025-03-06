using MedicineDiary.BotLogic.Abstractions;
using MedicineDiary.BotLogic.Handlers;
using MedicineDiary.BotLogic.Handlers.MessageHandlers;
using MedicineDiary.Data;
using MedicineDiary.Data.Abstraction;
using MedicineDiary.Models.Dto.Input;
using MedicineDiary.Models.Enums;
using Xunit.Abstractions;

namespace MedicineDiary.Tests
{
    public class HandlersTests : BaseTest
    {
        private readonly IDiaryRepository _repository;
        private readonly Dictionary<ChatStateEnum, IHandler> _handlers;
        private const long _chatId = -1;
        private readonly ITestOutputHelper _output;

        public HandlersTests(ITestOutputHelper output)
        {
            _repository = new RepositoryFactory().GetDiaryRepository(base.dbConnection, MessengerEnum.telegram);
            _handlers = HandlerFactory.GetMessageHandlers(_repository);
            _repository.GetChatState(_chatId);
            _output = output;
        }

        [Theory]
        [InlineData(LanguageEnum.ru)]
        [InlineData(LanguageEnum.en)]
        public async void NoRegistredHandlerTest(LanguageEnum language)
        {
            var input = new HandlerInput
            {
                ChatId = _chatId,
                Message = "trololo",
                Language = language.ToString()
            };

            var result = await _handlers[ChatStateEnum.NoRegistred].HandleAsync(input);
            _output.WriteLine(result.Message);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("viaudhvin","ru")]
        [InlineData("viaudhvin", "en")]
        [InlineData("en", "ru")]
        [InlineData("en", "en")]
        [InlineData("ru","en")]
        [InlineData("ru", "ru")]
        public async void ChangeLanguageHandlerTest(string language, string currentLanguage)
        {
            var input = new HandlerInput
            {
                ChatId = _chatId,
                Message = language,
                Language = currentLanguage
            };

            var result = await _handlers[ChatStateEnum.ChangeLanguage].HandleAsync(input);
            _output.WriteLine(result.Message);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("viaudhvin", "ru")]
        [InlineData("viaudhvin", "en")]
        [InlineData("10 l;50", "ru")]
        [InlineData("10 55", "en")]
        [InlineData("3001", "en")]
        [InlineData("1165", "ru")]
        public async void AddChatTimeHandlerTest(string time, string currentLanguage)
        {
            var input = new HandlerInput
            {
                ChatId = _chatId,
                Message = time,
                Language = currentLanguage
            };

            var result = await _handlers[ChatStateEnum.AddChatTime].HandleAsync(input);
            _output.WriteLine(result.Message);
            Assert.NotNull(result);
        }

    }
}
