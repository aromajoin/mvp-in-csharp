﻿using System;
using mvp_in_csharp.data;
using mvp_in_csharp.messages;

namespace mvp_in_csharp
{
  class Program
  {
    const string SAVING_FILE_PATH = "./messages.json";

    // Because users only interact with view, so only it should be declared as a global variable
    IMessagesView view;
    static void Main(string[] args)
    {
      Console.WriteLine("=== MESSAGE MANAGER ====");
      Program program = new Program();
      program.SetUp();
      IMessagesView view = program.view;

      // Users ask to open menu screen
      view.OnRequestedToShowMenu();
    }

    void SetUp()
    {
      // Model
      InFileSavingHelper fileSaveHelper = new InFileSavingHelper(new FileParser(), SAVING_FILE_PATH);
      LocalMessageDataSource localDataSource = new LocalMessageDataSource(fileSaveHelper);
      MessageRepository repository = new MessageRepository(localDataSource);

      // View
      view = new MessagesView();

      // Presenter
      IMessagesPresenter presenter = new MessagesPresenter(repository, view);
    }
  }
}
