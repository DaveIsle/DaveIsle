using Reqnroll;

namespace Automation.Steps
{
    [Binding]
    public class LoginSteps : GlobalSteps
    {
        public LoginSteps(UIAutomation.TestContext context) : base(context) { }


        [Given("I navigate to the login page")]
        public async Task GivenINavigateToTheLoginPage()
         {
            await Page.GotoAsync("https://www.google.com/");
        }
    }
}
