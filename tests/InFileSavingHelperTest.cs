using System;
using Xunit;
using mvp_in_csharp.data;
using mvp_in_csharp.mock;
namespace mvp_in_csharp.tests
{
  public class InFileSavingHelperTest
  {
    public static string USER_FILE_TEST_PATH = "./TEST.json";

    readonly InFileSavingHelper savingHelper;
    public InFileSavingHelperTest()
    {
      savingHelper = new InFileSavingHelper(new FileParser(), MockDataProvider.MOCK_FILE_PATH);
    }

    [Fact]
    public void LoadDataFromFile()
    {
      Assert.Equal(savingHelper.LoadMessagesFromFile(), MockDataProvider.GetMockMessages());
    }

    [Fact]
    public void SaveDataToFile()
    {
      string filePath = USER_FILE_TEST_PATH;

      // Change file path to testing file
      savingHelper.FilePath = filePath;
      
      // Firstly, delete if it is already exists
      TestUtils.DeleteFileIfExists(filePath);

      // Save data to a new file
      savingHelper.SaveMessagesToFile(MockDataProvider.GetMockMessages());

      // Check whether the expected file is created succefully or not
      Assert.True(TestUtils.CheckFileExists(filePath));

      // Check whether content is corret or not
      Assert.Equal(TestUtils.ReadFile(filePath), MockDataProvider.JSON);
    }
  }
}
