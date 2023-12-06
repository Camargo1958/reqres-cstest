namespace TestProject1;
using NUnit.Framework;
using RestSharp;
using System.Net;
using Newtonsoft.Json.Linq;

public class ApiTests3
{
    private RestClient client;
    private RestRequest request;

    [SetUp]
    public void Setup()
    {
        client = new RestClient("https://reqres.in/api");
        request = new RestRequest("users", Method.Post);
        request.AddJsonBody(new { name = "morpheus", job = "leader" });
    }

    [Test]
    public void TestPostRequest()
    {
        // Act
        RestResponse response = client.Execute(request); // DeepSeek modificado

        // Assert
        Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

        // Validate the response
        JObject jsonResponse = JObject.Parse(response.Content);
        Assert.AreEqual("morpheus", (string)jsonResponse["name"]);
        Assert.AreEqual("leader", (string)jsonResponse["job"]);
        Assert.IsNotNull(jsonResponse["id"]);
        Assert.IsNotNull(jsonResponse["createdAt"]);
    }
}