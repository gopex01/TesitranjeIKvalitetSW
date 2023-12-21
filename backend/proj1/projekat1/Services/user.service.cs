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
}