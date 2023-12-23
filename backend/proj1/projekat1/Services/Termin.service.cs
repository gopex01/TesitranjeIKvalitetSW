

public class TerminService
{

    private readonly AppDbContext dbContext;
    

    public TerminService(AppDbContext dbc)
    {
        dbContext=dbc;
    }


    public string? createTermin(TermEntity newTermin, string username)
    {
        try{
            var user=dbContext.Users.SingleOrDefault(user=>user.Username==username);
           user.listOfTerms??=new List<TermEntity>();
           user.listOfTerms.Add(newTermin);


           
            dbContext.Terms.Add(newTermin);
            dbContext.SaveChanges();
            return "new Termin  added!";
        }
        catch(Exception  ex)
        {
            var innerException= ex.InnerException;
            Console.WriteLine(innerException);
            return $"Error when adding a border crossing : {ex.Message}";
            //return $"Error when adding a border crossing : {ex.Message}";
        }
    }

}