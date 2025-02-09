using MedicineDiary.BotLogic.Abstractions;
using MedicineDiary.Models.Enums;


namespace MedicineDiary.BotLogic
{
    public class BotLogicFactory
    {
        public IBotLogic GetBotLogic(MessengerEnum messenger)
        {
            return new BotLogic(messenger);
        }
    }

}
