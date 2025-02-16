namespace MedicineDiary.BotLogic.Abstractions
{
    public interface IBotLogic
    {
        Task<string> MessageHandler(long chatId, string message);
        Task<string> TextMessageHandler(long chatId, string message);
        Task<string> ComandHandler(long chatId, string message);
    }

}
