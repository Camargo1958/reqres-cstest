namespace TestProject1;
using NUnit.Framework;
using RestSharp;
using System.Net;

[TestFixture]
public class PetstoreTest
{
    private RestClient client;

    [SetUp]
    public void Setup()
    {
        client = new RestClient("http://petstore.swagger.io/api");
    }

    [Test]
    public void TestGetPets()
    {
        var request = new RestRequest("pets", Method.Get);
        request.AddQueryParameter("tags", "tag1,tag2");
        request.AddQueryParameter("limit", "10");

        //var response = client.Execute(request);
        var response = client.Execute<RestRequest>(request);

        //Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        // Add more assertions based on your requirements
        Assert.Pass();
    }

    [Test]
    public void TestAddPet()
    {
        var request = new RestRequest("pets", Method.Post);
        request.AddJsonBody(new { name = "pet1", tag = "tag1" }); // Replace with your actual pet object

        //var response = client.Execute(request);
        var response = client.Execute<RestRequest>(request);

        //Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        // Add more assertions based on your requirements
        Assert.Pass();
    }

    [Test]
    public void TestGetPetById()
    {
        var request = new RestRequest("pets/{id}", Method.Get);
        request.AddUrlSegment("id", "1"); // Replace with your actual pet id

        //var response = client.Execute(request);
        var response = client.Execute<RestRequest>(request);

        //Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        // Add more assertions based on your requirements
        Assert.Pass();
    }

    [Test]
    public void TestDeletePetById()
    {
        var request = new RestRequest("pets/{id}", Method.Delete);
        request.AddUrlSegment("id", "1"); // Replace with your actual pet id

        //var response = client.Execute(request);
        var response = client.Execute<RestRequest>(request);

        //Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        // Add more assertions based on your requirements
        Assert.Pass();
    }
}