public class AdminService{
    private readonly AppDbContext dbContext;

    public AdminService(AppDbContext dbc)
    {
        dbContext=dbc;
    }

    public string createAdmin(AdminEntity newAdmin)
    {
        try{
            dbContext.Admin.Add(newAdmin);
            dbContext.SaveChanges();
            return "Admin uspesno dodat";
        }
        catch(Exception ex)
        {
            return $"Greška prilikom dodavanja korisnika ${ex.Message}";
        }
    }
    public AdminEntity? getAdmin(string username)
    {
        try{
            var admin=dbContext.Admin.SingleOrDefault(admin=>admin.Username==username);
            if(admin!=null){
                return admin;
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
}