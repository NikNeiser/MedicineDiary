namespace MedicineDiary.BotLogic.Abstractions
{
    internal interface IHandler
    {
        Task<string> HandleAsync(long chatId, string message);
    }
}
