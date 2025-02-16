namespace MedicineDiary.BotLogic.Abstractions
{
    internal interface IHandler
    {
        Task HandleAsync(string message);
    }
}
