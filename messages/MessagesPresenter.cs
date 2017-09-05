using System;
using System.Collections.Generic;
using mvp_in_csharp.data;

namespace mvp_in_csharp.messages
{
  public class MessagesPresenter : IMessagesPresenter
  {
    readonly MessageRepository repository;
    readonly IMessagesView view;
    public MessagesPresenter(MessageRepository repository, IMessagesView view)
    {
      this.repository = repository;
      this.view = view;
      this.view.SetPresenter(this);
    }

    public void LoadMessages()
    {
      // Load data from model
      IList<Message> results = repository.LoadMessages();

      if (results == null || results.Count == 0) {
        view.ShowNotification("NO MESSAGES");
      } else {
        view.ShowMessages(results); 
      }

      // Comeback to menu screen
      view.ShowInitialScreen();
    }

    public void AddMessage(Message message)
    {
      // Add new message to model
      repository.AddMessage(message);

      // Show notification on view
      view.ShowNotification("Add message successfully.");

      // Comeback to menu screen
      view.ShowInitialScreen();
    }

    public void RemoveMessage(long id)
    {
      // Remove message from model
      repository.RemoveMessage(id);

      // Show notification on view
      view.ShowNotification($"Remove message( id = {id}) succefully.");

      // Comeback to menu screen
      view.ShowInitialScreen();
    }

    public void ShowMenuScreen()
    {
      view.ShowInitialScreen();
    }
  }
}
