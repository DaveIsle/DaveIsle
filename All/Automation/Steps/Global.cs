using System;
using System.Collections.Generic;
using System.Text;
using Reqnroll;
using Microsoft.Playwright;

namespace Automation.Steps
{
    [Binding]
    public partial class GlobalSteps
    {
        protected static IPlaywright PlaywrightInstance;
        protected static IBrowser Browser;
        protected IPage Page;
    }
}
