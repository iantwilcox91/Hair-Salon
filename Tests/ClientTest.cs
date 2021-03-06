using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;


namespace HairSalon
{
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test1_EmptyDatabase()
    {
      int result = Client.GetAll().Count;
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test2_Save()
    {
      Client testClient = new Client("ClientName", 1);
      testClient.Save();
      Client savedClient = Client.GetAll()[0];
      int result = savedClient.GetId();
      int testId = testClient.GetId();
      Assert.Equal(testId, result);
    }

    [Fact]
    public void Test3_FindCorrectClient()
    {
      Client testClient = new Client("ClientName", 1);
      testClient.Save();
      Client foundClient = Client.Find(testClient.GetId());
      Assert.Equal(testClient, foundClient);
    }

    [Fact]
    public void Test4_UpdateClient()
    {
      string name = "ClientName";
      Client testClient = new Client(name, 1);
      testClient.Save();
      string newName = "ClientNewName";
      testClient.Update(newName);
      string result = testClient.GetName();
      Assert.Equal(newName, result);
    }

    [Fact]
    public void Test5_DeleteClient()
    {
      Client firstClient = new Client("FirstClientName", 1);
      firstClient.Save();
      Client secondClient = new Client("SecondClientName", 1);
      secondClient.Save();
      firstClient.Delete();
      List<Client> allClients = Client.GetAll();
      List<Client> testClient = new List<Client> {secondClient};
      Assert.Equal(testClient, allClients);
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
      Client.DeleteAll();
    }
  }
}
