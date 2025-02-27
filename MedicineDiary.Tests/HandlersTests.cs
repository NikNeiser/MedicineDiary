using MedicineDiary.BotLogic.Abstractions;
using MedicineDiary.BotLogic.Handlers;
using MedicineDiary.Data;
using MedicineDiary.Data.Abstraction;
using MedicineDiary.Models.Enums;

namespace MedicineDiary.Tests
{
    public class HandlersTests:BaseTest
    {
        private readonly IDiaryRepository _repository;
        private readonly Dictionary<ChatStateEnum, IHandler> _handlers;
        private const long _chatId = -1;

        public HandlersTests()
        {
            _repository = new RepositoryFactory().GetDiaryRepository(base.dbConnection, MessengerEnum.telegram);
            _handlers = HandlerFactory.GetHandlers(_repository);
            _repository.GetChatState(_chatId);
        }

        [Fact]
        public async void NoRegistredHandlerTest()
        {
            string message = "trololo";
            var result = await _handlers[ChatStateEnum.NoRegistred].HandleAsync(_chatId,message);
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
