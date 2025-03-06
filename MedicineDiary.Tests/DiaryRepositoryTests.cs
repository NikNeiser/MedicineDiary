using MedicineDiary.Data;
using MedicineDiary.Data.Abstraction;
using MedicineDiary.Models.Enums;
using Xunit.Abstractions;

namespace MedicineDiary.Tests
{
    public class DiaryRepositoryTests : BaseTest
    {
        private readonly IDiaryRepository _repository;
        private readonly ITestOutputHelper _output;
        public DiaryRepositoryTests(ITestOutputHelper output)
        {
            _repository = new RepositoryFactory().GetDiaryRepository(base.dbConnection, MessengerEnum.telegram);
            _output = output;
        }

        [Fact]
        public async Task GetChatStateTest()
        {
            var result = await _repository.GetChatState(5);
            Assert.NotNull(result);
            _output.WriteLine(result.State + " " + result.Language);
        }

    }
}
