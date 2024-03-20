
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System.ComponentModel.DataAnnotations;

namespace PlaywrightTests;

    [Parallelizable(ParallelScope.Self)]
    public class UserProfile:PageTest
    {
    IPage page;
    IBrowser browser;
    [SetUp]
    public async Task Setup()
    {


        browser = await Playwright.Chromium.LaunchAsync(new()
        {
            Headless = false,
            SlowMo = 2000
        });

        page = await browser.NewPageAsync(new()
        {
            ViewportSize = new()
            {
                Width = 1280,
                Height = 720
            },
            ScreenSize = new()
            {
                Width = 1280,
                Height = 720
            },
            RecordVideoSize = new()
            {
                Width = 1280,
                Height = 720
            },
            RecordVideoDir = "../../../Videos"
        });
    }
    public async Task login()
    {
        await page.GotoAsync("http://localhost:4200");

        await page.WaitForSelectorAsync("[data-testid='mainDivLogin']");
        await page.FillAsync("[data-testid='inputUsername']", "petar");
        await page.FillAsync("[data-testid='inputPassword']", "petar");

        await page.WaitForSelectorAsync("[data-testid='buttonLogin']");
        await page.ClickAsync("[data-testid='buttonLogin']");
    }
    [Test]
    public async Task clickAllTerms()
    {
        await login();

        await page.ClickAsync("[data-testid='user-personalterms']");
        var mainDiv=await page.WaitForSelectorAsync("[data-testid='listPersonalTerms']");
        Assert.IsNotNull(await page.QuerySelectorAsync("[data-testid='listPersonalTerms']"), "Personal Terms is not displayed.");
        var personalTermCards = await mainDiv.QuerySelectorAllAsync("[data-testid='divPersonalTermCard']");

        
        foreach (var card in personalTermCards)
        {
            var isDisplayed = await card.EvaluateAsync<bool>("(element) => element.offsetParent !== null");
            Assert.IsTrue(isDisplayed, "Personal term card is not displayed.");
        }

        await page.ScreenshotAsync(new() { Path = "../../../Slike/personalTerms.png" });
    }
    [Test]
    public async Task clickAllBCS()
    {
        await login();
        await page.ClickAsync("[data-testid='user-AllBcs']");
        var mainDiv = await page.WaitForSelectorAsync("[data-testid='listbc']");
        Assert.IsNotNull(await page.QuerySelectorAsync("[data-testid='listbc']"), "List BoredrCross is not displayed");
        var listBCS = await mainDiv.QuerySelectorAllAsync("[data-testid='bc-card']");

        foreach(var bc in listBCS)
        {
            var isDisplayed = await bc.EvaluateAsync<bool>("(element)=>element.offsetParent!==null");
            Assert.IsTrue(isDisplayed, "Border Cross card is not displayed");
        }
        await page.ScreenshotAsync(new() { Path="../../../Slike/allBCS.png"});
    }
    [Test]
    public async Task clickLogOut()
    {
        await login();

        await page.ClickAsync("[data-testid='user-logout']");
        var mainDiv = await page.WaitForSelectorAsync("[data-testid='mainDivLogin']");
        Assert.IsNotNull(await page.QuerySelectorAsync("[data-testid='mainDivLogin']"), "Login page is not displayed.");


        await page.ScreenshotAsync(new() { Path = "../../../Slike/logout.png" });
    }
    [Test]
    public async Task clickCreateTerm()
    {
        await login();
        await page.ClickAsync("[data-testid='user-create-term']");
        var mainDiv = await page.WaitForSelectorAsync("[data-testid='create-term-container']");
        Assert.IsNotNull(await page.QuerySelectorAsync("[data-testid='create-term-container']"), "Create term page is not displayed");
        await page.FillAsync("[data-testid='NumOfPassanger']", "3");
        await page.FillAsync("[data-testid='CarBrand']", "Audi");
        await page.FillAsync("[data-testid='NumOfRegistration']", "PI067XP");
        await page.FillAsync("[data-testid='ChassisNumber']", "xsasdklo1819190");
        await page.FillAsync("[data-testid='NumberOfDays']", "4");
        await page.FillAsync("[data-testid='PlaceOfResidence']", "Grcka");
       // await page.FillAsync("[data-testid='inputDate']", "2024-03-16");
        await page.FillAsync("[data-testid='CardNumber']", "2882198119");
        await page.SelectOptionAsync("[data-testid='selectBC']", "Gradina");
        await page.ClickAsync("[data-testid='inputDate']");
        var date = await page.QuerySelectorAsync("[data-testid='inputDate']");
        await date.TypeAsync("12. 3. 2024.");
        var dialogTaskCompletionSource = new TaskCompletionSource<IDialog>();
        page.Dialog += async (sender, e) =>
        {
            dialogTaskCompletionSource.SetResult(e);
        };
        await page.ClickAsync("[data-testid='create-term-button']");
        var dialog = await dialogTaskCompletionSource.Task;

        if (dialog.Type == DialogType.Alert)
        {

            var alertText = dialog.Message;


            if (alertText.Contains("Success created term"))
            {
                // Sve je u redu, prošlo je
            }

        }
        await page.ScreenshotAsync(new() { Path = "../../../Slike/createterm.png" });

        //await page.FillAsync("[data-testid=''", "");
    }
    [Test]
    public async Task clickSettings()
    {
        await login();

        await page.ClickAsync("[data-testid='user-settings']");

        var mainDiv = await page.WaitForSelectorAsync("[data-testid='main']");
        Assert.IsNotNull(await page.QuerySelectorAsync("[data-testid='main']"), "Settings page is not displayed.");


        await page.ScreenshotAsync(new() { Path = "../../../Slike/settings.png" });
    }
    [Test]
    public async Task changeNameAndEmailAndPhoneNumber()
    {
        await login();

        await page.ClickAsync("[data-testid='user-settings']");

        var mainDiv = await page.WaitForSelectorAsync("[data-testid='main']");
        Assert.IsNotNull(await page.QuerySelectorAsync("[data-testid='main']"), "Settings page is not displayed.");

        await page.ClickAsync("[data-testid='changeName']");
        await page.FillAsync("[data-testid='inputName']","Marko Petrovic");
        await page.ClickAsync("[data-testid='saveName']");

        await page.ClickAsync("[data-testid='changeEmail']");
        await page.FillAsync("[data-testid='inputEmail']", "markomar@gmail.com");
        await page.ClickAsync("[data-testid='saveEmail']");

        await page.ClickAsync("[data-testid='changePhone']");
        await page.FillAsync("[data-testid='inputPhone']", "0621981881");
        await page.ClickAsync("[data-testid='savePhone']");



        await page.ScreenshotAsync(new() { Path = "../../../Slike/changename.png" });
    }
    [Test]
    public async Task deleteTerm()
    {
        await login();

        await page.ClickAsync("[data-testid='user-personalterms']");
        var mainDiv = await page.WaitForSelectorAsync("[data-testid='listPersonalTerms']");
        Assert.IsNotNull(await page.QuerySelectorAsync("[data-testid='listPersonalTerms']"), "Personal Terms is not displayed.");
        var personalTermCards = await mainDiv.QuerySelectorAllAsync("[data-testid='divPersonalTermCard']");

        // Provjerite je li svaka kartica osobnog termina prikazana
        foreach (var card in personalTermCards)
        {
            var isDisplayed = await card.EvaluateAsync<bool>("(element) => element.offsetParent !== null");
            Assert.IsTrue(isDisplayed, "Personal term card is not displayed.");
        }
        var dialogTaskCompletionSource = new TaskCompletionSource<IDialog>();
        page.Dialog += async (sender, e) =>
        {
            dialogTaskCompletionSource.SetResult(e);
        };
        //var buttonsdelete= await page.QuerySelectorAllAsync("[data-testid='DeleteTerm']");
        await page.ClickAsync("[data-testid='DeleteTerm']");
        var dialog = await dialogTaskCompletionSource.Task;

        if (dialog.Type == DialogType.Alert)
        {

            var alertText = dialog.Message;


            if (alertText.Contains("Success deleted term"))
            {
                // Sve je u redu, prošlo je
            }

        }
        await page.ScreenshotAsync(new() { Path = "../../../Slike/deleteterm.png" });
    }
    [TearDown]
    public async Task Teardown()
    {
        await page.CloseAsync();
        await browser.DisposeAsync();
    }
}

