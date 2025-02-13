using MedicineDiary.Data.Abstraction;
using MedicineDiary.Data.Repositories;
using MedicineDiary.Models.Enums;

namespace MedicineDiary.Data
{
    public class RepositoryFactory
    {
        public IDiaryRepository GetDiaryRepository(string connection, MessengerEnum messenger) => new DiaryRepository(connection, messenger);

    }
}
