using MedicineDiary.Data.Abstraction;
using MedicineDiary.Models.Enums;
using Dapper;
using Npgsql;

namespace MedicineDiary.Data.Repositories
{
    public class DiaryRepository : BaseRrepository, IDiaryRepository
    {
        public DiaryRepository(string connection, MessengerEnum messenger)
            :base(connection, messenger )
        {
        }
        public async Task<ChatStateEnum> GetChatState(long id)
        {
            using var connection = new NpgsqlConnection(base._connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@messenger", base._messenger.ToString());
            parameters.Add("@id", id);
            var query = @"SELECT function.get_state_or_add_id(@messenger,@id)";
            var result = await connection.ExecuteAsync(query, parameters);
            return (ChatStateEnum)result;
        }
        public async Task<ChatStateEnum> SetChatState(long id, ChatStateEnum chatState)
        {
            using var connection = new NpgsqlConnection(base._connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@state", ((int)chatState));
            parameters.Add("@id", id);

            var query = $"UPDATE {base._messenger.ToString()}.users SET \"state\" = @state WHERE \"chatId\" = @id;";
            await connection.ExecuteAsync(query,parameters);
            return chatState;
        }
    }
}
