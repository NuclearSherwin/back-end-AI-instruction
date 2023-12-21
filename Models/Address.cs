namespace backend_lab.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        // Foreign Key
        public int UserId { get; set; }
        public User User { get; set; }
    }   
}