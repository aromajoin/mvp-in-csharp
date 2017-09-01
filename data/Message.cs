using System;
using Newtonsoft.Json;
namespace mvp_in_csharp.data
{
  public struct Message
  {
    [JsonProperty("id")]
    public long Id { get; set; }
    [JsonProperty("content")]
    public string Content { get; set; }
    //public DateTime Created { get; set; }

    public Message(long Id, string Content)
    {
      this.Id = Id;
      this.Content = Content;
    }

    public override string ToString()
    {
      return string.Format("[Message: Id={0}, Content={1}]", Id, Content);
    }
  }
}
