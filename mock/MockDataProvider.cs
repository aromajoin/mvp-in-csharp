using System;
using System.Collections.Generic;
using mvp_in_csharp.data;
namespace mvp_in_csharp.mock
{
  public class MockDataProvider
  {
    public static string JSON = "[{\"id\":1,\"content\":\"Hi message 1.\",\"created\":\"2017-09-05T12:00:00\"},{\"id\":2,\"content\":\"Hi message 2.\",\"created\":\"2017-09-05T13:00:00\"}]";
    public static string INVALID_JSON = "[{\"id\":1,\"content\":\"Hi message 1.\",\"created\":\"2017-09-05T12:00:00\"},{\"id\":2,\"content\":\"Hi message 2.\",\"created\":\"2017-09-05T13:00.";
    public static string MOCK_FILE_PATH = "../../../mock/MOCK_MESSAGES.json";

    public static IList<Message> GetMockMessages()
    {
      Message message1 = new Message(1, "Hi message 1.", new DateTime(2017, 09, 05, 12, 00, 00, 00));
      Message message2 = new Message(2, "Hi message 2.", new DateTime(2017, 09, 05, 13, 00, 00, 00));

      IList<Message> messages = new List<Message>
      {
        message1,
        message2
      };
      return messages;
    }
  }
}
