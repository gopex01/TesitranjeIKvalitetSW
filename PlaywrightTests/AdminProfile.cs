

using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

[Parallelizable(ParallelScope.Self)]
public class AdminProfile : PageTest
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
    
    public async Task loginAdmin()
    {
        await page.GotoAsync("http://localhost:4200");

        await page.WaitForSelectorAsync("[data-testid='mainDivLogin']");
        await page.FillAsync("[data-testid='inputUsername']", "Admin");
        await page.FillAsync("[data-testid='inputPassword']", "Admin");

        await page.WaitForSelectorAsync("[data-testid='buttonLogin']");
        await page.ClickAsync("[data-testid='buttonLogin']");
    }
    [Test]
    public async Task clickAllBCS()
    {
        await loginAdmin();
        await page.ClickAsync("[data-testid='allbcs']");
        var mainDiv = await page.WaitForSelectorAsync("[data-testid='listbc']");
        Assert.IsNotNull(await page.QuerySelectorAsync("[data-testid='listbc']"), "List BoredrCross is not displayed");
        var listBCS = await mainDiv.QuerySelectorAllAsync("[data-testid='bc-card']");

        foreach (var bc in listBCS)
        {
            var isDisplayed = await bc.EvaluateAsync<bool>("(element)=>element.offsetParent!==null");
            Assert.IsTrue(isDisplayed, "Border Cross card is not displayed");
        }
        await page.ScreenshotAsync(new() { Path = "../../../Slike/allBCSAdmin.png" });
    }
    [Test]
    public async Task clickAllUsers()
    {
        await loginAdmin();
        await page.ClickAsync("[data-testid='allusers']");
        var mainDiv=await page.WaitForSelectorAsync("[data-testid='alluserscontainer']");
        Assert.IsNotNull(await page.QuerySelectorAsync("[data-testid='alluserscontainer']"), "List Users is not displayed");
        var listUsers = await mainDiv.QuerySelectorAllAsync("[data-testid='usercard']");

        foreach (var bc in listUsers)
        {
            var isDisplayed = await bc.EvaluateAsync<bool>("(element)=>element.offsetParent!==null");
            Assert.IsTrue(isDisplayed, "User card is not displayed");
        }
        await page.ScreenshotAsync(new() { Path = "../../../Slike/allUsers.png" });
    }
    [Test]
    public async Task LoginTest()
    {
        await page.GotoAsync("http://localhost:4200");

        await page.WaitForSelectorAsync("[data-testid='mainDivLogin']");

        Assert.IsNotNull(await page.QuerySelectorAsync("[data-testid='mainDivLogin']"), "Login page is not displayed.");

        await page.FillAsync("[data-testid='inputUsername']", "Admin");
        await page.FillAsync("[data-testid='inputPassword']", "Admin");

        await page.WaitForSelectorAsync("[data-testid='buttonLogin']");
        await page.ClickAsync("[data-testid='buttonLogin']");

        await page.WaitForSelectorAsync("[data-testid='admin-container']");
        Assert.IsNotNull(await page.QuerySelectorAsync("[data-testid='admin-container']"), "Admin profile is not displayed.");

        await page.ScreenshotAsync(new() { Path = "../../../Slike/loginADMIN.png" });
    }
    [Test]
    public async Task addBC()
    {
        await loginAdmin();
        await page.ClickAsync("[data-testid='addbcadmin']");
        await page.WaitForSelectorAsync("[data-testid='create-bc-container']");
        Assert.IsNotNull(await page.QuerySelectorAsync("[data-testid='create-bc-container']"), "Create BC is not displayed");

        await page.FillAsync("[data-testid='Name']","Presevo");
        await page.FillAsync("[data-testid='Username']","Presevo");
        await page.FillAsync("[data-testid='Password']","Presevo");
        await page.FillAsync("[data-testid='Location']","South");
        await page.FillAsync("[data-testid='Country']","Srbija");
        await page.FillAsync("[data-testid='Type']","Putni");
        await page.FillAsync("[data-testid='WorkHour']","00-24h");
        await page.FillAsync("[data-testid='TransportConnections']","Putni");
        await page.FillAsync("[data-testid='Capacity']","12");
        await page.FillAsync("[data-testid='Email']","presevo@srb.rs");
        await page.FillAsync("[data-testid='PhoneNumber']","0192001919");
        await page.FillAsync("[data-testid='Description']","Nema opisa trenutno");

        var dialogTaskCompletionSource = new TaskCompletionSource<IDialog>();
        page.Dialog += async (sender, e) =>
        {
            dialogTaskCompletionSource.SetResult(e);
        };
        await page.ClickAsync("[data-testid='addbcbutton']");

        var dialog = await dialogTaskCompletionSource.Task;

        if (dialog.Type == DialogType.Alert)
        {

            var alertText = dialog.Message;


            if (alertText.Contains("Sucess added border cross"))
            {
                // Sve je u redu, prošlo je
            }

        }

        await page.ScreenshotAsync(new() { Path = "../../../Slike/createbc.png" });

    }
    [Test]
    public async Task deleteBC()
    {
        await loginAdmin();
        await page.ClickAsync("[data-testid='deletebc']");
        var mainDiv=await page.WaitForSelectorAsync("[data-testid='deletebccontainer']");
        Assert.IsNotNull(await page.QuerySelectorAsync("[data-testid='deletebccontainer']"), "Delete BC is not displayed");
        var listBCS = await mainDiv.QuerySelectorAllAsync("[data-testid='bccarddelete']");

        foreach (var bc in listBCS)
        {
            var isDisplayed = await bc.EvaluateAsync<bool>("(element)=>element.offsetParent!==null");
            Assert.IsTrue(isDisplayed, "Border Cross card is not displayed");
        }
        var deleteButtons= await page.QuerySelectorAllAsync("[data-testid='delete-bc-button']");
        if (deleteButtons.Count > 0)
        {
            // Odabir prvog pronađenog čekboksa
            var deletebutton = deleteButtons[0];

            // Klik na prvi čekboksvar dialogTaskCompletionSource = new TaskCompletionSource<IDialog>();
            var dialogTaskCompletionSource = new TaskCompletionSource<IDialog>();
            page.Dialog += async (sender, e) =>
            {
                dialogTaskCompletionSource.SetResult(e);
            };
            await deletebutton.ClickAsync();
            var dialog = await dialogTaskCompletionSource.Task;

            if (dialog.Type == DialogType.Alert)
            {

                var alertText = dialog.Message;


                if (alertText.Contains("Success deleted border cross"))
                {
                    // Sve je u redu, prošlo je
                }

            }
        }
        await page.ScreenshotAsync(new() { Path = "../../../Slike/deleteBC.png" });


    }
   
    [Test]
    public async Task clickLogOut()
    {
        await loginAdmin();

        await page.ClickAsync("[data-testid='logout']");
        var mainDiv = await page.WaitForSelectorAsync("[data-testid='mainDivLogin']");
        Assert.IsNotNull(await page.QuerySelectorAsync("[data-testid='mainDivLogin']"), "Login page is not displayed.");


        await page.ScreenshotAsync(new() { Path = "../../../Slike/logoutadmin.png" });
    }
    [TearDown]
    public async Task Teardown()
    {
        await page.CloseAsync();
        await browser.DisposeAsync();
    }
}

