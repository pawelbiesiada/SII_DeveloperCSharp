using System;
using System.Collections.Generic;

namespace MyEFApp.Exercises.Model;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<UserGroup> UserGroups { get; } = new List<UserGroup>();
}
