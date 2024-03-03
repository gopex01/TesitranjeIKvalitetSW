public class UserService{

    private readonly AppDbContext dbContext;

    public UserService(AppDbContext dbc)
    {
        dbContext=dbc;
    }
    public object? login(string username, string password)
    {
        var user = dbContext.Users.FirstOrDefault(user => user.Username == username);
        if (user == null)
        {
            var bc = dbContext.CrossBorders.FirstOrDefault(bc => bc.Username == username);
            if (bc == null)
            {
                var admin = dbContext.Admin.FirstOrDefault(admin => admin.Username == username);
                if (admin == null)
                {
                    return null;
                }
                else
                {
                    if (admin.Password == password)
                    {
                        return new { username= admin.Username,
                        type="admin"};
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else
            {
                if (bc.Password == password)
                {
                    return  new { username=bc.Username,type="bc"};
                }
                else
                {
                    return null;
                }
            }
        }
        else
        {
            if (user.Password == password)
            {
                return new { username = user.Username, type="user" };
            }
            else
            {
                return null;
            }
        }
    }
    public string createUser(UserEntity newUser)
    {
        try{
            dbContext.Users.Add(newUser);
            dbContext.SaveChanges();
            return "Korisnik uspesno dodat";
        }
        catch(Exception ex)
        {
             return $"Greška prilikom dodavanja korisnika: {ex.Message}";
        }
    }
    public UserEntity? getUser(string username)
    {
        try{
            var user=dbContext.Users.SingleOrDefault(user=>user.Username==username);
            if(user !=null)
            {
                return user;
            }
            else{
                return null;
            }
        }
        catch(Exception ex)
        {
            return null; 
        }
    }
    public UserEntity[]? getAllUsers()
    {
        try{
            var users=dbContext.Users.ToArray();
            return users;
        }
        catch(Exception ex)
        {
            return null;
        }
    }
    public string updatePassword(string newPassword,string username)
    {
        try{
            var user=dbContext.Users.SingleOrDefault(user=>user.Username==username);
            if(user!=null)
            {
                user.Password=newPassword;
                dbContext.Users.Update(user);
                dbContext.SaveChanges();
                return "Success";
            }
            else{
                return "Error";
            }
        }
        catch(Exception ex)
        {
               return ex.Message;
        }
    }
    public string deactivateAccount(string username,string password)
    {
        try{
            var user=dbContext.Users.SingleOrDefault(user=>user.Username==username);
            if(user!=null)
            {
                if(user.Password==password){
                    dbContext.Users.Remove(user);
                    dbContext.SaveChanges();
                    return "Success";
                }
                else{
                    return "Error";
                }
            }
            else{
                return "Error";
            }
        }
        catch(Exception ex)
        {
            return ex.Message;
        }
    }
    public string updatePhoneNumber(string newPhoneNumber,string username )
    {
        try{
            var user=dbContext.Users.SingleOrDefault(user=>user.Username==username);
            if(user!=null)
            {
                user.PhoneNumber=newPhoneNumber;
                dbContext.Users.Update(user);
                dbContext.SaveChanges();
                return "Success";
            }
            else{
                return "Error";
            }
        }
        catch(Exception ex)
        {
            return ex.Message;
        }
    }
    public string updateUsername(string newUsername,string username)
    {
        try{
            var user=dbContext.Users.SingleOrDefault(user=>user.Username==username);
            if(user!=null)
            {
                user.Username=newUsername;
                dbContext.Users.Update(user);
                dbContext.SaveChanges();
                return "Success";
            }
            else{
                return "Error";
            }
        }
        catch(Exception ex)
        {
            return ex.Message;
        }
    }
    public string updateName(string newName,string username)
    {
         try{
            var user=dbContext.Users.SingleOrDefault(user=>user.Username==username);
            if(user!=null)
            {
                user.NameAndSurname=newName;
                dbContext.Users.Update(user);
                dbContext.SaveChanges();
                return "Success";
            }
            else{
                return "Error";
            }
        }
        catch(Exception ex)
        {
            return ex.Message;
        }
    }


    public string updateEmail(string newEmail, string username)
    {
        try
        {
            var user = dbContext.Users.SingleOrDefault(user => user.Username == username);
            if (user != null)
            {
                user.Email = newEmail;
                dbContext.Users.Update(user);
                dbContext.SaveChanges();
                return "Success";
            }
            else
            {
                return "Error";
            }
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }



    public int getNumOfUsers()
    {
        int arrUsers=dbContext.Users.ToArray().Length;
        return arrUsers;
    }






}