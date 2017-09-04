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

      // Show it on view
      view.ShowMessages(results);
    }

    public void SaveMessage(Message message)
    {
      // Add new message to model
      repository.AddMessage(message);

      // Show notification on view
      view.ShowNotification("Add message successfully.");
    }

    public void RemoveMessage(long id)
    {
      // Remove message from model
      repository.RemoveMessage(id);

      // Show notification on view
      view.ShowNotification($"Remove message( id = {id}) succefully.");
    }
  }
}
