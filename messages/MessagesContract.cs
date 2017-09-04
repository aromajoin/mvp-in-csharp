using System.Collections.Generic;
using mvp_in_csharp.data;
namespace mvp_in_csharp.messages
{
  public interface IMessagesView
  {
    void SetPresenter(IMessagesPresenter presenter);

    // user request when interacting with the view
    void OnRequestedToShowMenu();
    void OnRequestedToMode(int mode);
    void OnRequestedToLoadMessages();
    void OnRequestedToAddMessage();

    // view response to user
    void ShowInitialScreen();
    void ShowMessages(IList<Message> messages);
    void ShowNotification(string msg);
  }

  public interface IMessagesPresenter
  {
    void ShowMenuScreen();
    void LoadMessages();
    void AddMessage(Message message);
    void RemoveMessage(long id);
  }
}
