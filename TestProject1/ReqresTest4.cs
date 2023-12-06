namespace TestProject1;
using Assert = NUnit.Framework.Assert;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;
using System.Diagnostics;
using NUnit.Allure.Core;

[AllureNUnit]
public class ApiTests4
{
    private RestClient client;
    private RestRequest request;

    [Test]
    public void TestGetRequest()
    {

        client = new RestClient("https://reqres.in/api");
        request = new RestRequest("users", Method.Get);
        request.AddParameter("page", "2");

        // Act
        RestResponse response = client.Execute(request); // DeepSeek levemente modificado - funciona

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK)); // NUnit Codeseek original

        // Validate the response
        JObject jsonResponse = JObject.Parse(response.Content); // DeepSeek original

        Assert.That((int)jsonResponse["page"], Is.EqualTo(2));
        Assert.That((int)jsonResponse["per_page"], Is.EqualTo(6));
        Assert.That((int)jsonResponse["total"], Is.EqualTo(12));
        Assert.That((int)jsonResponse["total_pages"], Is.EqualTo(2));

        // Validate the data in the response
        JArray data = (JArray)jsonResponse["data"];

        foreach (JObject user in data)
        {
            Assert.IsNotNull(user["id"]);
            Assert.IsNotNull(user["email"]);
            Assert.IsNotNull(user["first_name"]);
            Assert.IsNotNull(user["last_name"]);
            Assert.IsNotNull(user["avatar"]);
        }

        // Validate the support object in the response
        JObject support = (JObject)jsonResponse["support"];
        Assert.IsNotNull(support["url"]);
        //Assert.NotNull(support["url"]); // Xunit - funciona
        Assert.IsNotNull(support["text"]);
        //Assert.NotNull(support["text"]); // Xunit - funciona
    }

    [Test]
    public void TestPostRequest()
    {

        client = new RestClient("https://reqres.in/api");
        request = new RestRequest("users", Method.Post);
        request.AddJsonBody(new { name = "morpheus", job = "leader" });

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