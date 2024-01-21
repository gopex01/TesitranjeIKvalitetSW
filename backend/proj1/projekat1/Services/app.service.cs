public class LoginResult
{
    public string username{get;set;}
    public string type{get;set;}

    public LoginResult(string user,string typ)
    {
        username=user;
        type=typ;
    }
}
public class AppService{
    private readonly AppDbContext dbContext;

    public AppService(AppDbContext dbc)
    {
        dbContext=dbc;
    }

    public LoginResult? login(string username,string password)
    {
        try{

            var user=dbContext.Users.SingleOrDefault(user=>user.Username==username);
            if(user!=null)
            {
                if(user.Password==password)
                {
                   return new LoginResult(username,"user");
                }
                else{
                    return null;
                }
            }
            else
            {
                var bc=dbContext.CrossBorders.SingleOrDefault(bc=>bc.Username==username);
                if(bc!=null)
                {
                    if(bc.Password==password)
                    {
                        return new LoginResult(username,"bc");
                    }
                    else{
                        return null;
                    }
                }
                else
                {
                    var admin=dbContext.Admin.SingleOrDefault(admin=>admin.Username==username);
                    if(admin!=null)
                    {
                        if(admin.Password==password)
                        {
                            return new LoginResult(username,"admin");
                        }
                        else{
                            return null;
                        }
                    }
                    else{
                        return null;
                    }
                }
            }
        }
        catch(Exception ex)
        {
            return null;
        }
    }
}