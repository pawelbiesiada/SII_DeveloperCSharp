using System;
using System.Collections.Generic;

namespace CSharpConsole.Exercises.Model
{
    public partial class Group
    {
        public Group()
        {
            UserGroups = new HashSet<UserGroup>();
            Permissions = new HashSet<Permission>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserGroup> UserGroups { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
