using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace UIAutomation
{
    public class TestContext
    {
        public IBrowserContext BrowserContext { get; set; }
        public IPage Page { get; set; }
    }
}
