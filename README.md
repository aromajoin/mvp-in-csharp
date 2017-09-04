## A MVP implementation in .NET (Csharp)
Implement [MVP(Model-View-Presenter)](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93presenter) architecture in .NET app using C#.  

How is each layer implemented in this project?  
* Model: its source code lays under ./data folder. All users data will be saved/loaded using json files. `Presenter` layer interacts with it via `MessageRepository` instance.
* View: A passive view which currently is a Console screen. 
* Presenter: Wire up Model and View together.

### Play with it
Firstly, clone this project into your local machine.   
```
git clone https://github.com/aromajoin/mvp-in-csharp.git
```

#### Run Console program
```
dotnet run
```  

#### Run unit tests
```
dotnet xunit
```

### License
This project is under APACHE license. See the LICENSE file for details.
