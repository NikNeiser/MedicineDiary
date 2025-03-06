using MedicineDiary.Data.Abstraction;
using MedicineDiary.Models.Enums;
using Dapper;
using Npgsql;
using MedicineDiary.Models.Dto.Output;
using Newtonsoft.Json;
using System.Transactions;

namespace MedicineDiary.Data.Repositories
{
    public class DiaryRepository : BaseRrepository, IDiaryRepository
    {
        public DiaryRepository(string connection, MessengerEnum messenger)
            :base(connection, messenger )
        {
        }
        public async Task<GetStateOutput> GetChatState(long id)
        {
            using var connection = new NpgsqlConnection(base._connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@messenger", base._messenger.ToString());
            parameters.Add("@id", id);
            var query = @"SELECT function.get_state_or_add_id(@messenger,@id)";
            var jsonResult= await connection.QueryFirstOrDefaultAsync<string>(query, parameters);

            return JsonConvert.DeserializeObject<GetStateOutput>(jsonResult);
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

        public async Task<LanguageEnum> SetChatLanguage(long id, LanguageEnum language)
        {
            using var connection = new NpgsqlConnection(base._connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@language", language.ToString());
            parameters.Add("@id", id);
            parameters.Add("@state1", ((int)ChatStateEnum.Registred));
            parameters.Add("@state2", ((int)ChatStateEnum.NoRegistred));

            var query =
                $"UPDATE {base._messenger.ToString()}.users " +
                $"SET \"language\" = @language, " +
                $"\"state\" = CASE " +
                    $"WHEN \"timeDelta\" IS NULL THEN @state2 " +
                    $"ELSE @state1 " +
                    $"END " +
                $"WHERE \"chatId\" = @id;";

            await connection.ExecuteAsync(query, parameters);

            return language;
        }

        public async Task<bool> SetChatTimeDelta(long id, TimeSpan timeDelta)
        {
            using var connection = new NpgsqlConnection(base._connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@timeDelta", timeDelta);
            parameters.Add("@id", id);
            parameters.Add("@state", ((int)ChatStateEnum.Registred));

            var query =
                $"UPDATE {base._messenger.ToString()}.users " +
                $"SET \"timeDelta\" = @timeDelta, " +
                $"\"state\" = @state " +
                $"WHERE \"chatId\" = @id;";

            await connection.ExecuteAsync(query, parameters);

            return true;
        }

    }
}
