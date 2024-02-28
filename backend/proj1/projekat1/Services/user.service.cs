public class UserService{

    private readonly AppDbContext dbContext;

    public UserService(AppDbContext dbc)
    {
        dbContext=dbc;
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



    public int getNumOfUsers()
    {
        int arrUsers=dbContext.Users.ToArray().Length;
        return arrUsers;
    }






}