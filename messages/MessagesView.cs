using System;
using System.Collections.Generic;
using mvp_in_csharp.data;

namespace mvp_in_csharp.messages
{
  public class MessagesView : IMessagesView
  {
    IMessagesPresenter presenter;

    public void SetPresenter(IMessagesPresenter presenter)
    {
      this.presenter = presenter;
    }

    public void OnRequestedToMode(int mode)
    {
      if (mode == 1)
      {
        Console.WriteLine("Load messages ... ");
        OnRequestedToLoadMessages();
      }
      else if (mode == 2)
      {
        Console.WriteLine("Add new message: ");
        OnRequestedToAddMessage();
      }
      else if (mode == 3)
      {
        Environment.Exit(0);
      }
    }

    public void OnRequestedToShowMenu()
    {
      presenter.ShowMenuScreen();
    }

    public void OnRequestedToLoadMessages()
    {
      if (presenter != null)
        presenter.LoadMessages();
    }

    public void OnRequestedToAddMessage()
    {
      Console.Write("id: ");
      long id = Convert.ToInt64(Console.ReadLine());
      Console.Write("content: ");
      string content = Console.ReadLine();
      DateTime created = DateTime.Now;
      Message message = new Message(id, content, created);

      presenter.AddMessage(message);
    }

    public void ShowInitialScreen()
    {
      Console.WriteLine();
      Console.WriteLine("*** Choose Mode ***");
      Console.WriteLine("1. Print out all messages.");
      Console.WriteLine("2. Add a new message.");
      Console.WriteLine("3. Exit program.");

      Console.Write("Enter your choice: ");

      int mode = Convert.ToInt16(Console.ReadLine());
      OnRequestedToMode(mode);
    }

    public void ShowMessages(IList<Message> messages)
    {
      Console.WriteLine($"{messages.Count} message(s):");
      PrintMessages(messages);
    }

    public void ShowNotification(string msg)
    {
      Console.WriteLine($"{msg}");
    }

    void PrintMessages(IList<Message> messages)
    {
      foreach (var message in messages)
      {
        Console.WriteLine($" - {message}");
      }
    }
  }
}
