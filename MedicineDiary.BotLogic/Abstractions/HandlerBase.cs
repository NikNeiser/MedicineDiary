using MedicineDiary.Data.Abstraction;

namespace MedicineDiary.BotLogic.Abstractions
{
    abstract class HandlerBase
    {
        protected readonly IDiaryRepository _repository;
        protected HandlerBase(IDiaryRepository repository)
        {
            _repository = repository;
        }
    }
}
