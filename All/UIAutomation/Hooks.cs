using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using Reqnroll;

[Binding]
public class Hooks
{
    private static IPlaywright _playwright = null!;
    private static IBrowser _browser = null!;

    private readonly UIAutomation.TestContext _context;

    public Hooks (UIAutomation.TestContext testContext)
    {
        _context = testContext;
    }

    //before all tests
    [BeforeTestRun]
    public static async Task BeforeTestRun()
    {
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        bool headless = config.GetValue<bool>("Browser:Headless");

        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = headless});
    }

    //after all tests
    [AfterTestRun]
    public static async Task AfterTestRun()
    {
        await _browser.DisposeAsync();
        _playwright.Dispose();
    }

    //before each test
    [BeforeScenario]
    public async Task BeforeScenario()
    {
        var browserContext = await _browser.NewContextAsync();
        var page = await browserContext.NewPageAsync();

        _context.BrowserContext = browserContext;
        _context.Page = page;
    }

    //after each test
    [AfterScenario]
    public async Task AfterScenario()
    {
        await _context.Page.CloseAsync();
        await _context.BrowserContext.DisposeAsync();
    }
}