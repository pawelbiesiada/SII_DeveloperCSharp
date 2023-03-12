using System;
using System.Collections.Generic;

namespace MyEFApp.Exercises.Model;

public partial class Group
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<UserGroup> UserGroups { get; } = new List<UserGroup>();

    public virtual ICollection<Permission> Permissions { get; } = new List<Permission>();
}
