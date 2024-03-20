using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
public class Tests:PageTest

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

    [Test]
    public async Task LoginTest()
    {
        await page.GotoAsync("http://localhost:4200");

        await page.WaitForSelectorAsync("[data-testid='mainDivLogin']");

        Assert.IsNotNull(await page.QuerySelectorAsync("[data-testid='mainDivLogin']"), "Login page is not displayed.");

        await page.FillAsync("[data-testid='inputUsername']", "petar");
        await page.FillAsync("[data-testid='inputPassword']", "petar");

        await page.WaitForSelectorAsync("[data-testid='buttonLogin']");
        await page.ClickAsync("[data-testid='buttonLogin']");

        await page.WaitForSelectorAsync("[data-testid='user-profile-container']");
        Assert.IsNotNull(await page.QuerySelectorAsync("[data-testid='user-profile-container']"), "User profile is not displayed.");

        await page.ScreenshotAsync(new() { Path = "../../../Slike/login.png" });
    }
    [Test]
    public async Task SignUpTest()
    {
        await page.GotoAsync("http://localhost:4200/SignUp");
        await page.WaitForSelectorAsync("[data-testid='mainDivSignUp']");
        Assert.IsNotNull(await page.QuerySelectorAllAsync("[data-testid='mainDivSignUp']"), "Signup is not displayed");

        await page.FillAsync("[data-testid='inputNameAndSurname']", "Mihajlo Madic");
        await page.FillAsync("[data-testid='inputEmail']", "mihajlomadic@gmail.com");
        await page.FillAsync("[data-testid='inputUsername']", "mixa");
        await page.FillAsync("[data-testid='inputPassword']", "mixa");
        await page.FillAsync("[data-testid='inputPhoneNumber']", "065981919");
        await page.FillAsync("[data-testid='inputAge']", "25");
        await page.FillAsync("[data-testid='inputJMBG']", "902980100101");

        await page.WaitForSelectorAsync("[data-testid='buttonSignUp']");
        await page.ClickAsync("[data-testid='buttonSignUp']");
        var dialogTaskCompletionSource = new TaskCompletionSource<IDialog>();
        page.Dialog += async (sender, e) =>
        {
            dialogTaskCompletionSource.SetResult(e);
        };
        await page.ClickAsync("[data-testid='buttonSignUp']");

       
        var dialog = await dialogTaskCompletionSource.Task;

        if (dialog.Type == DialogType.Alert)
        {
           
            var alertText = dialog.Message;

           
            if (alertText.Contains("Success registration"))
            {
                // Sve je u redu, prošlo je
            }
          
        }
       
        

        await page.ScreenshotAsync(new() { Path = "../../../Slike/signup.png" });
    }

    [TearDown]
    public async Task Teardown()
    {
        await page.CloseAsync();
        await browser.DisposeAsync();
    }
}