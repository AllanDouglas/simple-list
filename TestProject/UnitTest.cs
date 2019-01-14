using TheSimpleList.Src.Modules.List.Services;
using TheSimpleList.Src.Modules.Storage.Services;
using Xunit;

namespace TestProject
{
    public class UnitTest
    {
        [Fact]
        public async void GetProductList()
        {
            var service = new LocalListService(new LocalStorageService());

            var lists = await service.List();

            Assert.NotEmpty(lists);
        }
    }
}
