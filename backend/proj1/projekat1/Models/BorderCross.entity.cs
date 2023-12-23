using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



   // [Table("BorderCross", Schema = "dbo")] // Define the table name and schema
    public class BorderCrossEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public string Type { get; set; }
        public string WorkHour { get; set; }
        public string TransportConnections { get; set; }
        public string Capacity { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        

      
    }



