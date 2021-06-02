﻿ 
using System.Collections.Generic;

namespace MediaBalansSaville.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    }
}
