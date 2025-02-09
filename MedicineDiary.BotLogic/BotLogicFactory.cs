using MedicineDiary.BotLogic.Abstractions;

namespace MedicineDiary.BotLogic
{
    public class BotLogicFactory
    {
        public IBotLogic GetBotLogic()
        {
            return new BotLogic();
        }
    }

}
