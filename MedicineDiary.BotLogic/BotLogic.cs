using MedicineDiary.BotLogic.Abstractions;
using MedicineDiary.Models.Enums;

namespace MedicineDiary.BotLogic
{
    public class BotLogic : IBotLogic
    {
        private MessengerEnum _messenger;
        string IBotLogic.ComandHandler(string message)
        {
            throw new NotImplementedException();
        }

        string IBotLogic.TextMessageHandler(string message)
        {
            throw new NotImplementedException();
        }

        string IBotLogic.MessageHandler(string message)
        {
            throw new NotImplementedException();
        }

        public BotLogic(MessengerEnum messenger)
        {
            _messenger = messenger;            
        }

    }

}
