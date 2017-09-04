using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace mvp_in_csharp.data
{
  // Encodes/Decodes data by using a specific encoding format.
  // Currently, data is serialized to JSON format.
  public class FileParser
  {
    public string SerializeData(IList<Message> messages)
    {
      if (messages == null || messages.Count == 0)
        throw new ArgumentNullException();
      return JsonConvert.SerializeObject(messages);
    }

    public IList<Message> DeserializeData(string text)
    {
      if (text == null || text.Trim().Equals(""))
        return null;
      
      return JsonConvert.DeserializeObject<List<Message>>(text);
    }
  }
}
