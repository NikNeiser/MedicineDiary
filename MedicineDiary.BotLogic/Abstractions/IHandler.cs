namespace MedicineDiary.BotLogic.Abstractions
{
    public interface IHandler
    {
        Task<string> HandleAsync(long chatId, string message);
    }
}
