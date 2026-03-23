using Microsoft.Playwright;

public class TestContext
{
    public IAPIRequestContext Api { get; private set; }

    public async Task CreateApiContext(IPlaywright playwright)
    {
        Api = await playwright.APIRequest.NewContextAsync();
    }

    public async Task DisposeApiContext()
    {
        if (Api != null)
            await Api.DisposeAsync();
    }
}