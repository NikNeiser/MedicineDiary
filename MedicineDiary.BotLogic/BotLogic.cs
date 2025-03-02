using MedicineDiary.BotLogic.Abstractions;
using MedicineDiary.BotLogic.Handlers;
using MedicineDiary.Data;
using MedicineDiary.Data.Abstraction;
using MedicineDiary.Models.Dto.Input;
using MedicineDiary.Models.Enums;

namespace MedicineDiary.BotLogic
{
    public class BotLogic : IBotLogic
    {
        private readonly IDiaryRepository _repository;
        private readonly Dictionary<ChatStateEnum, IHandler> _handlers;
        public async Task<string> ComandHandler(long chatId, string message)
        {
            throw new NotImplementedException();
        }

        public async Task<string> TextMessageHandler(long chatId, string message)
        {
            throw new NotImplementedException();
        }

        public async Task<string> MessageHandler(long chatId, string message)
        {
            var state = await _repository.GetChatState(chatId);
            var handlerInput = new HandlerInput() {
                ChatId = chatId,
                Message = message,
                Language = state.Language,
            };
            var answer = await _handlers[(ChatStateEnum)state.State].HandleAsync(handlerInput);
            return answer;
        }

        public BotLogic(string connection, MessengerEnum messenger)
        {
            _repository = new RepositoryFactory().GetDiaryRepository(connection, messenger);           
            _handlers = HandlerFactory.GetMessageHandlers(_repository);
        }

    }

}
