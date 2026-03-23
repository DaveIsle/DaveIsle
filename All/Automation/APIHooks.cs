using Microsoft.Playwright;

[TestFixture]
public class APIHooks
{
    protected TestContext Context = null!;
    private IPlaywright _playwright = null!;


    [OneTimeSetUp]
    public async Task GlobalSetup()
    {
        _playwright = await Playwright.CreateAsync();
    }

    [OneTimeTearDown]
    public async Task GlobalTeardown()
    {
        _playwright?.Dispose();
    }

    [SetUp]
    public async Task TestSetup()
    {
        Context = new TestContext();
        await Context.CreateApiContext(_playwright);

    }

    [TearDown]
    public async Task TestTeardown()
    {
        await Context.DisposeApiContext();
    }
}