using System.IO;
using System.Collections.Generic;
using mvp_in_csharp.data;
namespace mvp_in_csharp.tests
{
  public class TestUtils
  {
    public static string JSON = "[{\"id\":1,\"content\":\"Hi message 1.\"},{\"id\":2,\"content\":\"Hi message 2.\"}]";
    public static string INVALID_JSON = "[{\"id\":1,\"content\":\"Hi message 1.\"},{\"id\":2,\"content\":\"Hi message 2.";
    public static string MOCK_FILE_PATH = "../../../mock/MOCK_MESSAGES.json";
    public static string USER_FILE_TEST_PATH = "./TEST.json";

    public static IList<Message> GetMockMessages()
    {
      Message message1 = new Message(1, "Hi message 1.");
      Message message2 = new Message(2, "Hi message 2.");

      IList<Message> messages = new List<Message>();
      messages.Add(message1);
      messages.Add(message2);

      return messages;
    }

    public static void DeleteFileIfExists(string filePath)
    {
      if (File.Exists(filePath))
        File.Delete(filePath);
    }

    public static bool CheckFileExists(string filePath)
    {
      return File.Exists(filePath);
    }

    public static string ReadFile(string filePath)
    {
      TextReader reader = null;

      try
      {
        reader = new StreamReader(filePath);
        return reader.ReadToEnd().Trim();

      }
      finally
      {
        if (reader != null) reader.Close();
      }
    }
  }
}
