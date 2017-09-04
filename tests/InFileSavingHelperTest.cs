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

    [Fact]
    public void SaveDataToFile()
    {
      string filePath = TestUtils.USER_FILE_TEST_PATH;

      // Change file path to testing file
      savingHelper.FilePath = filePath;
      
      // Firstly, delete if it is already exists
      TestUtils.DeleteFileIfExists(filePath);

      // Save data to a new file
      savingHelper.SaveMessagesToFile(TestUtils.GetMockMessages());

      // Check whether the expected file is created succefully or not
      Assert.True(TestUtils.CheckFileExists(filePath));

      // Check whether content is corret or not
      Assert.Equal(TestUtils.ReadFile(filePath), TestUtils.JSON);
    }
  }
}
