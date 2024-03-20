using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

[Parallelizable(ParallelScope.Self)]
public class BCProfile:PageTest
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
    public async Task LoginBC()
    {
        await page.GotoAsync("http://localhost:4200");

        await page.WaitForSelectorAsync("[data-testid='mainDivLogin']");
        await page.FillAsync("[data-testid='inputUsername']", "Gradina");
        await page.FillAsync("[data-testid='inputPassword']", "Gradina");

        await page.WaitForSelectorAsync("[data-testid='buttonLogin']");
        await page.ClickAsync("[data-testid='buttonLogin']");
    }
    [Test]
    public async Task LoginTest()
    {
        await page.GotoAsync("http://localhost:4200");

        await page.WaitForSelectorAsync("[data-testid='mainDivLogin']");

        Assert.IsNotNull(await page.QuerySelectorAsync("[data-testid='mainDivLogin']"), "Login page is not displayed.");

        await page.FillAsync("[data-testid='inputUsername']", "Gradina");
        await page.FillAsync("[data-testid='inputPassword']", "Gradina");

        await page.WaitForSelectorAsync("[data-testid='buttonLogin']");
        await page.ClickAsync("[data-testid='buttonLogin']");

        await page.WaitForSelectorAsync("[data-testid='bc-container']");
        Assert.IsNotNull(await page.QuerySelectorAsync("[data-testid='bc-container']"), "BC profile is not displayed.");

        await page.ScreenshotAsync(new() { Path = "../../../Slike/loginBC.png" });
    }
    [Test]
    public async Task AllTermsBC()
    {
        await LoginBC();
        await page.ClickAsync("[data-testid='button-allterms']");
        var maindiv = await page.WaitForSelectorAsync("[data-testid='bcallterms']");
        Assert.IsNotNull(await page.QuerySelectorAsync("[data-testid='bcallterms']"), "BC Terms is not displayed.");
        var bcTermCards = await maindiv.QuerySelectorAllAsync("[data-testid='divBcTermCard']");
        foreach (var card in bcTermCards)
        {
            var isDisplayed = await card.EvaluateAsync<bool>("(element) => element.offsetParent !== null");
            Assert.IsTrue(isDisplayed, "Personal term card is not displayed.");
        }

        await page.ScreenshotAsync(new() { Path = "../../../Slike/bcTerms.png" });
    }
    [Test]
    public async Task clickLogOut()
    {
        await LoginBC();

        await page.ClickAsync("[data-testid='button-logout']");
        var mainDiv = await page.WaitForSelectorAsync("[data-testid='mainDivLogin']");
        Assert.IsNotNull(await page.QuerySelectorAsync("[data-testid='mainDivLogin']"), "Login page is not displayed.");


        await page.ScreenshotAsync(new() { Path = "../../../Slike/logoutbc.png" });
    }
    [Test]
    public async Task clickAllBCS()
    {
        await LoginBC();
        await page.ClickAsync("[data-testid='button-allbcs']");
        var mainDiv = await page.WaitForSelectorAsync("[data-testid='listbc']");
        Assert.IsNotNull(await page.QuerySelectorAsync("[data-testid='listbc']"), "List BoredrCross is not displayed");
        var listBCS = await mainDiv.QuerySelectorAllAsync("[data-testid='bc-card']");

        foreach (var bc in listBCS)
        {
            var isDisplayed = await bc.EvaluateAsync<bool>("(element)=>element.offsetParent!==null");
            Assert.IsTrue(isDisplayed, "Border Cross card is not displayed");
        }
        await page.ScreenshotAsync(new() { Path = "../../../Slike/allBCSBC.png" });
    }
    [Test]
    public async Task updateTerm()
    {
        await LoginBC();
        await page.ClickAsync("[data-testid='button-allterms']");
        var maindiv = await page.WaitForSelectorAsync("[data-testid='bcallterms']");
        Assert.IsNotNull(await page.QuerySelectorAsync("[data-testid='bcallterms']"), "BC Terms is not displayed.");
        var irregularitiesElements = await page.QuerySelectorAllAsync("[data-testid='inputiregularities']");
        if (irregularitiesElements.Count > 0)
        {
           
            var firstIrregularityElement = irregularitiesElements[0];

            
            await firstIrregularityElement.FillAsync("Ne postoje nepravilnosti");
        }

        var checkboxElements = await page.QuerySelectorAllAsync("[data-testid='inputIsCrossed']");

        
        if (checkboxElements.Count > 0)
        {
           
            var firstCheckboxElement = checkboxElements[0];

          
            await firstCheckboxElement.ClickAsync();
        }

        var checkboxElementstw = await page.QuerySelectorAllAsync("[data-testid='inputIsComeBack']");

        
        if (checkboxElementstw.Count > 0)
        {
           
            var firstCheckboxElement = checkboxElementstw[0];

            
            await firstCheckboxElement.ClickAsync();
        }

        var dialogTaskCompletionSource = new TaskCompletionSource<IDialog>();
        page.Dialog += async (sender, e) =>
        {
            dialogTaskCompletionSource.SetResult(e);
        };
        await page.ClickAsync("[data-testid='updatetermbutton']");

        var dialog = await dialogTaskCompletionSource.Task;

        if (dialog.Type == DialogType.Alert)
        {

            var alertText = dialog.Message;


            if (alertText.Contains("Success updated term!"))
            {
                // Sve je u redu, prošlo je
            }

        }

        await page.ScreenshotAsync(new() { Path = "../../../Slike/updateterm.png" });

    }
    [TearDown]
    public async Task Teardown()
    {
        await page.CloseAsync();
        await browser.DisposeAsync();
    }
}
