using System.Collections.Specialized;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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

            if(newBorderCross.PhoneNumber.Length >=11)
            {
                return "Not valid phoneNumber";
            }
            if(newBorderCross.Username.Length>25)
            {
                return "Not valid username";
            }

            dbContext.CrossBorders.Add(newBorderCross); 
            dbContext.SaveChanges();
            return "new Border Cross added!";
        }
        catch(Exception ex)
        {
            return "Error when adding a border crossing";
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
    public BorderCrossEntity? getOneBC(string username)
    {
        try{
            if(username.Length>25)
            {
                return null;
            }
            var bc=dbContext.CrossBorders.SingleOrDefault(bc=>bc.Username==username);
            if(bc!=null)
            {
                return bc;
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
    public BorderCrossEntity? getBCByName(string name)
    {
        try{

            if(name.Length>25)
            {
                return null;
            }


            var bc=dbContext.CrossBorders.SingleOrDefault(bc=>bc.Name==name);
            if(bc!=null){
            return bc;
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
    public int getNumOfBC()
    {
        int arrBC=dbContext.CrossBorders.ToArray().Length;
        return arrBC;
    }
    public string deleteBC(string name)
    {
        var bc=dbContext.CrossBorders.SingleOrDefault(bc=>bc.Name==name);

          if (name.Length > 25)
        {
            return "Too long name";
        }

        if(bc==null){
            return "Error";
        }
        else{
            dbContext.CrossBorders.Remove(bc);
            dbContext.SaveChanges();
            return "Success";
        }
    }





}