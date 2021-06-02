using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MediaBalansSaville.Entities
{
    public class User : BaseEntity
    {        
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required, RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string SecretKey { get; set; } = Guid.NewGuid().ToString().Replace("-", "") + DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "");
        [NotMapped]
        public string FullName{get{return this.FirstName+" "+this.LastName;} private set{}}
        public virtual ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();        
    }
}
