namespace TestProject1;
using Assert = NUnit.Framework.Assert;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;
using System.Diagnostics;


public class ApiTests
{
    private RestClient client;
    private RestRequest request;

    [SetUp]

    public void Setup()
    {
        client = new RestClient("https://reqres.in/api");
        request = new RestRequest("users", Method.Get);
        request.AddParameter("page", "2");
        //Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
    }

    [Test]
    public void TestGetRequest()
    {
        // Act
        //IRestResponse response = client.Execute(request); // DeepSeek original - não funciona diretamente
        RestResponse response = client.Execute(request); // DeepSeek levemente modificado - funciona
        //var response = client.Execute<RestRequest>(request); // manual - funciona

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK)); // NUnit Codeseek original
        //Assert.Equal(HttpStatusCode.OK, response.StatusCode); //Xunit

        // Validate the response
        JObject jsonResponse = JObject.Parse(response.Content); // DeepSeek original
        //JObject jsonResponse = JObject.Parse(response.Content); // funciona

        //Console.WriteLine(value: response.Content.ToString());
        //Trace.WriteLine(value: response.Content.ToString());

        Assert.That((int)jsonResponse["page"], Is.EqualTo(2));
        //Assert.Equal(2, (int)jsonResponse["page"]); // Xunit - funciona
        Assert.That((int)jsonResponse["per_page"], Is.EqualTo(6));
        //Assert.Equal(6, (int)jsonResponse["per_page"]); // Xunit - funciona
        Assert.That((int)jsonResponse["total"], Is.EqualTo(12));
        Assert.That((int)jsonResponse["total_pages"], Is.EqualTo(2));

        // Validate the data in the response
        JArray data = (JArray)jsonResponse["data"];
        //Assert.That(data.Count, Is.EqualTo(6));

        foreach (JObject user in data)
        {
            Assert.IsNotNull(user["id"]);
            //Assert.NotNull(user["id"]); // Xunit - funciona
            //Console.WriteLine(user["id"]);
            Assert.IsNotNull(user["email"]);
            //Assert.NotNull(user["email"]); // Xunit - funciona
            Assert.IsNotNull(user["first_name"]);
            Assert.IsNotNull(user["last_name"]);
            Assert.IsNotNull(user["avatar"]);
            //Assert.NotNull(user["avatar"]); // Xunit - funciona
        }

        // Validate the support object in the response
        JObject support = (JObject)jsonResponse["support"];
        Assert.IsNotNull(support["url"]);
        //Assert.NotNull(support["url"]); // Xunit - funciona
        Assert.IsNotNull(support["text"]);
        //Assert.NotNull(support["text"]); // Xunit - funciona
    }
}