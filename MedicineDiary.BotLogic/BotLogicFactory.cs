using MedicineDiary.BotLogic.Abstractions;
using MedicineDiary.Models.Enums;


namespace MedicineDiary.BotLogic
{
    public class BotLogicFactory
    {
        public IBotLogic GetBotLogic(string connection, MessengerEnum messenger)
            => new BotLogic(connection,messenger);
    }

}
