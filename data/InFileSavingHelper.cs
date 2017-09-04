using System;
using System.IO;
using System.Collections.Generic;

namespace mvp_in_csharp.data
{
  // Saves and loads data to/from local file.
  // It uses a parser to encode file.
  public class InFileSavingHelper
  {
    readonly FileParser parser;
    public string FilePath { get; set; }
    public InFileSavingHelper(FileParser parser, string filePath)
    {
      this.parser = parser;
      FilePath = filePath;
    }

    public IList<Message> LoadMessagesFromFile()
    {
      // Return null when file does not exist
      if (!File.Exists(FilePath)) return null;

      TextReader reader = null;

      // Read json from file
      try
      {
        reader = new StreamReader(FilePath);
        string json = reader.ReadToEnd();
        return parser.DeserializeData(json);
      }
      finally
      {
        if (reader != null) reader.Close();
      }
    }

    public void AppendMessageToFile(Message message)
    {
      IList<Message> messages = LoadMessagesFromFile();
      if (messages == null) messages = new List<Message>();
      messages.Add(message);
      SaveMessagesToFile(messages);
    }

    public void RemoveMessageFromFile(long messageId)
    {
      throw new NotImplementedException();
    }

    public void SaveMessagesToFile(IList<Message> messages)
    {
      TextWriter writer = null;

      // Compose json string 
      string json = parser.SerializeData(messages);

      // Write it to file
      try
      {
        writer = new StreamWriter(FilePath);
        writer.WriteLine(json);
      }
      finally
      {
        if (writer != null) writer.Close();
      }
    }
  }
}
