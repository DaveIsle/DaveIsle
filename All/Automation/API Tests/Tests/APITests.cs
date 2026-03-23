using Microsoft.Playwright;
using System.Text.Json;

namespace Automation.ApiTests
{
    [TestFixture]
    public class PostsTests : APIHooks
    {
        [Test]
        public async Task GetPostById_ShouldReturnPost()
        {
            var response = await Context.Api.GetAsync("https://jsonplaceholder.typicode.com/posts/1");
            Assert.That(response.Status, Is.EqualTo(200));

            var body = await response.TextAsync();
            var json = JsonSerializer.Deserialize<Dictionary<string, object>>(body)!;
            Assert.That(json["title"].ToString(), Is.EqualTo("sunt aut facere repellat provident occaecati excepturi optio reprehenderit"));
        }

        [Test]
        public async Task GetPost2AndAssertID()
        {
            var response = await Context.Api.GetAsync("https://jsonplaceholder.typicode.com/posts/2");

            Assert.That(response.Status, Is.EqualTo(200));

            var body = await response.TextAsync();
            var json = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(body)!;

            Assert.That((json["userId"].GetInt32), Is.EqualTo(1));
        }

        [Test]
        public async Task CreatePost()
        {
            var data = new
            {
                title = "test post",
                body = "api automation",
                userId = 1
            };

            var response = await Context.Api.PostAsync(
                "https://jsonplaceholder.typicode.com/posts",
                new() { DataObject = data });

            Assert.That(response.Status, Is.EqualTo(201));


            var body = await response.TextAsync();
            var json = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(body)!;

            var userID = json["userId"].GetInt32();
            Assert.That(userID, Is.GreaterThan(0));

            Assert.That((json["title"]).GetString(), Is.EqualTo("test post"));
        }


    }
}