using Microsoft.Playwright;
using System.Text.Json;

namespace Automation.ApiTests
{
    [TestFixture]
    public class PostsTests
    {
        [Test]
        public async Task GetPostById_ShouldReturnPost()
        {
            var response = await ApiRequest.GetAsync("https://jsonplaceholder.typicode.com/posts/1");
            Assert.That(response.Status, Is.EqualTo(200));

            var body = await response.TextAsync();
            var json = JsonSerializer.Deserialize<Dictionary<string, object>>(body)!;
            Assert.That(json["title"].ToString(), Is.EqualTo("sunt aut facere repellat provident occaecati excepturi optio reprehenderit"));
        }

        [Test]
        public async Task GetPost2AndAssertID()
        {
            var response = await ApiRequest.GetAsync("https://jsonplaceholder.typicode.com/posts/2");

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

            var response = await ApiRequest.PostAsync(
                "https://jsonplaceholder.typicode.com/posts",
                new() { DataObject = data });

            Assert.That(response.Status, Is.EqualTo(201));


            var body = await response.TextAsync();
            var json = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(body)!;

            var userID = json["userId"].GetInt32();
            Assert.That(userID, Is.GreaterThan(0));

            Assert.That((json["title"]).GetString(), Is.EqualTo("test post"));
        }

        private async Task ClickButton(string button)
        {
            var clickable = _page!.GetByRole(AriaRole.Button, new() { Name = button, Exact = true }).First;
            await clickable.ScrollIntoViewIfNeededAsync();
            await clickable.ClickAsync();
        }

        private async Task FillInField(string fieldName, string fieldValue)
        {
            var fillable = _page!.GetByRole(AriaRole.Textbox, new() { Name = fieldName, Exact = true }).First;
            await fillable.ScrollIntoViewIfNeededAsync();
            await fillable.FillAsync(fieldValue);
            await fillable.BlurAsync();
        }

        [Test]
        public async Task basic()
        {
            await ClickButton("Reject non-essential cookies");
            await ClickButton("open search");
            await FillInField("Search", "wapple");
            await ClickButton("Search");
            await Assertions.Expect(_page!.Locator(":text-is(\"0 results for 'wapple'\")")).ToBeVisibleAsync();
        }
    }
}