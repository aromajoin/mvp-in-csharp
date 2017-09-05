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
    [JsonProperty("created")]
    public DateTime Created { get; set; }

    public Message(long Id, string Content, DateTime Created)
    {
      this.Id = Id;
      this.Content = Content;
      this.Created = Created;
    }

    public override string ToString()
    {
      return string.Format("[Message: Id={0}, Content={1}, Created={2}]", Id, Content, Created);
    }
  }
}
