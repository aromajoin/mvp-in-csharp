using System;
using System.Collections.Generic;
using Xunit;
using mvp_in_csharp.data;
namespace mvp_in_csharp.tests
{
  public class FileParserTest
  {
    readonly FileParser fileParser;

    public FileParserTest()
    {
      fileParser = new FileParser();
    }

    [Fact]
    public void SerializeData_ShouldThrowExeption_WhenListIsNull()
    {
      Assert.Throws<ArgumentNullException>(() => fileParser.SerializeData(null));
    }

    [Fact]
    public void SerializeData_ShouldThrowExeption_WhenListIsEmpty()
    {
      Assert.Throws<ArgumentNullException>(() => fileParser.SerializeData(new List<Message>()));
    }

    [Fact]
    public void SerializeData_ShouldReturnJSON_IfListIsValid()
    {
      string json = fileParser.SerializeData(TestUtils.GetMockMessages());
      Assert.Equal(json, TestUtils.JSON);
    }

    [Fact]
    public void DeserializeData_ShouldReturnNull_WhenJsonIsEmpty()
    {
      Assert.Null(fileParser.DeserializeData(""));
    }

    [Fact]
    public void DeserializeData_ShouldReturnList_WhenJsonFormatIsValid()
    {
      Assert.Equal(fileParser.DeserializeData(TestUtils.JSON), TestUtils.GetMockMessages());
    }
  }
}
