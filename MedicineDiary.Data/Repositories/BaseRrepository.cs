using MedicineDiary.Models.Enums;

namespace MedicineDiary.Data.Repositories
{
    public abstract class BaseRrepository
    {
        public readonly MessengerEnum _messenger;
        public readonly string _connectionString;
        public BaseRrepository(string connectionString, MessengerEnum messenger )
        {
            _messenger = messenger;
            _connectionString = connectionString;
        }
    }
}
