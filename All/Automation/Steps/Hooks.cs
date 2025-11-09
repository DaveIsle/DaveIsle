using Microsoft.Playwright;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Steps
{
    [Binding]
    public class Hooks
    {
        public static IPlaywright? PlaywrightInstance;
        public static IBrowser? Browser;
        public static IPage? Page;

        [BeforeScenario]
        public static async Task Setup()
        {
            PlaywrightInstance = await Playwright.CreateAsync();
            Browser = await PlaywrightInstance.Chromium.LaunchAsync(new() { Headless = false });
            Page = await Browser.NewPageAsync();
        }

        [AfterScenario]
        public static async Task TearDown()
        {
            await Browser.CloseAsync();
            PlaywrightInstance?.Dispose();
        }
    }
}
