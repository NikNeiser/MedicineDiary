using MedicineDiary.Models;
using MedicineDiary.Models.Dto.Output;
using MedicineDiary.Models.Enums;

namespace MedicineDiary.Data.Abstraction
{
    public interface IDiaryRepository
    {
        Task<GetStateOutput> GetChatState(long id);
        Task<ChatStateEnum> SetChatState(long id, ChatStateEnum chatState);
        Task<LanguageEnum> SetChatLanguage(long id, LanguageEnum language);
    }
}
