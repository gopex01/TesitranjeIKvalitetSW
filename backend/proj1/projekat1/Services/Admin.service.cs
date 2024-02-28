public class AdminService{
    private readonly AppDbContext dbContext;

    public AdminService(AppDbContext dbc)
    {
        dbContext=dbc;
    }

    public string createAdmin(AdminEntity newAdmin)
    {
        try{
            var adminExist = this.getAdmin(newAdmin.Username);
            if (adminExist == null)
            {
                dbContext.Admin.Add(newAdmin);
                dbContext.SaveChanges();
                return "Admin uspesno dodat";
            }
            else
            {
                return "Admin vec postoji";
            }
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