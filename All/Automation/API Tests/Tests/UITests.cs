using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIAutomation.API_Tests.Tests
{
    internal class UITests
    {
        //private async Task ClickButton(string button)
        //{
        //    var clickable = _page!.GetByRole(AriaRole.Button, new() { Name = button, Exact = true }).First;
        //    await clickable.ScrollIntoViewIfNeededAsync();
        //    await clickable.ClickAsync();
        //}

        //private async Task FillInField(string fieldName, string fieldValue)
        //{
        //    var fillable = _page!.GetByRole(AriaRole.Textbox, new() { Name = fieldName, Exact = true }).First;
        //    await fillable.ScrollIntoViewIfNeededAsync();
        //    await fillable.FillAsync(fieldValue);
        //    await fillable.BlurAsync();
        //}

        //[Test]
        //public async Task basic()
        //{
        //    await ClickButton("Reject non-essential cookies");
        //    await ClickButton("open search");
        //    await FillInField("Search", "wapple");
        //    await ClickButton("Search");
        //    await Assertions.Expect(_page!.Locator(":text-is(\"0 results for 'wapple'\")")).ToBeVisibleAsync();
        //}
    }
}
