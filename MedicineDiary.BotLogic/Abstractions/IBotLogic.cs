namespace MedicineDiary.BotLogic.Abstractions
{
    public interface IBotLogic
    {
        string MessageHandler(string message);
        string TextMessageHandler(string message);
        string ComandHandler(string message);
    }

}
