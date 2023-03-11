using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace EFTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //AddUsers();
                LazyLoadUserGroups();
                //GetActiveUsersWithSp();

                using (var ctx = new EFTestDbEntities())
                {
                    ctx.pGetUsers(true);
                }
            }
            catch (DbEntityValidationException vex)
            {
                //TODO log and fix invalid stuff
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            Console.ReadKey();
        }
        
        static void AddUsers()
        {
            using (var dbCtx = new EFTestDbEntities())
            {
                try
                {
                    dbCtx.Database.CommandTimeout = 10;
                    dbCtx.Database.Log = Console.WriteLine;

                    //dbCtx.Users.RemoveRange(dbCtx.Users);
                    //dbCtx.Groups.RemoveRange(dbCtx.Groups);
                    //dbCtx.UserGroups.RemoveRange(dbCtx.UserGroups);

                    var user = dbCtx.Users.Add(new User {Name = "John", Password = "Password", IsActive = true });

                    Group group = null; 
                    if (!dbCtx.Groups.Any(el => el.Name == "Administrator"))
                    {
                        group = dbCtx.Groups.Add(new Group {Name = "Administrator" });
                    }
                    //var users = dbCtx.Users.Include(e => e.Name).ToList();
                    dbCtx.SaveChanges();

                    if (group != null)
                    {
                        var userGroupId = dbCtx.UserGroups.Max(el => el.Id);
                        var userGroup = dbCtx.UserGroups.Add(new UserGroup() { Id = userGroupId + 1, GroupId = group.Id, UserId = user.Id });

                        dbCtx.SaveChanges();

                        var c = user.UserGroups.Count;
                    }
                    var count = dbCtx.Users.First().UserGroups.Count;

                    dbCtx.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        static void LazyLoadUserGroups()
        {
            using (var dbCtx = new EFTestDbEntities())
            {
                dbCtx.Database.CommandTimeout = 10;
                dbCtx.Configuration.LazyLoadingEnabled = true;
                dbCtx.Database.Log = Console.WriteLine;

                var user = dbCtx.Users
                    .Where(u => u.Name == "John")
                    //.Include(u => u.UserGroups)  //That would be eager loading
                    .First();
                
                var entity = dbCtx.Entry(user);
                //entity.State = EntityState.Added;
                entity.Collection(e => e.UserGroups).Query().Load(); //That is lazy loading referenced collection
                dbCtx.SaveChanges();

                //dbCtx.Users.Local.ToBindingList();
            }
        }

        private static void GetActiveUsersWithSp()
        {
            using (var dbCtx = new EFTestDbEntities())
            {

                dbCtx.Database.CommandTimeout = 10;
                dbCtx.Configuration.LazyLoadingEnabled = true;
                dbCtx.Database.Log = Console.WriteLine;

                var activeUsers = dbCtx.pGetUsers(true);

                foreach (var activeUser in activeUsers)
                {
                    Console.WriteLine(activeUser.Name);
                }
            }
        }
    }
}
 