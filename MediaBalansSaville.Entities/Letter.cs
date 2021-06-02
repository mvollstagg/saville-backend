namespace MediaBalansSaville.Entities
{
    public class Letter : BaseEntity
    {
        public string FullName { get; set; }  
        public string PhoneNumber { get; set; } 
        public string Email { get; set; } 
        public string Country { get; set; } 
        public string City { get; set; } 
        public string Message { get; set; }
    }
}
