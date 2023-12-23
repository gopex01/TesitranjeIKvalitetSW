using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class UserEntity{
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id{get;set;}
    public string? NameAndSurname{get;set;}
    public string? Email{get;set;}
    public string? Username{get;set;}
    public string? Password{get;set;}
    public string? PhoneNumber{get;set;}
    public int Age{get;set;}
    public string? JMBG{get;set;}
    public bool Verified{get;set;}=false;


    public ICollection<TermEntity>? listOfTerms{get; set;}

}