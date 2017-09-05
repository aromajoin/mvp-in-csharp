using System.IO;
using System.Collections.Generic;
using mvp_in_csharp.data;
namespace mvp_in_csharp.tests
{
  public class TestUtils
  {
    
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
