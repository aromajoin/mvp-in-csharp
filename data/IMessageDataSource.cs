using System.Collections.Generic;
namespace mvp_in_csharp.data
{
  public interface IMessageDataSource
  {
    IList<Message> LoadMessages();

    void AddMessage(Message message);

    void RemoveMessage(long messageId);
  }
}
