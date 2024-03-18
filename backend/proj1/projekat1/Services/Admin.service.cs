public class AdminService{
    private readonly AppDbContext dbContext;

    public AdminService(AppDbContext dbc)
    {
        dbContext=dbc;
    }

    public string createAdmin(AdminEntity newAdmin)
    {
        try{

            if (string.IsNullOrWhiteSpace(newAdmin.Username) || string.IsNullOrWhiteSpace(newAdmin.Password))
            {
                return "Korisnicko ime ili lozinka nisu uneseni";
            }

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


    public string deleteAdmin(int id)
    {
        try
        {
            if( id<=0)
            {
                return "Negativan ID";

            }
           
            var admin = dbContext.Admin.SingleOrDefault(admin => admin.Id == id);
            if (admin != null)
            {
                return "Success";
            }
            else
            {
                return "Not found";
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }


    public string updateAdminUsername(int id, string newUsername)
    {
        try
        {
            if (id <= 0)
            {
                return "Negativan ID";

            }

            var admin = dbContext.Admin.SingleOrDefault(admin => admin.Id == id);
            if (admin != null)
            {
                admin.Username = newUsername;
                dbContext.Update(admin);
                dbContext.SaveChanges();
                return "Success";
            }
            else
            {
                return "Not found";
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public string updatePassword(int id, string newPassword)
    {
        try
        {
            if (id <= 0)
            {
                return "Negativan ID";

            }

            var admin = dbContext.Admin.SingleOrDefault(admin => admin.Id == id);
            if (admin != null)
            {
                admin.Password = newPassword;
                dbContext.Update(admin);
                dbContext.SaveChanges();
                return "Success";
            }
            else
            {
                return "Not found";
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}