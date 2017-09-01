using System;
using System.Collections.Generic;
using mvp_in_csharp.data;

namespace mvp_in_csharp.messages
{
  public class MessagesView : IMessagesView
  {
    private IMessagesPresenter presenter;
    public MessagesView()
    {

    }

    public void SetPresenter(IMessagesPresenter presenter)
    {
      this.presenter = presenter;
    }

    public void OnRequestedToMode(int mode)
    {
      throw new NotImplementedException();
    }

    public void OnRequestedToShowMenu()
    {
      throw new NotImplementedException();
    }

    public void OnRequestedToLoadMessages()
    {
      if (presenter != null)
        presenter.LoadMessages();
    }

    public void ShowMessages(IList<Message> messages)
    {
      Console.WriteLine($"Messages count: {messages.Count}");
      Console.WriteLine("Messages detail:");
      PrintMessages(messages);
    }

    public void ShowNotification(string msg)
    {
      Console.WriteLine($"Notification: {msg}");
    }

    void PrintMessages(IList<Message> messages)
    {
      foreach (var message in messages)
      {
        Console.WriteLine(message);
      }
    }
  }
}
