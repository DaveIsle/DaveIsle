using Microsoft.Playwright;

namespace Automation.Steps
{
    public class GlobalSteps
    {
        protected readonly UIAutomation.TestContext Context;

        public GlobalSteps(UIAutomation.TestContext context)
        {
            Context = context;
        }

        protected IPage Page => Context.Page;
        protected IBrowserContext BrowserContext => Context.BrowserContext;
    }
}