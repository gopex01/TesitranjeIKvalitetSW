using Microsoft.EntityFrameworkCore;

public class NotificationService{
    private readonly AppDbContext dbContext;
    public NotificationService(AppDbContext dbc)
    {
        dbContext=dbc;
    }
    public string addNotification(string message,string username,int idTerm)
    {
        try{
            var term=dbContext.Terms.SingleOrDefault(term=>term.Id==idTerm);
            var user=dbContext.Users.SingleOrDefault(user=>user.Username==username);
            if(user!=null)
            {
                var newNotification=new NotificationEntity();
                newNotification.Content=message;
                newNotification.date=new DateTime();
                newNotification.User=user;
                newNotification.Term=term;
                dbContext.Notifications.Add(newNotification);
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
    public void readNotification(int idNot)
    {
        var not=dbContext.Notifications.SingleOrDefault(not=>not.Id==idNot);
        if(not!=null)
        {
            not.IsRead=true;
            dbContext.Notifications.Update(not);
            dbContext.SaveChanges();
        }
    }
    public async Task<IEnumerable<NotificationEntity>?> GetNotificationsAsync(string username)
{
    var user = await dbContext.Users
        .Include(u => u.listOfNotifications)
        .Where(u => u.Username == username)
        .FirstOrDefaultAsync();

    return user?.listOfNotifications?.Where(not => !not.IsRead);
}

}