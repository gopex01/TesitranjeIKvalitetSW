public class BorderCrossService
{

    private readonly AppDbContext dbContext;

    public BorderCrossService(AppDbContext dbc)
    {
        dbContext=dbc;
    }

    public string createBorderCross(BorderCrossEntity newBorderCross)
    {
        try{
            dbContext.CrossBorders.Add(newBorderCross); 
            dbContext.SaveChanges();
            return "new Border Cross added!";
        }
        catch(Exception ex)
        {
            return $"Error when adding a border crossing : {ex.Message}";
        }
    }

     public BorderCrossEntity? getBorderCross(string ID_Name)
    {
        try{
            var BC=dbContext.CrossBorders.SingleOrDefault(BC=>BC.Name==ID_Name);
            if(BC !=null)
            {
                return BC;
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


    public BorderCrossEntity[]? getALLBCS()
    {
        try{
            var BCS=dbContext.CrossBorders.ToArray();
            return BCS;
        }
        catch(Exception ex)
        {
            return null;
        }
    }





}