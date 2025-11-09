using Microsoft.Playwright;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Automation.Steps
{
    public class LoginSteps : GlobalSteps
    {
        [Given("I navigate to the login page")]
        public async Task GivenINavigateToTheLoginPage()
        {
            await Hooks.Page!.GotoAsync("https://www.google.com/");

        }
    }
}
