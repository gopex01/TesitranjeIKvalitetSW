

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
        var user=userService.getUser(username);
        var bc=bcService.getBCByName(bcname);
        if(bc==null || user==null)
        {
            return "Error";
        }
        else{
        newTermin.borderCross=bc;
        newTermin.user=user;
        newTermin.IsPaid=false;
        newTermin.IsComeBack=false;
        newTermin.IsCrossed=false;
        dbContext.Terms.Add(newTermin);
        dbContext.SaveChanges();
        return "Success";
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
    public async Task<IEnumerable<TermEntity>?> GetTermsAsync(string username)
    {
        var bc = bcService.getOneBC(username);
        Console.WriteLine(bc);
        var term = await dbContext.CrossBorders
            .Include(b => b.listOfTerms)
            .Where(b => b.Username == username)
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
}