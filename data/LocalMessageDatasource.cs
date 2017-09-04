using System;
using System.Collections.Generic;

namespace mvp_in_csharp.data
{
  public class LocalMessageDataSource : IMessageDataSource
  {
    private InFileSavingHelper fileHelper;
    public LocalMessageDataSource(InFileSavingHelper fileHelper)
    {
      this.fileHelper = fileHelper;
    }

    public void AddMessage(Message message)
    {
      fileHelper.AppendMessageToFile(message);
    }

    public IList<Message> LoadMessages()
    {
      return fileHelper.LoadMessagesFromFile();
    }

    public void RemoveMessage(long messageId)
    {
      fileHelper.RemoveMessageFromFile(messageId);
    }
  }
}
