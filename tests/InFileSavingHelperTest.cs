using System;
using Xunit;
using mvp_in_csharp.data;
namespace mvp_in_csharp.tests
{
  public class InFileSavingHelperTest
  {
    readonly InFileSavingHelper savingHelper;
    public InFileSavingHelperTest()
    {
      savingHelper = new InFileSavingHelper(new FileParser(), TestUtils.MOCK_FILE_PATH);
    }

    [Fact]
    public void LoadDataFromFile()
    {
      Assert.Equal(savingHelper.LoadMessagesFromFile(), TestUtils.GetMockMessages());
    }
  }
}
