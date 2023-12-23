public class NotificationService{
    private readonly AppDbContext dbContext;
    public NotificationService(AppDbContext dbc)
    {
        dbContext=dbc;
    }
}