using MedicineDiary.Models;
using MedicineDiary.Models.Enums;

namespace MedicineDiary.Data.Abstraction
{
    public interface IDiaryRepository
    {
        Task<ChatStateEnum> GetChatState(long id);
        Task<ChatStateEnum> SetChatState(long id, ChatStateEnum chatState);
    }
}
