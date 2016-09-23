using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;


namespace HairSalon
{
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test1_EmptyDatabase()
    {
      int result = Stylist.GetAll().Count;
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test2_Save()
    {
      Stylist testStylist = new Stylist("StylistName");
      testStylist.Save();
      Stylist savedStylist = Stylist.GetAll()[0];
      int result = savedStylist.GetId();
      int testId = testStylist.GetId();
      Assert.Equal(testId, result);
    }

    [Fact]
    public void Test3_FindCorrectStylist()
    {
      Stylist testStylist = new Stylist("StylistName");
      testStylist.Save();
      Stylist foundStylist = Stylist.Find(testStylist.GetId());
      Assert.Equal(testStylist, foundStylist);
    }

    [Fact]
    public void Test4_UpdateStylist()
    {
      string name = "StylistName";
      Stylist testStylist = new Stylist(name);
      testStylist.Save();
      string newName = "StylistNewName";
      testStylist.Update(newName);
      string result = testStylist.GetName();
      Assert.Equal(newName, result);
    }

    [Fact]
    public void Test5_DeleteStylist()
    {
      Stylist firstStylist = new Stylist("FirstStylistName");
      firstStylist.Save();
      Stylist secondStylist = new Stylist("SecondStylistName");
      secondStylist.Save();
      firstStylist.Delete();
      List<Stylist> allStylists = Stylist.GetAll();
      List<Stylist> testStylist = new List<Stylist> {secondStylist};
      Assert.Equal(testStylist, allStylists);
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
      Client.DeleteAll();
    }
  }
}
