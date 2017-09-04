using System;
using System.Collections.Generic;

namespace mvp_in_csharp.data
{
  public class MessageRepository : IMessageDataSource
  {
    readonly IMessageDataSource localDataSource;
    public MessageRepository(IMessageDataSource localDataSource)
    {
      this.localDataSource = localDataSource;
    }

    public IList<Message> LoadMessages()
    {
      return localDataSource.LoadMessages();
    }

    public void AddMessage(Message message)
    {
      localDataSource.AddMessage(message);
    }

    public void RemoveMessage(long messageId)
    {
      localDataSource.RemoveMessage(messageId);
    }
  }
}
