

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
    public TermEntity[] GetTermsAsync(string username)
    {
        var terms=dbContext.Terms
        .Where(t=>t.borderCross.Username==username)
        .ToArray<TermEntity>();
        return terms;
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


    public TermEntity[] GetPersonalTermsAsync(string username)
    {
        var terms= dbContext.Terms
        .Where(t=>t.user.Username==username)
        .ToArray<TermEntity>();
        return terms;
    
    }

    public string updateTerm(int id,bool IsCrossed,bool IsComeBack,string irreg)
    {
        var term=dbContext.Terms.FirstOrDefault(t=>t.Id==id);
        if(term==null)
        {
            return "error";
        }
        term.IsCrossed=IsCrossed;
        term.IsComeBack=IsComeBack;
        term.Irregularities=irreg;   
        dbContext.Terms.Update(term);
        dbContext.SaveChanges();
        return "Success";
    }
}