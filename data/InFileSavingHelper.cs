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
    string filePath;
    public InFileSavingHelper(FileParser parser, string filePath)
    {
      this.parser = parser;
      this.filePath = filePath;
    }

    public IList<Message> LoadMessagesFromFile() {
      // Check whether if file is exists or not
      ValidateFile(filePath);

      TextReader reader = null;

      // Read json from file
      try
      {
        reader = new StreamReader(filePath);
        string json = reader.ReadToEnd();
        return parser.DeserializeData(json);
      }
      finally
      {
        if (reader != null) reader.Close();
      }
    }

    public void AppendMessageToFile(Message message) {
      throw new NotImplementedException();
    }

    public void RemoveMessageFromFile(long messageId) {
      // Check whether if file is exists or not
      ValidateFile(filePath);

      // TODO: Check whether the messsage with expected id exists or not

      throw new NotImplementedException();
    }

    public void SaveMessagesToFile(IList<Message> messages) {
      TextWriter writer = null;

      // Compose json string 
      string json = parser.SerializeData(messages);

      // Write it to file
      try
      {
        writer = new StreamWriter(filePath);
        writer.WriteLine(json);
      }
      finally
      {
        if (writer != null) writer.Close();
      }
    }

    // Validates file existence
    void ValidateFile(string path)
    {
      if (path == null)
        throw new ArgumentNullException(nameof(path));
      if (!File.Exists(path))
        throw new FileNotFoundException();
    }
  }
}
