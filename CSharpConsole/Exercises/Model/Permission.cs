using System;
using System.Collections.Generic;

namespace CSharpConsole.Exercises.Model
{
    public partial class Permission
    {
        public Permission()
        {
            Groups = new HashSet<Group>();
        }

        public int Id { get; set; }
        public string Permission1 { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
