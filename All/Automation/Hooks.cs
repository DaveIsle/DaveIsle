using Microsoft.Playwright;

public class Hooks
{
    private static IPlaywright _playwright = null!;
    private IAPIRequestContext _apiRequest = null!;

    [OneTimeSetUp]
    public async Task BeforeAllTestsRun()
    {
        _playwright = await Playwright.CreateAsync();
    }

    [OneTimeTearDown]
    public async Task AfterAllTestsRun()
    {
        _playwright?.Dispose();
    }

    [SetUp]
    public async Task BeforeEachTest()
    {
        _apiRequest = await _playwright.APIRequest.NewContextAsync();
    }

    [TearDown]
    public async Task AfterEachTest()
    {
        await _apiRequest.DisposeAsync();
    }
}