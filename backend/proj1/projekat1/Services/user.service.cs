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
}