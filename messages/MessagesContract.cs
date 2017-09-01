using System;
using System.Collections.Generic;
using mvp_in_csharp.data;
namespace mvp_in_csharp.messages
{
  public interface IMessagesView
  {
    void SetPresenter(IMessagesPresenter presenter);

    void OnRequestedToShowMenu();
    void OnRequestedToMode(int mode);
    void OnRequestedToLoadMessages();

    void ShowMessages(IList<Message> messages);
    void ShowNotification(string msg);
  }

  public interface IMessagesPresenter
  {
    void LoadMessages();
    void SaveMessage(Message message);
    void RemoveMessage(long id);
  }
}
