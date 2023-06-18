using System;
using System.Collections.Generic;

namespace be.Models;

public partial class RoleUser
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
