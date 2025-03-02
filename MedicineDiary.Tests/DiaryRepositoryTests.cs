using MedicineDiary.Data;
using MedicineDiary.Data.Abstraction;
using MedicineDiary.Models.Enums;

namespace MedicineDiary.Tests
{
    public class DiaryRepositoryTests : BaseTest
    {
        private readonly IDiaryRepository _repository;
        public DiaryRepositoryTests()
        {
            _repository = new RepositoryFactory().GetDiaryRepository(base.dbConnection, MessengerEnum.telegram);
        }

        [Fact]
        public async Task GetChatStateTest()
        {
            var result = await _repository.GetChatState(5);
            Assert.NotNull(result);
            Assert.Equal(result.State, 6);
            Assert.Equal(result.Language, "en");

        }

    }
}
