

using System.Drawing;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

public class TerminService
{

    private readonly AppDbContext dbContext;
    private readonly BorderCrossService bcService;
    private readonly UserService userService;
    

    public TerminService(AppDbContext dbc,BorderCrossService bcs,UserService usS)
    {
        dbContext=dbc;
        bcService=bcs;
        userService=usS;
    }


public async Task<string> createTermin(TermEntity newTermin, string username, string bcname)
{
    try
    {
        DateTime? selectedDate = newTermin.DateAndTime;
        if (selectedDate.HasValue)
        {
            Console.WriteLine(selectedDate.Value);
            var x = await FindNextAvailableTermAsync(DateTime.Now);
            Console.Write("Stipendija");
            Console.WriteLine(x);
            // DateTime? newDate = DateTime.Now;//;
            // // // Rad s newDate...

            // // // Postavljanje vremena na UTC pre dodavanja u bazu podataka
            // newTermin.DateAndTime = DateTime.SpecifyKind(newDate.Value, DateTimeKind.Utc);

            // var user = dbContext.Users.SingleOrDefault(user => user.Username == username);
            // var bc = dbContext.CrossBorders.SingleOrDefault(bc => bc.Name == bcname);
            // user.listOfTerms ??= new List<TermEntity>();
            // user.listOfTerms.Add(newTermin);
            // bc.listOfTerms ??= new List<TermEntity>();
            // bc.listOfTerms.Add(newTermin);
            // newTermin.DateAndTime = newDate;
            // newTermin.IsComeBack = false;
            // newTermin.IsComeBack = false;
            // newTermin.IsPaid = false;
            // newTermin.Accepted = false;
            // newTermin.Irregularities = "";
            // dbContext.Terms.Add(newTermin);
            // dbContext.SaveChanges();
            return "Success";
        }
        else
        {
            return "Error";
        }
    }
    catch (Exception ex)
    {
        var innerException = ex.InnerException;
        Console.WriteLine(innerException);
        return $"Error when adding a border crossing : {ex.Message}";
        //return $"Error when adding a border crossing : {ex.Message}";
    }
}


   public async Task<DateTime> FindNextAvailableTermAsync(DateTime selectedDate)
{
    if (selectedDate == null)
    {
        // Handle the case where selectedDate is null
        throw new ArgumentNullException(nameof(selectedDate));
    }

    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("opsala");
    selectedDate = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, 0, 0, 0, 0);


    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("opsala2");
    var overlappingTerms = await dbContext.Terms
        .Where(term => term.DateAndTime != null && term.DateAndTime.Value >= selectedDate && term.DateAndTime.Value < selectedDate.AddDays(1))
        .Select(p => new {
            DateAndTime= p.DateAndTime!
        })
        //.OrderBy(term => term.DateAndTime.Value)
        .ToListAsync();

    var nextAvailableDate = new DateTime(selectedDate.Ticks);

    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("op");

    while (overlappingTerms.Any(term => term.DateAndTime != null && term.DateAndTime.Value.Ticks == nextAvailableDate.Ticks))
    {
        nextAvailableDate = nextAvailableDate.AddMinutes(30);
    }
    Console.WriteLine("opop");

    if (nextAvailableDate.Hour >= 23 && nextAvailableDate.Minute >= 30)
    {
        nextAvailableDate = nextAvailableDate.AddDays(1).Date;
    }
    Console.WriteLine("opopop");

    return selectedDate;
}
    public async Task<IEnumerable<TermEntity>?> GetTermsAsync(string username)
    {
        var bc = bcService.getOneBC(username);

        var term = await dbContext.CrossBorders
            .Include(bc => bc.listOfTerms)
            .Where(bc => bc.Username == username)
            .FirstOrDefaultAsync();

        return term?.listOfTerms?.Where(t => t.Accepted == true);
    }

    public int? getNumOfTerms()
    {
        try{
            var arrTerms=dbContext.Terms.ToArray().Length;
            return arrTerms;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public async Task<IEnumerable<TermEntity>?> GetPersonalTermsAsync(string username)
{
    var user =  userService.getUser(username);

    var term = await dbContext.Users
        .Include(u => u.listOfTerms)
        .Where(u => u.Username == username)
        .FirstOrDefaultAsync();

    return term?.listOfTerms?.Where(t => t.Accepted == true);
}

    public async Task<object> getAllTerms()
    {
        var selectedDate = DateTime.Now;
        var overlappingTerms = await dbContext.Terms
        .Where(term => term.DateAndTime != null && term.DateAndTime.Value >= selectedDate && term.DateAndTime.Value < selectedDate.AddDays(1))
        .Select(p => new {
            DateAndTime= p.DateAndTime!
        })
        //.OrderBy(term => term.DateAndTime.Value)
        .ToListAsync();
        return overlappingTerms;//await dbContext.Terms.Select(p => p).ToListAsync();
    }
}